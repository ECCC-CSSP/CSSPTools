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
    public partial class WebSample
    {
        #region Properties
        public List<MWQMSample> MWQMSampleList { get; set; }
        public List<MWQMSampleLanguage> MWQMSampleLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public WebSample()
        {
            MWQMSampleList = new List<MWQMSample>();
            MWQMSampleLanguageList = new List<MWQMSampleLanguage>();
        }
        #endregion Constructors
    }
}
