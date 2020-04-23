using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GenerateCodeBase.Models
{
    public class CSSPProp
    {
        public CSSPProp()
        {
            CSSPError = "";
            PropName = "";
            PropType = "";
            IsNullable = false;
            IsKey = false;
            Min = null;
            Max = null;
            OtherField = "";
            Year = null;
            Compare = "";
            ExistTypeName = "";
            ExistPlurial = "";
            ExistFieldID = "";
            dataType = DataType.Custom;
            IsVirtual = false;
            HasNotMappedAttribute = false;
            HasCSSPAfterAttribute = false;
            HasCSSPAllowNullAttribute = false;
            HasCSSPBiggerAttribute = false;
            HasCSSPEnumTypeAttribute = false;
            HasCSSPExistAttribute = false;
            HasCSSPFillAttribute = false;
            HasStringLengthAttribute = false;
            HasRangeAttribute = false;
            HasCompareAttribute = false;
            HasDataTypeAttribute = false;
            AllowableTVTypeList = new List<TVTypeEnum>();
            IsCollection = false;
            IsList = false;
            IsIQueryable = false;
            FillTypeName = "";
            FillPlurial = "";
            FillFieldID = "";
            FillEqualField = "";
            FillReturnField = "";
            HasCSSPEnumTypeTextAttribute = false;
            EnumTypeName = "";
            EnumType = "";
            FillNeedLanguage = false;
            FillIsList = false;
            HasCSSPDescriptionENAttribute = false;
            HasCSSPDescriptionFRAttribute = false;
            HasCSSPDisplayENAttribute = false;
            HasCSSPDisplayFRAttribute = false;
            DescriptionEN = "";
            DescriptionFR = "";
            DisplayEN = "";
            DisplayFR = "";
        }
        public string CSSPError { get; set; }
        public string PropName { get; set; }
        public string PropType { get; set; }
        public bool IsNullable { get; set; }
        public bool IsKey { get; set; }
        public double? Min { get; set; }
        public double? Max { get; set; }
        public string OtherField { get; set; }
        public int? Year { get; set; }
        public string Compare { get; set; }
        public string ExistTypeName { get; set; }
        public string ExistPlurial { get; set; }
        public string ExistFieldID { get; set; }
        public DataType dataType { get; set; }
        public bool IsVirtual { get; set; }
        public bool HasNotMappedAttribute { get; set; }
        public bool HasCSSPAfterAttribute { get; set; }
        public bool HasCSSPAllowNullAttribute { get; set; }
        public bool HasCSSPBiggerAttribute { get; set; }
        public bool HasCSSPEnumTypeAttribute { get; set; }
        public bool HasCSSPExistAttribute { get; set; }
        public bool HasCSSPFillAttribute { get; set; }
        public bool HasStringLengthAttribute { get; set; }
        public bool HasRangeAttribute { get; set; }
        public bool HasCompareAttribute { get; set; }
        public bool HasDataTypeAttribute { get; set; }
        public List<TVTypeEnum> AllowableTVTypeList { get; set; }
        public bool IsCollection { get; set; }
        public bool IsList { get; set; }
        public bool IsIQueryable { get; set; }
        public string FillTypeName { get; set; }
        public string FillPlurial { get; set; }
        public string FillFieldID { get; set; }
        public string FillEqualField { get; set; }
        public string FillReturnField { get; set; }
        public bool HasCSSPEnumTypeTextAttribute { get; set; }
        public string EnumTypeName { get; set; }
        public string EnumType { get; set; }
        public bool FillNeedLanguage { get; set; }
        public bool FillIsList { get; set; }
        public bool HasCSSPDescriptionENAttribute { get; set; }
        public bool HasCSSPDescriptionFRAttribute { get; set; }
        public bool HasCSSPDisplayENAttribute { get; set; }
        public bool HasCSSPDisplayFRAttribute { get; set; }
        public string DescriptionEN { get; set; }
        public string DescriptionFR { get; set; }
        public string DisplayEN { get; set; }
        public string DisplayFR { get; set; }
    }
}
