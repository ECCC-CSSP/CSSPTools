/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class OtherFilesToUpload
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(1, -1)]
        public int MikeScenarioID { get; set; }
        public List<TVFile> TVFileList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public OtherFilesToUpload() : base()
        {
            TVFileList = new List<TVFile>();
        }
        #endregion Constructors
    }
}
