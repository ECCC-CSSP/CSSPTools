/*
 * Manually edited
 * 
 */
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPModels
{
    [NotMapped]
    public partial class WhereInfo : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "Property name")]
        [CSSPDisplayFR(DisplayFR = "Nom de la propriété")]
        [CSSPDescriptionEN(DescriptionEN = @"Property name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom de la propriété")]
        public string PropertyName { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Property type")]
        [CSSPDisplayFR(DisplayFR = "Type de propriété")]
        [CSSPDescriptionEN(DescriptionEN = @"Property type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de propriété")]
        public PropertyTypeEnum PropertyType { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Where operator (Ex: Equal, LessThan, GreaterThan, Contains, StartsWith, EndsWith)")]
        [CSSPDisplayFR(DisplayFR = "Opérateur de filtre (Ex: Equal, LessThan, GreaterThan, Contains, StartsWith, EndsWith)")]
        [CSSPDescriptionEN(DescriptionEN = @"Where operator (Ex: Equal, LessThan, GreaterThan, Contains, StartsWith, EndsWith)")]
        [CSSPDescriptionFR(DescriptionFR = @"Opérateur de filtre (Ex: Equal, LessThan, GreaterThan, Contains, StartsWith, EndsWith)")]
        public WhereOperatorEnum WhereOperator { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "Value")]
        [CSSPDisplayFR(DisplayFR = "Valeur")]
        [CSSPDescriptionEN(DescriptionEN = @"Value")]
        [CSSPDescriptionFR(DescriptionFR = @"Valeur")]
        public string Value { get; set; }
        [Range(-1, -1)]
        [CSSPDisplayEN(DisplayEN = "Value (int)")]
        [CSSPDisplayFR(DisplayFR = "Valeur (int)")]
        [CSSPDescriptionEN(DescriptionEN = @"Value (int)")]
        [CSSPDescriptionFR(DescriptionFR = @"Valeur (int)")]
        public int ValueInt { get; set; }
        [Range(-1.0D, -1.0D)]
        [CSSPDisplayEN(DisplayEN = "Value (double)")]
        [CSSPDisplayFR(DisplayFR = "Valeur (double)")]
        [CSSPDescriptionEN(DescriptionEN = @"Value (double)")]
        [CSSPDescriptionFR(DescriptionFR = @"Valeur (double)")]
        public double ValueDouble { get; set; }
        [CSSPDisplayEN(DisplayEN = "Value (bool)")]
        [CSSPDisplayFR(DisplayFR = "Valeur (bool)")]
        [CSSPDescriptionEN(DescriptionEN = @"Value (bool)")]
        [CSSPDescriptionFR(DescriptionFR = @"Valeur (bool)")]
        public bool ValueBool { get; set; }
        [CSSPAfter(Year = 1900)]
        [CSSPDisplayEN(DisplayEN = "Value (DateTime)")]
        [CSSPDisplayFR(DisplayFR = "Valeur (DateTime)")]
        [CSSPDescriptionEN(DescriptionEN = @"Value (DateTime)")]
        [CSSPDescriptionFR(DescriptionFR = @"Valeur (DateTime)")]
        public DateTime ValueDateTime { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "Value (Enum)")]
        [CSSPDisplayFR(DisplayFR = "Valeur (Enum)")]
        [CSSPDescriptionEN(DescriptionEN = @"Value (Enum)")]
        [CSSPDescriptionFR(DescriptionFR = @"Valeur (Enum)")]
        public string ValueEnumText { get; set; }
        [CSSPDisplayEN(DisplayEN = "Type of Enum")]
        [CSSPDisplayFR(DisplayFR = "Type d'Enum")]
        [CSSPDescriptionEN(DescriptionEN = @"Type of Enum")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'Enum")]
        public Type EnumType { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public WhereInfo() : base()
        {
        }
        #endregion Constructors
    }
}
