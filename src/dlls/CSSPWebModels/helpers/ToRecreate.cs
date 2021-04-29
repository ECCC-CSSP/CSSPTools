/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Linq;
using CSSPCustomAttributes;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class ToRecreate
    {
        #region Properties
        [CSSPEnumType]
        public WebTypeEnum WebType { get; set; }
        public int TVItemID { get; set; }
        #endregion Properties

        #region Constructors
        public ToRecreate()
        {
        }

        public static void AppendToRecreateList(List<ToRecreate> ToRecreateList, WebTypeEnum webType, int TVItemID)
        {
            if (!(from c in ToRecreateList
                  where c.WebType == webType
                  && c.TVItemID == TVItemID
                  select c).Any())
            {
                ToRecreateList.Add(new ToRecreate() { WebType = webType, TVItemID = TVItemID });
            }
        }
        #endregion Constructors
    }
}
