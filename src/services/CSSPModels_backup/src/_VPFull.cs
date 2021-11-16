/*
 * Manually edited
 * 
 */
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPModels
{
    [NotMapped]
    public partial class VPFull
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public VPScenario VPScenario { get; set; }
        public List<VPAmbient> VPAmbientList { get; set; }
        public List<VPResult> VPResultList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public VPFull() : base()
        {
            VPAmbientList = new List<VPAmbient>();
            VPResultList = new List<VPResult>();
        }
        #endregion Constructors
    }
}
