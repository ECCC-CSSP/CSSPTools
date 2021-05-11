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
    public partial class WebMunicipality
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<TVItemModel> TVItemModelInfrastructureList { get; set; }
        public List<TVItemModel> TVItemModelMikeScenarioList { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }
        public List<ContactModel> MunicipalityContactModelList { get; set; }
        public List<TVItemLink> MunicipalityTVItemLinkList { get; set; }
        public List<InfrastructureModel> InfrastructureModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMunicipality()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            TVItemModelInfrastructureList = new List<TVItemModel>();
            TVItemModelMikeScenarioList = new List<TVItemModel>();
            TVFileModelList = new List<TVFileModel>();
            MunicipalityContactModelList = new List<ContactModel>();
            MunicipalityTVItemLinkList = new List<TVItemLink>();
            InfrastructureModelList = new List<InfrastructureModel>();
        }
        #endregion Constructors
    }
}
