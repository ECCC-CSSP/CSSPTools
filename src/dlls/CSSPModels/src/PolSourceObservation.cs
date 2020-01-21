/*
 * Manually edited by Charles LeBlanc 
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
    public partial class PolSourceObservation : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "PolSourceObservation ID")]
        [CSSPDisplayFR(DisplayFR = "PolSourceObservation ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the PolSourceObservations table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table PolSourceObservations")]
        public int PolSourceObservationID { get; set; }
        [CSSPExist(ExistTypeName = "PolSourceSite", ExistPlurial = "s", ExistFieldID = "PolSourceSiteID")]
        [CSSPDisplayEN(DisplayEN = "Pollution source site ID")]
        [CSSPDisplayFR(DisplayFR = "Site de la source de pollution ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the PolSourceSites table representing the pollution source site")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table PolSourceSites représentant le site de source de pollution")]
        public int PolSourceSiteID { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Observation date")]
        [CSSPDisplayFR(DisplayFR = "Date d'observation")]
        [CSSPDescriptionEN(DescriptionEN = @"Observation date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date d'observation")]
        public DateTime ObservationDate_Local { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
        [CSSPDisplayEN(DisplayEN = "Contact who made the observation TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Contact ayant l'observation TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the contact who made the observation")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le contact ayant l'observation")]
        public int ContactTVItemID { get; set; }
        [CSSPDisplayEN(DisplayEN = "Desktop Reviewed")]
        [CSSPDisplayFR(DisplayFR = "Révisé au bureau")]
        [CSSPDescriptionEN(DescriptionEN = @"Desktop Reviewed")]
        [CSSPDescriptionFR(DescriptionFR = @"Révisé au bureau")]
        public bool DesktopReviewed { get; set; }
        [CSSPDisplayEN(DisplayEN = "Observation to be deleted")]
        [CSSPDisplayFR(DisplayFR = "Observation qui va être effacé")]
        [CSSPDescriptionEN(DescriptionEN = @"Observation to be deleted")]
        [CSSPDescriptionFR(DescriptionFR = @"Observation qui va être effacé")]
        public string Observation_ToBeDeleted { get; set; }

        [ForeignKey(nameof(ContactTVItemID))]
        [InverseProperty(nameof(TVItem.PolSourceObservations))]
        public virtual TVItem ContactTVItem { get; set; }
        [ForeignKey(nameof(PolSourceSiteID))]
        [InverseProperty(nameof(PolSourceSite.PolSourceObservations))]
        public virtual PolSourceSite PolSourceSiteNavigation { get; set; }
        [InverseProperty("PolSourceObservation")]
        public virtual ICollection<PolSourceObservationIssue> PolSourceObservationIssues { get; set; }
        #endregion Properties in DB

        #region Constructors
        public PolSourceObservation() : base()
        {
        }
        #endregion Constructors
    }
}
