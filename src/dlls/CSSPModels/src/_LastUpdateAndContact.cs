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
    public partial class LastUpdateAndContact : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Last update date (UTC)")]
        [CSSPDisplayFR(DisplayFR = "Date de la dernière mise à jour (UTC)")]
        [CSSPDescriptionEN(DescriptionEN = @"Last update date (UTC)")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de la dernière mise à jour (UTC)")]
        public DateTime LastUpdateAndContactDate_UTC { get; set; }
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "Contact TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Contact TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems representing the contact")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le contact")]
        public int LastUpdateAndContactTVItemID { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public LastUpdateAndContact() : base()
        {
        }
        #endregion Constructors
    }
}
