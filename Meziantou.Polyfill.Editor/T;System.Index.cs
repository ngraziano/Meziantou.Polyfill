// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System
{
    /// <summary>Represent a type can be used to index a collection either from the start or the end.</summary>
    /// <remarks>
    /// Index is used by the C# compiler to support the new index syntax
    /// <code>
    /// int[] someArray = new int[5] { 1, 2, 3, 4, 5 } ;
    /// int lastElement = someArray[^1]; // lastElement = 5
    /// </code>
    /// </remarks>
    internal readonly struct Index : global::System.IEquatable<global::System.Index>
    {
        private readonly int _value;

        /// <summary>Construct an Index using a value and indicating if the index is from the start or from the end.</summary>
        /// <param name="value">The index value. it has to be zero or positive number.</param>
        /// <param name="fromEnd">Indicating if the index is from the start or from the end.</param>
        /// <remarks>
        /// If the Index constructed from the end, index value 1 means pointing at the last element and index value 0 means pointing at beyond last element.
        /// </remarks>
        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public Index(int value, bool fromEnd = false)
        {
            if (value < 0)
            {
                global::System.Index.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException();
            }

            if (fromEnd)
                _value = ~value;
            else
                _value = value;
        }

        // The following private constructors mainly created for perf reason to avoid the checks
        private Index(int value)
        {
            _value = value;
        }

        /// <summary>Create an Index pointing at first element.</summary>
        public static global::System.Index Start => new global::System.Index(0);

        /// <summary>Create an Index pointing at beyond last element.</summary>
        public static global::System.Index End => new global::System.Index(~0);

        /// <summary>Create an Index from the start at the position indicated by the value.</summary>
        /// <param name="value">The index value from the start.</param>
        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static global::System.Index FromStart(int value)
        {
            if (value < 0)
            {
                global::System.Index.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException();
            }

            return new global::System.Index(value);
        }

        /// <summary>Create an Index from the end at the position indicated by the value.</summary>
        /// <param name="value">The index value from the end.</param>
        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static global::System.Index FromEnd(int value)
        {
            if (value < 0)
            {
                global::System.Index.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException();
            }

            return new global::System.Index(~value);
        }

        /// <summary>Returns the index value.</summary>
        public int Value
        {
            get
            {
                if (_value < 0)
                    return ~_value;
                else
                    return _value;
            }
        }

        /// <summary>Indicates whether the index is from the start or the end.</summary>
        public bool IsFromEnd => _value < 0;

        /// <summary>Calculate the offset from the start using the giving collection length.</summary>
        /// <param name="length">The length of the collection that the Index will be used with. length has to be a positive value</param>
        /// <remarks>
        /// For performance reason, we don't validate the input length parameter and the returned offset value against negative values.
        /// we don't validate either the returned offset is greater than the input length.
        /// It is expected Index will be used with collections which always have non negative length/count. If the returned offset is negative and
        /// then used to index a collection will get out of range exception which will be same affect as the validation.
        /// </remarks>
        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public int GetOffset(int length)
        {
            int offset = _value;
            if (IsFromEnd)
            {
                // offset = length - (~value)
                // offset = length + (~(~value) + 1)
                // offset = length + value + 1

                offset += length + 1;
            }
            return offset;
        }

        /// <summary>Indicates whether the current Index object is equal to another object of the same type.</summary>
        /// <param name="value">An object to compare with this object</param>
        public override bool Equals([global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] object? value) => value is global::System.Index && _value == ((global::System.Index)value)._value;

        /// <summary>Indicates whether the current Index object is equal to another Index object.</summary>
        /// <param name="other">An object to compare with this object</param>
        public bool Equals(global::System.Index other) => _value == other._value;

        /// <summary>Returns the hash code for this instance.</summary>
        public override int GetHashCode() => _value;

        /// <summary>Converts integer number to an Index.</summary>
        public static implicit operator global::System.Index(int value) => FromStart(value);

        /// <summary>Converts the value of the current Index object to its equivalent string representation.</summary>
        public override string ToString()
        {
            if (IsFromEnd)
                return ToStringFromEnd();

            return ((uint)Value).ToString();
        }

        private string ToStringFromEnd()
        {
            return '^' + Value.ToString();
        }

        private static class ThrowHelper
        {
            [global::System.Diagnostics.CodeAnalysis.DoesNotReturn]
            public static void ThrowValueArgumentOutOfRange_NeedNonNegNumException()
            {
                throw new global::System.ArgumentOutOfRangeException("value", "Non-negative number required.");
            }
        }
    }
}