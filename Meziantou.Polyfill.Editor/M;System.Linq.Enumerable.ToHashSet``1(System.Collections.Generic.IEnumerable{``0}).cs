﻿using System.Collections.Generic;

static partial class PolyfillExtensions
{
    public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source)
        => source.ToHashSet(null);
}