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
    public partial class VPScenarioLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int VPScenarioLanguageID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID")]
        [CSSPForeignKey(TableName = "VPScenarios", FieldName = "VPScenarioID")]
        public int VPScenarioID { get; set; }
        [CSSPEnumType]
        public LanguageEnum Language { get; set; }
        [CSSPMaxLength(100)]
        public string VPScenarioName { get; set; }
        [CSSPEnumType]
        public TranslationStatusEnum TranslationStatus { get; set; }
        #endregion Properties in DB

        #region Constructors
        public VPScenarioLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
