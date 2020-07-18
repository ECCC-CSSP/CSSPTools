/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebMWQMSample
    {
        #region Properties
        public List<MWQMSample> MWQMSampleList { get; set; }
        public List<MWQMSampleLanguage> MWQMSampleLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMWQMSample()
        {
            MWQMSampleList = new List<MWQMSample>();
            MWQMSampleLanguageList = new List<MWQMSampleLanguage>();
        }
        #endregion Constructors
    }
}
