﻿using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;

static partial class PolyfillExtensions
{
    public static void CopyTo(this HttpContent target, Stream stream, TransportContext? context, CancellationToken cancellationToken)
    {
        target.CopyToAsync(stream, context, cancellationToken).Wait(cancellationToken);
    }
}
