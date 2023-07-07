﻿using System;
using System.Collections.Concurrent;

static partial class PolyfillExtensions
{
    public static TValue GetOrAdd<TKey, TValue, TArg>(this ConcurrentDictionary<TKey, TValue> target, TKey key, Func<TKey, TArg, TValue> valueFactory, TArg factoryArgument)
        where TKey : notnull
    {
        return target.GetOrAdd(key, key => valueFactory(key, factoryArgument));
    }
}