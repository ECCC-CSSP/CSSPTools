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
    public partial class Log : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "Log ID")]
        [CSSPDisplayFR(DisplayFR = "Log ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the Logs table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table Logs")]
        public int LogID { get; set; }
        [StringLength(50)]
        [CSSPDisplayEN(DisplayEN = "Table name")]
        [CSSPDisplayFR(DisplayFR = "Nom de la table")]
        [CSSPDescriptionEN(DescriptionEN = @"Table name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom de la table")]
        public string TableName { get; set; }
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "Key of table")]
        [CSSPDisplayFR(DisplayFR = "Clef de la table")]
        [CSSPDescriptionEN(DescriptionEN = @"Key of table")]
        [CSSPDescriptionFR(DescriptionFR = @"Clef de la table")]
        public int ID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Log command")]
        [CSSPDisplayFR(DisplayFR = "Command log")]
        [CSSPDescriptionEN(DescriptionEN = @"Log command")]
        [CSSPDescriptionFR(DescriptionFR = @"Command log")]
        public LogCommandEnum LogCommand { get; set; }
        [CSSPDisplayEN(DisplayEN = "Information")]
        [CSSPDisplayFR(DisplayFR = "Information")]
        [CSSPDescriptionEN(DescriptionEN = @"Information describing the log command")]
        [CSSPDescriptionFR(DescriptionFR = @"Information décrivant la command log")]
        public string Information { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Log() : base()
        {
        }
        #endregion Constructors
    }
}
