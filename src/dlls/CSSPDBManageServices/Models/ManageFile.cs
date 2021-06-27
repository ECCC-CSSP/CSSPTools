/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ManageServices
{
    public partial class ManageFile
    {
        #region Properties in DB
        [Key]
        public int ManageFileID { get; set; }
        [CSSPMaxLength(100)]
        public string AzureStorage { get; set; }
        [CSSPMaxLength(200)]
        public string AzureFileName { get; set; }
        [CSSPMaxLength(50)]
        public string AzureETag { get; set; }
        [CSSPAfter(Year = 1980)]
        public DateTime AzureCreationTimeUTC { get; set; }
        public bool LoadedOnce { get; set; }
        #endregion Properties in DB

        #region Constructors
        public ManageFile() : base()
        {
        }
        #endregion Constructors
    }
}
