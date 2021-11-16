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
    public partial class MWQMSubsectorModel
    {
        #region Properties
        public MWQMSubsector MWQMSubsector { get; set; }
        public List<MWQMSubsectorLanguage> MWQMSubsectorLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorModel()
        {
            MWQMSubsector = new MWQMSubsector();
            MWQMSubsectorLanguageList = new List<MWQMSubsectorLanguage>();
        }
        #endregion Constructors
    }
}
