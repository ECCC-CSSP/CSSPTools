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

namespace CSSPModels
{
    public partial class Address : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int AddressID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "2")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int AddressTVItemID { get; set; }
        [CSSPEnumType]
        public AddressTypeEnum AddressType { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "6")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int CountryTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "18")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int ProvinceTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "15")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int MunicipalityTVItemID { get; set; }
        [CSSPMaxLength(200)]
        [CSSPAllowNull]
        public string StreetName { get; set; }
        [CSSPMaxLength(50)]
        [CSSPAllowNull]
        public string StreetNumber { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        public StreetTypeEnum? StreetType { get; set; }
        [CSSPMaxLength(11)]
        [CSSPMinLength(6)]
        [CSSPAllowNull]
        public string PostalCode { get; set; }
        [CSSPMaxLength(200)]
        [CSSPMinLength(10)]
        [CSSPAllowNull]
        public string GoogleAddressText { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Address() : base()
        {
        }
        #endregion Constructors
    }

    
}
