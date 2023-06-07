// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.Versioning
{
    /// <summary>
    /// Records the operating system (and minimum version) that supports an API. Multiple attributes can be
    /// applied to indicate support on multiple operating systems.
    /// </summary>
    /// <remarks>
    /// Callers can apply a <see cref="global::System.Runtime.Versioning.SupportedOSPlatformAttribute " />
    /// or use guards to prevent calls to APIs on unsupported operating systems.
    ///
    /// A given platform should only be specified once.
    /// </remarks>
    [global::System.AttributeUsage(
        global::System.AttributeTargets.Assembly |
        global::System.AttributeTargets.Class |
        global::System.AttributeTargets.Constructor |
        global::System.AttributeTargets.Enum |
        global::System.AttributeTargets.Event |
        global::System.AttributeTargets.Field |
        global::System.AttributeTargets.Interface |
        global::System.AttributeTargets.Method |
        global::System.AttributeTargets.Module |
        global::System.AttributeTargets.Property |
        global::System.AttributeTargets.Struct,
        AllowMultiple = true, Inherited = false)]
    internal sealed class SupportedOSPlatformAttribute : Attribute // global::System.Runtime.Versioning.OSPlatformAttribute
    {
        public SupportedOSPlatformAttribute(string platformName)
            //: base(platformName)
        {
        }
    }
}