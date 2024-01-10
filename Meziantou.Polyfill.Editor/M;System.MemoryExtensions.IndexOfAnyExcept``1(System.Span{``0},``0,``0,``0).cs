﻿using System;

static partial class PolyfillExtensions
{
    public static int IndexOfAnyExcept<T>(this Span<T> span, T value0, T value1, T value2) where T : IEquatable<T>?
    {
        return IndexOfAnyExcept((ReadOnlySpan<T>)span, value0, value1, value2);
    }
}
