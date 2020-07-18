/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebDrogueRun
    {
        #region Properties
        public List<DrogueRun> DrogueRunList { get; set; }
        public List<DrogueRunPosition> DrogueRunPositionList { get; set; }
        #endregion Properties

        #region Constructors
        public WebDrogueRun()
        {
            DrogueRunList = new List<DrogueRun>();
            DrogueRunPositionList = new List<DrogueRunPosition>();
        }
        #endregion Constructors
    }
}
