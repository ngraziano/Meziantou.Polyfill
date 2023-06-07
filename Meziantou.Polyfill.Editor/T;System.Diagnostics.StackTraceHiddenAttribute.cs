// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Diagnostics
{
    /// <summary>
    /// Types and Methods attributed with StackTraceHidden will be omitted from the stack trace text shown in StackTrace.ToString()
    /// and Exception.StackTrace
    /// </summary>
    [global::System.AttributeUsage(
        global::System.AttributeTargets.Class |
        global::System.AttributeTargets.Method |
        global::System.AttributeTargets.Constructor |
        global::System.AttributeTargets.Struct,
        Inherited = false)]
    internal sealed class StackTraceHiddenAttribute : global::System.Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="global::System.Diagnostics.StackTraceHiddenAttribute"/> class.
        /// </summary>
        public StackTraceHiddenAttribute() { }
    }
}