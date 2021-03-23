/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class LastUpdateAndContact
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPAfter(Year = 1980)]
        public DateTime LastUpdateAndContactDate_UTC { get; set; }
        [CSSPRange(1, -1)]
        public int LastUpdateAndContactTVItemID { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public LastUpdateAndContact() : base()
        {
        }
        #endregion Constructors
    }
}
