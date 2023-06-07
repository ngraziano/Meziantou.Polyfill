// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.Versioning
{
    [global::System.AttributeUsage(
        global::System.AttributeTargets.Assembly |
        global::System.AttributeTargets.Module |
        global::System.AttributeTargets.Class |
        global::System.AttributeTargets.Interface |
        global::System.AttributeTargets.Delegate |
        global::System.AttributeTargets.Struct |
        global::System.AttributeTargets.Enum |
        global::System.AttributeTargets.Constructor |
        global::System.AttributeTargets.Method |
        global::System.AttributeTargets.Property |
        global::System.AttributeTargets.Field |
        AttributeTargets.Event, Inherited = false)]
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal sealed class RequiresPreviewFeaturesAttribute : global::System.Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="global::System.Runtime.Versioning.RequiresPreviewFeaturesAttribute"/> class.
        /// </summary>
        public RequiresPreviewFeaturesAttribute() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="global::System.Runtime.Versioning.RequiresPreviewFeaturesAttribute"/> class with the specified message.
        /// </summary>
        /// <param name="message">An optional message associated with this attribute instance.</param>
        public RequiresPreviewFeaturesAttribute(string? message)
        {
            Message = message;
        }

        /// <summary>
        /// Returns the optional message associated with this attribute instance.
        /// </summary>
        public string? Message { get; }

        /// <summary>
        /// Returns the optional URL associated with this attribute instance.
        /// </summary>
        public string? Url { get; set; }
    }
}