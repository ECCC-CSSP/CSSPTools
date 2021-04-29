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
        public List<TelModel> TelModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllTels()
        {
            TelModelList = new List<TelModel>();
        }
        #endregion Constructors
    }
}
