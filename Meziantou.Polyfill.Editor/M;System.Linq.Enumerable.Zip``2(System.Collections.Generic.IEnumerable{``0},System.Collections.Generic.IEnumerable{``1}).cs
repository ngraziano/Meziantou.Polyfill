﻿using System.Collections.Generic;
using System.Linq;

static partial class PolyfillExtensions
{
    public static IEnumerable<(TFirst left, TSecond right)> Zip<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
    {
        return first.Zip(second, (x, y) => (x, y));
    }
}