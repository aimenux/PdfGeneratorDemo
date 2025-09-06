using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace DinkToPdfLib;

/// <summary>
/// See issue : https://github.com/rdvojmoc/DinkToPdf/issues/119
/// </summary>
public sealed class StaSynchronizedConverter : BasicConverter
{
    private bool _kill;
    private Thread? _conversionThread;
    private readonly Lock _startLock = new();
    private readonly BlockingCollection<Task> _conversions = [];

    public StaSynchronizedConverter(ITools tools) : base(tools)
    {
    }

    public override byte[] Convert(IDocument document)
    {
        return Invoke(() => base.Convert(document));
    }

    private TResult Invoke<TResult>(Func<TResult> @delegate)
    {
        StartThread();

        var task = new Task<TResult>(@delegate);

        lock (task)
        {
            _conversions.Add(task);
            Monitor.Wait(task);
        }

        if (task.Exception != null)
        {
            throw task.Exception;
        }

        return task.Result;
    }

    private void StartThread()
    {
        lock (_startLock)
        {
            if (_conversionThread == null)
            {
                _conversionThread = new Thread(Run)
                {
                    IsBackground = true,
                    Name = "wkhtmltopdf worker thread"
                };

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    _conversionThread.SetApartmentState(ApartmentState.STA);
                }

                _kill = false;

                _conversionThread.Start();
            }
        }
    }

    private void Run()
    {
        while (!_kill)
        {
            var task = _conversions.Take();

            lock (task)
            {
                task.RunSynchronously();
                Monitor.Pulse(task);
            }
        }
    }
}