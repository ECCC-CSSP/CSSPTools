﻿/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebAllTideLocations(WebAllTideLocations WebAllTideLocations, WebAllTideLocations WebAllTideLocationsLocal)
        {
            List<TideLocation> tideLocationLocalList = (from c in WebAllTideLocationsLocal.TideLocationList
                                              where c.DBCommand != DBCommandEnum.Original
                                              select c).ToList();

            foreach (TideLocation tideLocationLocal in tideLocationLocalList)
            {
                TideLocation tideLocationOriginal = WebAllTideLocations.TideLocationList.Where(c => c.TideLocationID == tideLocationLocal.TideLocationID).FirstOrDefault();
                if (tideLocationOriginal == null)
                {
                    WebAllTideLocations.TideLocationList.Add(tideLocationLocal);
                }
                else
                {
                    tideLocationOriginal = tideLocationLocal;
                }
            }
        }
    }
}
