﻿static partial class PolyfillExtensions
{
    public static int IndexOf(this string target, char value, System.StringComparison comparisonType)
    {
        return target.IndexOf(value.ToString(), comparisonType);
    }
}