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
    public partial class LocalFileInfo
    {
        #region Properties
        public int ParentTVItemID { get; set; }
        public string FileName { get; set; }
        public long Length { get; set; }
        #endregion Properties

        #region Constructors
        public LocalFileInfo()
        {

        }
        #endregion Constructors
    }
}
