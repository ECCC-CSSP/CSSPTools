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
    public partial class InfrastructureLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int InfrastructureLanguageID { get; set; }
        [CSSPExist(ExistTypeName = "Infrastructure", ExistPlurial = "s", ExistFieldID = "InfrastructureID")]
        [CSSPForeignKey(TableName = "Infrastructures", FieldName = "InfrastructureID")]
        public int InfrastructureID { get; set; }
        [CSSPEnumType]
        public LanguageEnum Language { get; set; }
        public string Comment { get; set; }
        [CSSPEnumType]
        public TranslationStatusEnum TranslationStatus { get; set; }
        #endregion Properties in DB

        #region Constructors
        public InfrastructureLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
