﻿using System;

namespace kwd.CoreUtil.Strings
{
    /// <summary>
    /// String extensions to check for matching strings.
    /// </summary>
    public static class StringMatchExtensions
    {
        /// <summary>
        /// Case-ignorant string compare, also ignores lading and trailing white space.
        /// </summary>
        /// <remarks>Uses span to avoid memory allocation</remarks>
        /// <returns>True if the strings are the same, ignoring case.</returns>
        public static bool Same(this string lhs, string rhs)
            => lhs.AsSpan().Trim().Equals(rhs.AsSpan().Trim(), StringComparison.OrdinalIgnoreCase);
        
        /// <summary>
        /// Compare the words from 2 strings; where words are separated by white space (phrases).
        /// Words are compared case-ignorant (See <see cref="Same"/>).
        /// </summary>
        /// <returns></returns>
        public static bool SamePhrase(this string lhs, string rhs, Func<char, bool>? isDelimiter = null)
        {
            var lhsRest = lhs.AsSpan();
            var rhsRest = rhs.AsSpan();

            while (lhsRest.Length > 0 || rhsRest.Length > 0)
            {
                var lhsWord = lhsRest.NextWord(out lhsRest, isDelimiter);
                var rhsWord = rhsRest.NextWord(out rhsRest, isDelimiter);

                if (!lhsWord.Equals(rhsWord, StringComparison.OrdinalIgnoreCase))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Shorthand for <see cref="System.String.IsNullOrWhiteSpace"/>
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string lhs)
            => string.IsNullOrWhiteSpace(lhs);

        /// <summary>
        /// Shorthand for <see cref="System.String.IsNullOrEmpty"/>
        /// </summary>
        public static bool IsNullOrEmpty(this string lhs)
            => string.IsNullOrEmpty(lhs);
    }
}
