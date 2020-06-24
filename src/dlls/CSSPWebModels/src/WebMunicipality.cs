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
    public partial class WebMunicipality
    {
        #region Properties
        public TVItem TVItemMunicipality { get; set; }
        public List<TVItem> TVItemInfrastructureList { get; set; }
        public List<TVItemLanguage> TVItemLanguageInfrastructureList { get; set; }
        public List<Infrastructure> InfrastructureList { get; set; }
        public List<InfrastructureLanguage> InfrastructureLanguageList { get; set; }
        public List<BoxModel> BoxModelList { get; set; }
        public List<BoxModelLanguage> BoxModelLanguageList { get; set; }
        public List<BoxModelResult> BoxModelResultList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMunicipality()
        {
            TVItemMunicipality = new TVItem();
            InfrastructureList = new List<Infrastructure>();
            InfrastructureLanguageList = new List<InfrastructureLanguage>();
            BoxModelList = new List<BoxModel>();
            BoxModelLanguageList = new List<BoxModelLanguage>();
            BoxModelResultList = new List<BoxModelResult>();
        }
        #endregion Constructors
    }
}
