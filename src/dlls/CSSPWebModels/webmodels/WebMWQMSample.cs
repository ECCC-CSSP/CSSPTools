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
    public partial class WebMWQMSample : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<MWQMSample> MWQMSampleList { get; set; }
        public List<MWQMSampleLanguage> MWQMSampleLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMWQMSample()
        {
            TVItemParentList = new List<WebBase>();
            MWQMSampleList = new List<MWQMSample>();
            MWQMSampleLanguageList = new List<MWQMSampleLanguage>();
        }
        #endregion Constructors
    }
}
