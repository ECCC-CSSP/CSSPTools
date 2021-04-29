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
    public partial class TideSiteModel
    {
        #region Properties
        public TVItemMapModel TVItemMapModel { get; set; }
        public TideSite TideSite { get; set; }
        public List<TideDataValue> TideDataValueList { get; set; }
        #endregion Properties

        #region Constructors
        public TideSiteModel()
        {
            TideDataValueList = new List<TideDataValue>();
        }
        #endregion Constructors
    }
}
