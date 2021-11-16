/*
 * Manually edited
 * 
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class RunsToRemoveFromStat
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public bool RemoveFromStat { get; set; }
        [Range(1, -1)]
        public int MWQMRunTVItemID { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public RunsToRemoveFromStat()
        {
        }
        #endregion Constructors
    }
}
