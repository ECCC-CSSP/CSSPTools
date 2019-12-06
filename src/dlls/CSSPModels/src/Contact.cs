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
    public partial class Contact : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "Contact ID")]
        [CSSPDisplayFR(DisplayFR = "Contact ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the Contacts table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table Contacts")]
        public int ContactID { get; set; }
        [CSSPExist(ExistTypeName = "AspNetUser", ExistPlurial = "s", ExistFieldID = "Id")]
        [StringLength(128)]
        [CSSPDisplayEN(DisplayEN = "Id")]
        [CSSPDisplayFR(DisplayFR = "Id")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the AspNetUsers table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table AspNetUsers")]
        public string Id { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
        [CSSPDisplayEN(DisplayEN = "Contact TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Contact TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table with the unique identifier")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems avec l'identifiant unique")]
        public int ContactTVItemID { get; set; }
        [StringLength(255, MinimumLength = 6)]
        [DataType(DataType.EmailAddress)]
        [CSSPDisplayEN(DisplayEN = "Login email")]
        [CSSPDisplayFR(DisplayFR = "Courriel de connexion")]
        [CSSPDescriptionEN(DescriptionEN = @"Login email for connecting to web site")]
        [CSSPDescriptionFR(DescriptionFR = @"Courriel de connexion pour le site web")]
        public string LoginEmail { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "First name")]
        [CSSPDisplayFR(DisplayFR = "Prénom")]
        [CSSPDescriptionEN(DescriptionEN = @"First name")]
        [CSSPDescriptionFR(DescriptionFR = @"Prénom")]
        public string FirstName { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "Last name")]
        [CSSPDisplayFR(DisplayFR = "Nom")]
        [CSSPDescriptionEN(DescriptionEN = @"Last name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom")]
        public string LastName { get; set; }
        [StringLength(50)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Initial")]
        [CSSPDisplayFR(DisplayFR = "Initiale")]
        [CSSPDescriptionEN(DescriptionEN = @"Initial")]
        [CSSPDescriptionFR(DescriptionFR = @"Initiale")]
        public string Initial { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "Web name")]
        [CSSPDisplayFR(DisplayFR = "Nom Web")]
        [CSSPDescriptionEN(DescriptionEN = @"Web name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom Web")]
        public string WebName { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Title")]
        [CSSPDisplayFR(DisplayFR = "Titre")]
        [CSSPDescriptionEN(DescriptionEN = @"Title")]
        [CSSPDescriptionFR(DescriptionFR = @"Titre")]
        public ContactTitleEnum? ContactTitle { get; set; }
        [CSSPDisplayEN(DisplayEN = "Administrator")]
        [CSSPDisplayFR(DisplayFR = "Administrateur")]
        [CSSPDescriptionEN(DescriptionEN = @"Administrator")]
        [CSSPDescriptionFR(DescriptionFR = @"Administrateur")]
        public bool IsAdmin { get; set; }
        [CSSPDisplayEN(DisplayEN = "Email validated")]
        [CSSPDisplayFR(DisplayFR = "Courriel validé")]
        [CSSPDescriptionEN(DescriptionEN = @"Email validated")]
        [CSSPDescriptionFR(DescriptionFR = @"Courriel validé")]
        public bool EmailValidated { get; set; }
        [CSSPDisplayEN(DisplayEN = "Disabled")]
        [CSSPDisplayFR(DisplayFR = "Déactivé")]
        [CSSPDescriptionEN(DescriptionEN = @"Disabled")]
        [CSSPDescriptionFR(DescriptionFR = @"Déactivé")]
        public bool Disabled { get; set; }
        [CSSPDisplayEN(DisplayEN = "Is new")]
        [CSSPDisplayFR(DisplayFR = "Est nouveau")]
        [CSSPDescriptionEN(DescriptionEN = @"Is new")]
        [CSSPDescriptionFR(DescriptionFR = @"Est nouveau")]
        public bool IsNew { get; set; }
        [StringLength(200)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sampling planner for provinces")]
        [CSSPDisplayFR(DisplayFR = "Planificateur d'échantillonnage pour les provinces")]
        [CSSPDescriptionEN(DescriptionEN = @"Sampling planner for provinces")]
        [CSSPDescriptionFR(DescriptionFR = @"Planificateur d'échantillonnage pour les provinces")]
        public string SamplingPlanner_ProvincesTVItemID { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Contact() : base()
        {
        }
        #endregion Constructors
    }
}
