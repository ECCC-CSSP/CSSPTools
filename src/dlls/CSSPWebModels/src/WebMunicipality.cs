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
    public partial class WebMunicipality : WebBase
    {
        #region Properties
        public List<TVItem> TVItemInfrastructureList { get; set; }
        public List<TVItemLanguage> TVItemLanguageInfrastructureList { get; set; }
        public List<TVItemStat> TVItemStatInfrastructureList { get; set; }
        public List<MapInfo> TVItemMapInfoInfrastructureList { get; set; }
        public List<MapInfoPoint> TVItemMapInfoPointInfrastructureList { get; set; }
        public List<TVItem> TVItemMikeScenarioList { get; set; }
        public List<TVItemLanguage> TVItemLanguageMikeScenarioList { get; set; }
        public List<TVItemStat> TVItemStatMikeScenarioList { get; set; }
        public List<Infrastructure> InfrastructureList { get; set; }
        public List<InfrastructureLanguage> InfrastructureLanguageList { get; set; }
        public List<Address> InfrastructureCivicAddressList { get; set; }
        public List<BoxModel> BoxModelList { get; set; }
        public List<BoxModelLanguage> BoxModelLanguageList { get; set; }
        public List<BoxModelResult> BoxModelResultList { get; set; }
        public List<VPScenario> VPScenarioList { get; set; }
        public List<VPScenarioLanguage> VPScenarioLanguageList { get; set; }
        public List<VPAmbient> VPAmbientList { get; set; }
        public List<VPResult> VPResultList { get; set; }
        public List<TVItemLink> MunicipalityTVItemLinkList { get; set; }
        public List<Contact> MunicipalityContactList { get; set; }
        public List<Email> MunicipalityContactEmailList { get; set; }
        public List<Tel> MunicipalityContactTelList { get; set; }
        public List<Address> MunicipalityContactAddressList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMunicipality()
        {
            TVItemInfrastructureList = new List<TVItem>();
            TVItemLanguageInfrastructureList = new List<TVItemLanguage>();
            TVItemStatInfrastructureList = new List<TVItemStat>();
            TVItemMapInfoInfrastructureList = new List<MapInfo>();
            TVItemMapInfoPointInfrastructureList = new List<MapInfoPoint>();
            TVItemMikeScenarioList = new List<TVItem>();
            TVItemLanguageMikeScenarioList = new List<TVItemLanguage>();
            TVItemStatMikeScenarioList = new List<TVItemStat>();
            InfrastructureList = new List<Infrastructure>();
            InfrastructureLanguageList = new List<InfrastructureLanguage>();
            InfrastructureCivicAddressList = new List<Address>();
            BoxModelList = new List<BoxModel>();
            BoxModelLanguageList = new List<BoxModelLanguage>();
            BoxModelResultList = new List<BoxModelResult>();
            VPScenarioList = new List<VPScenario>();
            VPScenarioLanguageList = new List<VPScenarioLanguage>();
            VPAmbientList = new List<VPAmbient>();
            VPResultList = new List<VPResult>();
            MunicipalityTVItemLinkList = new List<TVItemLink>();
            MunicipalityContactList = new List<Contact>();
            MunicipalityContactEmailList = new List<Email>();
            MunicipalityContactTelList = new List<Tel>();
            MunicipalityContactAddressList = new List<Address>();
        }
        #endregion Constructors
    }
}
