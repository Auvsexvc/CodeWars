using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

public class Worker
{

    public class ExecutedTasks
    {
        public readonly IList<Runnable> successful = new List<Runnable>();
        public readonly ISet<Runnable> failed = new HashSet<Runnable>();
        public readonly ISet<Runnable> timedOut = new HashSet<Runnable>();
    }

    public readonly struct Runnable
    {
        private readonly Action _Action;

        public Runnable(Action action) => _Action = action;
        public void Run() => _Action();

        public static implicit operator Action(Runnable runnable) => runnable.Run;
    }

    public ExecutedTasks Execute(IEnumerable<Runnable> actions, TimeSpan timeout)
    {
        var result = new ExecutedTasks();
        var cancellationToken = new CancellationTokenSource(timeout).Token;
        Task.WaitAll(actions.Select(action => Task.Factory.StartNew(() => {
                try
                {
                    var task = Task.Factory.StartNew(action, TaskCreationOptions.LongRunning);
                    task.Wait(cancellationToken);
                    result.successful.Add(action);
                }
                catch (OperationCanceledException)
                {
                    result.timedOut.Add(action);
                }
                catch (Exception)
                {
                    result.failed.Add(action);
                }
            }, TaskCreationOptions.LongRunning)).ToArray());

        return result;
    }
}