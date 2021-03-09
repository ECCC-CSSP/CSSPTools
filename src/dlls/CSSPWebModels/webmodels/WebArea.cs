/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebArea : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<WebBase> TVItemSectorList { get; set; }
        public List<WebBase> TVItemFileList { get; set; }
        #endregion Properties

        #region Constructors
        public WebArea()
        {
            TVItemParentList = new List<WebBase>();
            TVItemSectorList = new List<WebBase>();
            TVItemFileList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
