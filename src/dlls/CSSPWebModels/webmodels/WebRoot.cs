/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebRoot : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        //public List<WebBase> TVItemAddressList { get; set; }
        //public List<WebBase> TVItemContactList { get; set; }
        //public List<WebBase> TVItemEmailList { get; set; }
        //public List<WebBase> TVItemTelList { get; set; }
        public List<WebBase> TVItemCountryList { get; set; }
        #endregion Properties

        #region Constructors
        public WebRoot() : base()
        {
            TVItemParentList = new List<WebBase>();
            //TVItemAddressList = new List<WebBase>();
            //TVItemContactList = new List<WebBase>();
            //TVItemEmailList = new List<WebBase>();
            //TVItemTelList = new List<WebBase>();
            TVItemCountryList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
