﻿/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebProvince : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<WebBase> TVItemAreaList { get; set; }
        public List<SamplingPlan> SamplingPlanList { get; set; }
        #endregion Properties

        #region Constructors
        public WebProvince()
        {
            TVItemParentList = new List<WebBase>();
            TVItemAreaList = new List<WebBase>();
            SamplingPlanList = new List<SamplingPlan>();
        }
        #endregion Constructors
    }
}