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
    public partial class AppTaskLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int AppTaskLanguageID { get; set; }
        [CSSPExist(ExistTypeName = "AppTask", ExistPlurial = "s", ExistFieldID = "AppTaskID")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int AppTaskID { get; set; }
        [CSSPEnumType]
        public LanguageEnum Language { get; set; }
        [CSSPMaxLength(250)]
        [CSSPAllowNull]
        public string StatusText { get; set; }
        [CSSPMaxLength(250)]
        [CSSPAllowNull]
        public string ErrorText { get; set; }
        [CSSPEnumType]
        public TranslationStatusEnum TranslationStatus { get; set; }
        #endregion Properties in DB

        #region Constructors
        public AppTaskLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
