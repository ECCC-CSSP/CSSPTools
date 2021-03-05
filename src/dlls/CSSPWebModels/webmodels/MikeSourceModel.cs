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
    public partial class MikeSourceModel : WebBase
    {
        public MikeSource MikeSource { get; set; }
        #region Properties
        public List<MikeSourceStartEnd> MikeSourceStartEndList { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceModel()
        {
            MikeSource = new MikeSource();
            MikeSourceStartEndList = new List<MikeSourceStartEnd>();
        }
        #endregion Constructors
    }
}
