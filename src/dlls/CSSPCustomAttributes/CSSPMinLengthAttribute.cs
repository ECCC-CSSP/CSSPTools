﻿/*
 * Manually edited
 * 
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace CSSPCustomAttributes
{
    /// <summary>
    /// > [!NOTE]
    /// > Custom validation attribute used to replace MinLengthAttribute
    /// > <para>Used when generating some codes</para>
    /// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
    /// </summary>
    /// <example>
    ///     <code>
    ///         [CSSPMinLength(6)]
    ///         public string FirstName { get; set; }
    ///     </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CSSPMinLengthAttribute : MinLengthAttribute
    {
        /// <summary>
        /// > [!NOTE]
        /// > Constructor
        /// </summary>
        public CSSPMinLengthAttribute(int length) : base(length)
        {

        }
        /// <summary>
        /// > [!NOTE]
        /// > Not used. Using own validation system.
        /// </summary>
        /// <param name="value">Not used</param>
        /// <returns>Not used</returns>
        public override bool IsValid(object value)
        {
            return true;
        }
    }
}
