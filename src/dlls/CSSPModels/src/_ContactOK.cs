﻿/*
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
    public partial class ContactOK
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "Contact ID")]
        [CSSPDisplayFR(DisplayFR = "Identifiant de contact")]
        [CSSPDescriptionEN(DescriptionEN = @"Contact ID")]
        [CSSPDescriptionFR(DescriptionFR = @"Identifiant de contact")]
        public int ContactID { get; set; }
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "Contact TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Contact TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table with the unique identifier")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems avec l'identifiant unique")]
        public int ContactTVItemID { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public ContactOK() : base()
        {
        }
        #endregion Constructors
    }
}
