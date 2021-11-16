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
    public partial class BoxModelModel
    {
        #region Properties
        public BoxModel BoxModel { get; set; }
        public List<BoxModelLanguage> BoxModelLanguageList { get; set; }
        public List<BoxModelResult> BoxModelResultList { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelModel()
        {
            BoxModel = new BoxModel();
            BoxModelLanguageList = new List<BoxModelLanguage>();
            BoxModelResultList = new List<BoxModelResult>();
        }
        #endregion Constructors

    }
}
