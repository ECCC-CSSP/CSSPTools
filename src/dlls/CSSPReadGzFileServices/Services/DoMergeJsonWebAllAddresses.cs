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
            // -----------------------------------------------------------
            // doing TVItemAllAddressesList
            // -----------------------------------------------------------
            int count = WebAllAddresses.TVItemAllAddressList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in WebAllAddressesLocal.TVItemAllAddressList
                                        where c.TVItemModel.TVItem.TVItemID == WebAllAddresses.TVItemAllAddressList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    WebAllAddresses.TVItemAllAddressList[i] = webBaseLocal;
                }
            }

            List<WebBase> webBaseLocalNewList = (from c in WebAllAddressesLocal.TVItemAllAddressList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                WebAllAddresses.TVItemAllAddressList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing AddressList
            // -----------------------------------------------------------
            
            count = WebAllAddresses.AddressList.Count;
            for (int i = 0; i < count; i++)
            {
                Address AddressLocal = (from c in WebAllAddressesLocal.AddressList
                                        where c.AddressID == WebAllAddresses.AddressList[i].AddressID
                                        && c.DBCommand != DBCommandEnum.Original
                                        select c).FirstOrDefault();

                if (AddressLocal != null)
                {
                    WebAllAddresses.AddressList[i] = AddressLocal;
                }
            }

            List<Address> AddressLocalNewList = (from c in WebAllAddressesLocal.AddressList
                                                 where c.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach(Address AddressNew in AddressLocalNewList)
            {
                WebAllAddresses.AddressList.Add(AddressNew);
            }

            return;
        }
    }
}
