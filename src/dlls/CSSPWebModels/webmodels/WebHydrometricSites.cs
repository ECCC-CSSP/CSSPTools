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
    public partial class WebHydrometricSites
    {
        #region Properties
        public TVItemStatMapModel TVItemStatMapModel { get; set; }
        public List<TVItemStatModel> TVItemStatModelParentList { get; set; }
        public List<HydrometricSiteModel> HydrometricSiteModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebHydrometricSites()
        {
            TVItemStatMapModel = new TVItemStatMapModel();
            TVItemStatModelParentList = new List<TVItemStatModel>();
            HydrometricSiteModelList = new List<HydrometricSiteModel>();
        }
        #endregion Constructors
    }
}
