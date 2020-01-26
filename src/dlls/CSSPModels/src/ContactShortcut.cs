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
    public partial class ContactShortcut : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "ContactShortcut ID")]
        [CSSPDisplayFR(DisplayFR = "ContactShortcut ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the ContactShortcuts table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table ContactShortcuts")]
        public int ContactShortcutID { get; set; }
        [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID")]
        [CSSPDisplayEN(DisplayEN = "Contact ID")]
        [CSSPDisplayFR(DisplayFR = "Contact ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the Contacts table with the unique identifier")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table Contacts avec l'identifiant unique")]
        public int ContactID { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "Shortcut text")]
        [CSSPDisplayFR(DisplayFR = "Texte de raccourci")]
        [CSSPDescriptionEN(DescriptionEN = @"Shortcut text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte de raccourci")]
        public string ShortCutText { get; set; }
        [StringLength(200)]
        [CSSPDisplayEN(DisplayEN = "Shortcut address")]
        [CSSPDisplayFR(DisplayFR = "Texte de l'address")]
        [CSSPDescriptionEN(DescriptionEN = @"Shortcut address")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte de l'address")]
        public string ShortCutAddress { get; set; }
        #endregion Properties in DB

        #region Constructors
        public ContactShortcut() : base()
        {
        }
        #endregion Constructors
    }
}
