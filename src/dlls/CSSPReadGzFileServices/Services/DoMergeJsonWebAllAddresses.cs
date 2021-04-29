/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using CSSPDBPreferenceModels;
using CSSPDBFilesManagementModels;
using LoggedInServices;
using CSSPWebModels;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebAllAddresses(WebAllAddresses WebAllAddresses, WebAllAddresses WebAllAddressesLocal)
        {
            List<AddressModel> addressModelLocalList = (from c in WebAllAddressesLocal.AddressModelList
                                                        where c.TVItem.DBCommand != DBCommandEnum.Original
                                                        || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                        || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                        || c.Address.DBCommand != DBCommandEnum.Original
                                                        select c).ToList();

            foreach (AddressModel addressModelLocal in addressModelLocalList)
            {
                AddressModel addressModelOriginal = WebAllAddresses.AddressModelList.Where(c => c.TVItem.TVItemID == addressModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (addressModelOriginal == null)
                {
                    WebAllAddresses.AddressModelList.Add(addressModelLocal);
                }
                else
                {
                    addressModelOriginal = addressModelLocal;
                }
            }
        }
    }
}
