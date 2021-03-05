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
    public partial class WebDrogueRun : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<DrogueRun> DrogueRunList { get; set; }
        public List<DrogueRunPosition> DrogueRunPositionList { get; set; }
        #endregion Properties

        #region Constructors
        public WebDrogueRun()
        {
            TVItemParentList = new List<WebBase>();
            DrogueRunList = new List<DrogueRun>();
            DrogueRunPositionList = new List<DrogueRunPosition>();
        }
        #endregion Constructors
    }
}
