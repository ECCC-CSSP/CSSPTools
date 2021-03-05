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

namespace CSSPWebModels
{
    [NotMapped]
    public partial class ToRecreate
    {
        #region Properties
        [CSSPEnumType]
        public WebTypeEnum WebType { get; set; }
        public int TVItemID { get; set; }
        [CSSPEnumType]
        public WebTypeYearEnum WebTypeYear { get; set; }
        #endregion Properties

        #region Constructors
        public ToRecreate()
        {
        }

        public static void AppendToRecreateList(List<ToRecreate> ToRecreateList, WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            if (!(from c in ToRecreateList
                  where c.WebType == webType
                  && c.TVItemID == TVItemID
                  && c.WebTypeYear == webTypeYear
                  select c).Any())
            {
                ToRecreateList.Add(new ToRecreate() { WebType = webType, TVItemID = TVItemID, WebTypeYear = webTypeYear });
            }
        }
        #endregion Constructors
    }
}
