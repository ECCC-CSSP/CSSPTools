/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPDBModels;
using CSSPEnums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class TVFileModelByPurpose
    {
        [CSSPEnumType]
        public FilePurposeEnum FilePurpose { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }

        public TVFileModelByPurpose()
        {
            TVFileModelList = new List<TVFileModel>();
        }
    }
}
