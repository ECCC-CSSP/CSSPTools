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
    public partial class MWQMSampleModel
    {
        #region Properties
        public MWQMSample MWQMSample { get; set; }
        public List<MWQMSampleLanguage> MWQMSampleLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleModel()
        {
            MWQMSample = new MWQMSample();
            MWQMSampleLanguageList = new List<MWQMSampleLanguage>();
        }
        #endregion Constructors
    }
}
