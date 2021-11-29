using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

internal static class Timeout
{
    private static readonly ConcurrentDictionary<int, Thread> InnerDic;

    private static int _handle;

    static Timeout()
    {
        InnerDic = new ConcurrentDictionary<int, Thread>();
    }

    public static int Set(Action action, int delayMs = 0) //, bool iscontext = false
    {
        var handle = Interlocked.Increment(ref _handle);
        //HttpContext context = (iscontext ? HttpContext.Current : null);
        var thread = new Thread(new ThreadStart(delegate
        {
            if (delayMs > 0) Thread.Sleep(delayMs);
            Thread _;
            InnerDic.TryRemove(handle, out _);
            Task.Factory.StartNew(action);
            //Task.Factory.StartNew(()=> {
            //if (context != null) HttpContext.Current = context;
            //action();
            //}); //, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default
        }));
        InnerDic.TryAdd(handle, thread);

        thread.Start();
        return handle;
    }

    public static void Clear(int handle)
    {
        Thread thread;
        if (InnerDic.TryRemove(handle, out thread))
            thread.Abort();
    }
}