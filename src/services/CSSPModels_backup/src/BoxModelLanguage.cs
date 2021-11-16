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
    public partial class BoxModelLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int BoxModelLanguageID { get; set; }
        [CSSPExist(ExistTypeName = "BoxModel", ExistPlurial = "s", ExistFieldID = "BoxModelID")]
        [CSSPForeignKey(TableName = "BoxModels", FieldName = "BoxModelID")]
        public int BoxModelID { get; set; }
        [CSSPEnumType]
        public LanguageEnum Language { get; set; }
        [CSSPMaxLength(250)]
        public string ScenarioName { get; set; }
        [CSSPEnumType]
        public TranslationStatusEnum TranslationStatus { get; set; }
        #endregion Properties in DB

        #region Constructors
        public BoxModelLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
