﻿using System;
using System.Text;

static partial class PolyfillExtensions
{
    public static StringBuilder Append(this StringBuilder target, ReadOnlySpan<char> value)
    {
        if (value.IsEmpty)
            return target;

        return target.Append(value.ToArray());
    }
}