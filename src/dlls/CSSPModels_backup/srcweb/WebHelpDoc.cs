/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPModels
{
    [NotMapped]
    public partial class WebHelpDoc
    {
        #region Properties
        public List<HelpDoc> HelpDocList { get; set; }
        #endregion Properties

        #region Constructors
        public WebHelpDoc()
        {
            HelpDocList = new List<HelpDoc>();
        }
        #endregion Constructors
    }
}
