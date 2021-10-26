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
    public partial class WebSubsector
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }
        public List<TVItemModel> TVItemModelClassificationList { get; set; }
        #endregion Properties

        #region Constructors
        public WebSubsector()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            TVFileModelList = new List<TVFileModel>();
            TVItemModelClassificationList = new List<TVItemModel>();
        }
        #endregion Constructors
    }
}
