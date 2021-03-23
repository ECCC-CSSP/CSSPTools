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
    public partial class MWQMRunLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int MWQMRunLanguageID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "MWQMRun", ExistPlurial = "s", ExistFieldID = "MWQMRunID")]
        [CSSPForeignKey(TableName = "MWQMRuns", FieldName = "MWQMRunID")]
        public int MWQMRunID { get; set; }
        [CSSPEnumType]
        public LanguageEnum Language { get; set; }
        public string RunComment { get; set; }
        [CSSPEnumType]
        public TranslationStatusEnum TranslationStatusRunComment { get; set; }
        public string RunWeatherComment { get; set; }
        [CSSPEnumType]
        public TranslationStatusEnum TranslationStatusRunWeatherComment { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MWQMRunLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
