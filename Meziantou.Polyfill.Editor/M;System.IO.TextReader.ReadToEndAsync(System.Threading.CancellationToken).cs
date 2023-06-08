﻿using System.IO;
using System.Threading;
using System.Threading.Tasks;

static partial class PolyfillExtensions
{
    public static Task<string> ReadToEndAsync(this TextReader target, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return target.ReadToEndAsync();
    }
}