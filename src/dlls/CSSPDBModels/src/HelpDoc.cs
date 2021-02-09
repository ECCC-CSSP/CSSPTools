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

namespace CSSPDBModels
{
    public partial class HelpDoc : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int HelpDocID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPMaxLength(100)]
        public string DocKey { get; set; }
        [CSSPEnumType]
        public LanguageEnum Language { get; set; }
        [CSSPMaxLength(100000)]
        public string DocHTMLText { get; set; }
        #endregion Properties in DB

        #region Constructors
        public HelpDoc() : base()
        {
        }
        #endregion Constructors
    }
}
