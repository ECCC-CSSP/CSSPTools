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
    public partial class OtherFilesToUpload : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "MikeScenario ID")]
        [CSSPDisplayFR(DisplayFR = "MikeScenario ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the MikeScenarios table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table MikeScenarios")]
        public int MikeScenarioID { get; set; }
        [CSSPDisplayEN(DisplayEN = "TVFile list")]
        [CSSPDisplayFR(DisplayFR = "List de TVFile")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view file list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste de filière de l'arbre visuel")]
        public List<TVFile> TVFileList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public OtherFilesToUpload() : base()
        {
            TVFileList = new List<TVFile>();
        }
        #endregion Constructors
    }
}
