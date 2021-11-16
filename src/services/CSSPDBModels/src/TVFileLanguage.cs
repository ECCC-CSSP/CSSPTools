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
    public partial class TVFileLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int TVFileLanguageID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "TVFile", ExistPlurial = "s", ExistFieldID = "TVFileID")]
        [CSSPForeignKey(TableName = "TVFiles", FieldName = "TVFileID")]
        public int TVFileID { get; set; }
        [CSSPEnumType]
        public LanguageEnum Language { get; set; }
        [CSSPAllowNull]
        public string FileDescription { get; set; }
        [CSSPEnumType]
        public TranslationStatusEnum TranslationStatus { get; set; }
        #endregion Properties in DB

        #region Constructors
        public TVFileLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
