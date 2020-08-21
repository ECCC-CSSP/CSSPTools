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
    public partial class CSSPFile
    {
        #region Properties in DB
        [Key]
        public int CSSPFileID { get; set; }
        [CSSPMaxLength(100)]
        public string AzureStorage { get; set; }
        [CSSPMaxLength(200)]
        public string AzureFileName { get; set; }
        [CSSPMaxLength(50)]
        public string AzureETag { get; set; }
        [CSSPAfter(Year = 1980)]
        public DateTime AzureCreationTimeUTC { get; set; }
        #endregion Properties in DB

        #region Constructors
        public CSSPFile() : base()
        {
        }
        #endregion Constructors
    }
}
