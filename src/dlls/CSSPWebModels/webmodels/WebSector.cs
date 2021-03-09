/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebSector : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<WebBase> TVItemSubsectorList { get; set; }
        public List<WebBase> TVItemFileList { get; set; }      
        #endregion Properties

        #region Constructors
        public WebSector()
        {
            TVItemParentList = new List<WebBase>();
            TVItemSubsectorList = new List<WebBase>();
            TVItemFileList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
