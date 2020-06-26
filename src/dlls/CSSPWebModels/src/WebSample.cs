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
