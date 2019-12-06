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
    [NotMapped]
    public partial class DBTable : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [StringLength(200, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Table name")]
        [CSSPDisplayFR(DisplayFR = "Nom de la table")]
        [CSSPDescriptionEN(DescriptionEN = @"Database table name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom de la table de la base de donnée")]
        public string TableName { get; set; }
        [StringLength(3, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Plurial")]
        [CSSPDisplayFR(DisplayFR = "Pluriel")]
        [CSSPDescriptionEN(DescriptionEN = @"One or two letters to create the plurial (Ex: 's', 'es')")]
        [CSSPDescriptionFR(DescriptionFR = @"Une ou deux lettres de fin créant le pruriel (Ex: 's', 'es')")]
        public string Plurial { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public DBTable() : base()
        {
        }
        #endregion Constructors
    }
}
