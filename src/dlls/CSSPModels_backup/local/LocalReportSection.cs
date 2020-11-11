/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels.local;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPModels
{
    public partial class LocalReportSection : LocalBase
    {
        #region Properties in DB
        public ReportSection ReportSection { get; set; }
        #endregion Properties in DB

        #region Constructors
        public LocalReportSection() : base()
        {
        }
        #endregion Constructors
    }


}
