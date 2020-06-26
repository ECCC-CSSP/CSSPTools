/*
 * Manually edited
 * 
 */
using CSSPModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPWebModels
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
