/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPDBModels
{
    public partial class Email : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int EmailID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "7")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int EmailTVItemID { get; set; }
        [CSSPMaxLength(255)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [CSSPEnumType]
        public EmailTypeEnum EmailType { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Email() : base()
        {
        }
        #endregion Constructors
    }
}
