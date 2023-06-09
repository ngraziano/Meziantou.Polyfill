﻿using System.Text;

static partial class PolyfillExtensions
{
    public static string ReplaceLineEndings(this string target, string replacementText)
    {
        var sb = new StringBuilder();

        var previousIndex = 0;
        while (target.IndexOfAny(Constants.NewLineChars, previousIndex) is var index and not -1)
        {
            sb.Append(target, previousIndex, index - previousIndex);
            sb.Append(replacementText);

            previousIndex = index + 1;
            if (target[index] == '\r' && index + 1 < target.Length && target[index + 1] == '\n')
            {
                previousIndex++;
            }
        }

        sb.Append(target, previousIndex, target.Length - previousIndex);
        return sb.ToString();
    }
}

file static class Constants
{
    public static readonly char[] NewLineChars = new char[] { '\n', '\r', '\f', '\u0085', '\u2028', '\u2029' };
}