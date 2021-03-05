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
    public partial class WebAllHelpDocs
    {
        #region Properties
        public List<HelpDoc> HelpDocList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllHelpDocs()
        {
            HelpDocList = new List<HelpDoc>();
        }
        #endregion Constructors
    }
}
