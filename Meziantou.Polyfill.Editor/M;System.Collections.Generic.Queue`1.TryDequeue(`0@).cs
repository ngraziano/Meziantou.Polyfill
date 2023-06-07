using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

static partial class PolyfillExtensions
{
    public static bool TryDequeue<T>(this Queue<T> target, [MaybeNullWhen(false)] out T result)
    {
        if (target.Count == 0)
        {
            result = default;
            return false;
        }

        result = target.Dequeue();
        return true;
    }
}