﻿/*
 * Manually edited
 * 
 */
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPHelperModels
{
    /// <summary>
    /// > [!NOTE]
    /// > Custom validation attribute used to replace CompareAttribute
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
    public class CSSPCompareAttribute : CompareAttribute
    {
        /// <summary>
        /// > [!NOTE]
        /// > Constructor
        /// </summary>
        public CSSPCompareAttribute(string otherProperty) : base(otherProperty)
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
