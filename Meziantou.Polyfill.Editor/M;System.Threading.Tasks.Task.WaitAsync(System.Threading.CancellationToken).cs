﻿using System.Threading.Tasks;
using System.Threading;

static partial class PolyfillExtensions
{
    /// <summary>
    /// Gets a <see cref="Task{TResult}"/> that will complete when the <paramref name="task"/> completes or when the specified <paramref name="cancellationToken"/> has cancellation requested.
    /// </summary>
    /// <typeparam name="TResult">The type of the task result.</typeparam>
    /// <param name="task">The task to wait on for completion.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for a cancellation request.</param>
    /// <returns>The <see cref="Task{TResult}"/> representing the asynchronous wait.</returns>
    public static Task<TResult> WaitAsync<TResult>(this Task<TResult> task, CancellationToken cancellationToken)
    {
        if (task.IsCompleted || (!cancellationToken.CanBeCanceled))
        {
            return task;
        }

        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromCanceled<TResult>(cancellationToken);
        }

        return WaitTask.WaitTaskAsync(task, cancellationToken);
    }
}

file sealed class WaitTask
{
    public static async Task<TResult> WaitTaskAsync<TResult>(Task<TResult> task, CancellationToken cancellationToken)
    {
        var tcs = new TaskCompletionSource<TResult>(TaskCreationOptions.RunContinuationsAsynchronously);
        using (cancellationToken.Register(static state => ((TaskCompletionSource<TResult>)state!).SetCanceled(), tcs, false))
        {
            var t = await Task.WhenAny(task, tcs.Task).ConfigureAwait(false);
            return t.GetAwaiter().GetResult();
        }
    }
}