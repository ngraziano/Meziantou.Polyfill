// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>
    /// Indicates that certain members on a specified <see cref="global::System.Type"/> are accessed dynamically,
    /// for example through <see cref="global::System.Reflection"/>.
    /// </summary>
    /// <remarks>
    /// This allows tools to understand which members are being accessed during the execution
    /// of a program.
    ///
    /// This attribute is valid on members whose type is <see cref="global::System.Type"/> or <see cref="string"/>.
    ///
    /// When this attribute is applied to a location of type <see cref="string"/>, the assumption is
    /// that the string represents a fully qualified type name.
    ///
    /// When this attribute is applied to a class, interface, or struct, the members specified
    /// can be accessed dynamically on <see cref="global::System.Type"/> instances returned from calling
    /// <see cref="object.GetType"/> on instances of that class, interface, or struct.
    ///
    /// If the attribute is applied to a method it's treated as a special case and it implies
    /// the attribute should be applied to the "this" parameter of the method. As such the attribute
    /// should only be used on instance methods of types assignable to System.Type (or string, but no methods
    /// will use it there).
    /// </remarks>
    [global::System.AttributeUsage(
        global::System.AttributeTargets.Field |
        global::System.AttributeTargets.ReturnValue |
        global::System.AttributeTargets.GenericParameter |
        global::System.AttributeTargets.Parameter |
        global::System.AttributeTargets.Property |
        global::System.AttributeTargets.Method |
        global::System.AttributeTargets.Class |
        global::System.AttributeTargets.Interface |
        global::System.AttributeTargets.Struct,
        Inherited = false)]
    internal sealed class DynamicallyAccessedMembersAttribute : global::System.Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="global::System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute"/> class
        /// with the specified member types.
        /// </summary>
        /// <param name="memberTypes">The types of members dynamically accessed.</param>
        public DynamicallyAccessedMembersAttribute(global::System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes memberTypes)
        {
            MemberTypes = memberTypes;
        }

        /// <summary>
        /// Gets the <see cref="global::System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes"/> which specifies the type
        /// of members dynamically accessed.
        /// </summary>
        public global::System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes MemberTypes { get; }
    }
}