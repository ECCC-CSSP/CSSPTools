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
    public partial class MWQMSampleLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int MWQMSampleLanguageID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "MWQMSample", ExistPlurial = "s", ExistFieldID = "MWQMSampleID")]
        [CSSPForeignKey(TableName = "MWQMSamples", FieldName = "MWQMSampleID")]
        public int MWQMSampleID { get; set; }
        [CSSPEnumType]
        public LanguageEnum Language { get; set; }
        public string MWQMSampleNote { get; set; }
        [CSSPEnumType]
        public TranslationStatusEnum TranslationStatus { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MWQMSampleLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
