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
    public partial class LoadModel
    {
        #region Properties
        [CSSPEnumType]
        public WebTypeEnum WebType { get; set; }
        public int TVItemID { get; set; }
        public bool ForceReload { get; set; }
        #endregion Properties

        #region Constructors
        public LoadModel()
        {
        }
        #endregion Constructors
    }
}
