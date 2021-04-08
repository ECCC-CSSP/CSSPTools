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
            tvItemParentList = new List<WebBase>();
            tvItemSiblingList = new List<WebBase>();
            tvItemFileSiblingList = new List<WebBase>();
            tvItemList = new List<WebBase>();
        }

        public TVItem ParentTVItem { get; set; }
        public List<WebBase> tvItemParentList { get; set; }
        public List<WebBase> tvItemSiblingList { get; set; }
        public List<WebBase> tvItemFileSiblingList { get; set; }
        public List<WebBase> tvItemList { get; set; }
    }

}