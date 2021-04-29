/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CSSPDBLocalServices
{
    public class GzObjectList
    {
        public GzObjectList()
        {
            tvItemParentList = new List<TVItemStatModel>();
            tvItemSiblingList = new List<TVItemModel>();
            tvItemFileSiblingList = new List<TVFileModel>();
            tvItemList = new List<TVItemModel>();
        }

        public TVItem ParentTVItem { get; set; }
        public List<TVItemStatModel> tvItemParentList { get; set; }
        public List<TVItemModel> tvItemSiblingList { get; set; }
        public List<TVFileModel> tvItemFileSiblingList { get; set; }
        public List<TVItemModel> tvItemList { get; set; }
    }

}