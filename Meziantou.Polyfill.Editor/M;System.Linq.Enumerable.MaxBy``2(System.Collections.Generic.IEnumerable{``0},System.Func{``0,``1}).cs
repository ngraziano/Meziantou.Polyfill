﻿using System;
using System.Collections.Generic;

static partial class PolyfillExtensions
{
    public static TSource? MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
        return source.MaxBy(keySelector, comparer: null);
    }
}