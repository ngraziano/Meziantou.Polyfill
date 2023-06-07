// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.Versioning
{
    /// <summary>
    /// Annotates a custom guard field, property or method with a supported platform name and optional version.
    /// Multiple attributes can be applied to indicate guard for multiple supported platforms.
    /// </summary>
    /// <remarks>
    /// Callers can apply a <see cref="global::System.Runtime.Versioning.SupportedOSPlatformGuardAttribute " /> to a field, property or method
    /// and use that field, property or method in a conditional or assert statements in order to safely call platform specific APIs.
    ///
    /// The type of the field or property should be boolean, the method return type should be boolean in order to be used as platform guard.
    /// </remarks>
    [global::System.AttributeUsage(
        global::System.AttributeTargets.Field |
        global::System.AttributeTargets.Method |
        global::System.AttributeTargets.Property,
        AllowMultiple = true, Inherited = false)]
    internal sealed class SupportedOSPlatformGuardAttribute : Attribute // global::System.Runtime.Versioning.OSPlatformAttribute
    {
        public SupportedOSPlatformGuardAttribute(string platformName)
            //: base(platformName)
        {
        }
    }
}