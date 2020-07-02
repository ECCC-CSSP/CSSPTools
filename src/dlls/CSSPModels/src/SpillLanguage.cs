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
    public partial class SpillLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int SpillLanguageID { get; set; }
        [CSSPExist(ExistTypeName = "Spill", ExistPlurial = "s", ExistFieldID = "SpillID")]
        [CSSPForeignKey(TableName = "Spills", FieldName = "SpillID")]
        public int SpillID { get; set; }
        [CSSPEnumType]
        public LanguageEnum Language { get; set; }
        public string SpillComment { get; set; }
        [CSSPEnumType]
        public TranslationStatusEnum TranslationStatus { get; set; }
        #endregion Properties in DB

        #region Constructors
        public SpillLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
