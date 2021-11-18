/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ICSSPReadGzFileService
    {
        private void SyncMikeSourceModel(MikeSourceModel mikeSourceModelOriginal, MikeSourceModel mikeSourceModelLocal)
        {
            if (mikeSourceModelLocal != null)
            {
                if (mikeSourceModelLocal.TVItemModel != null)
                {
                    SyncTVItemModel(mikeSourceModelOriginal.TVItemModel, mikeSourceModelLocal.TVItemModel);
                }
                if (mikeSourceModelLocal.MikeSource != null)
                {
                    mikeSourceModelOriginal.MikeSource = mikeSourceModelLocal.MikeSource;
                }
                foreach (MikeSourceStartEnd mikeSourceStartEndLocal in mikeSourceModelLocal.MikeSourceStartEndList)
                {
                    MikeSourceStartEnd mikeSourceStartEndOriginal = mikeSourceModelOriginal.MikeSourceStartEndList.Where(c => c.MikeSourceStartEndID == mikeSourceStartEndLocal.MikeSourceStartEndID).FirstOrDefault();
                    if (mikeSourceStartEndOriginal == null)
                    {
                        mikeSourceModelOriginal.MikeSourceStartEndList.Add(mikeSourceStartEndLocal);
                    }
                    else
                    {
                        mikeSourceStartEndOriginal = mikeSourceStartEndLocal;
                    }
                }
            }
        }
    }
}
