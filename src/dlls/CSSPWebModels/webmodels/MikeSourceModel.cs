﻿/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class MikeSourceModel
    {
        #region Properties
        public TVItemMapModel TVItemMapModel { get; set; }
        public MikeSource MikeSource { get; set; }
        public List<MikeSourceStartEnd> MikeSourceStartEndList { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceModel()
        {
            TVItemMapModel = new TVItemMapModel();
            MikeSource = new MikeSource();
            MikeSourceStartEndList = new List<MikeSourceStartEnd>();
        }
        #endregion Constructors
    }
}
