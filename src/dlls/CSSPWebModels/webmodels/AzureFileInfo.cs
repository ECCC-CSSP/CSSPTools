/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPDBModels;
using CSSPEnums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class AzureFileInfo
    {
        #region Properties
        public string FileName { get; set; }
        public long Length { get; set; }
        #endregion Properties

        #region Constructors
        public AzureFileInfo()
        {

        }
        #endregion Constructors
    }
}
