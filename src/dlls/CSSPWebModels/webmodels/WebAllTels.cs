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
    public partial class WebAllTels
    {
        #region Properties
        public List<WebBase> TVItemAllTelList { get; set; }

        public List<Tel> TelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllTels()
        {
            TVItemAllTelList = new List<WebBase>();
            TelList = new List<Tel>();
        }
        #endregion Constructors
    }
}
