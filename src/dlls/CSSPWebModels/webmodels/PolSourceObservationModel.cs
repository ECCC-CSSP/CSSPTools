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
    public partial class PolSourceObservationModel
    {
        #region Properties
        public PolSourceObservation PolSourceObservation { get; set; }
        public List<PolSourceObservationIssue> PolSourceObservationIssueList { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationModel()
        {
            PolSourceObservation = new PolSourceObservation();
            PolSourceObservationIssueList = new List<PolSourceObservationIssue>();
        }
        #endregion Constructors
    }
}
