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
    public partial class ReportType : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int ReportTypeID { get; set; }
        [CSSPEnumType]
        public TVTypeEnum TVType { get; set; }
        [CSSPEnumType]
        public FileTypeEnum FileType { get; set; }
        [CSSPMaxLength(100)]
        public string UniqueCode { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        public LanguageEnum? Language { get; set; }
        [CSSPMaxLength(100)]
        [CSSPAllowNull]
        public string Name { get; set; }
        [CSSPMaxLength(1000)]
        [CSSPAllowNull]
        public string Description { get; set; }
        [CSSPMaxLength(100)]
        [CSSPAllowNull]
        public string StartOfFileName { get; set; }
        #endregion Properties in DB

        #region Constructors
        public ReportType() : base()
        {
        }
        #endregion Constructors
    }
}
