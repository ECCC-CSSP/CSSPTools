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
    public partial class InfrastructureModelPath
    {
        #region Properties
        public InfrastructureModel InfrastructureModel { get; set; }
        public List<InfrastructureModelPath> InfrastructureModelChildList { get; set; }
        public int Count { get; set; }
        public bool ShowOnMap { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureModelPath()
        {
        }
        #endregion Constructors
    }
}
