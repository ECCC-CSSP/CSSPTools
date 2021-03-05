/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class PostTVItemModel
    {
        public int ParentID { get; set; }
        public int TVItemID { get; set; }
        [CSSPEnumType]
        public TVTypeEnum TVType { get; set; }
        public string TVTextEN { get; set; }
        public string TVTextFR { get; set; }

        public PostTVItemModel()
        {
        }
    }
}
