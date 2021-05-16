/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class TVFileID_Text_Sort
    {
        #region Properties
        public int TVFileID { get; set; }
        public string TextToSort { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileID_Text_Sort()
        {
        }
        #endregion Constructors
    }
}
