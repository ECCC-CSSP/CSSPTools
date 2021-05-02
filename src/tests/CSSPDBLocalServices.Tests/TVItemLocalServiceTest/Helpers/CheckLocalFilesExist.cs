/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPDBPreferenceModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPScrambleServices;
using CSSPWebModels;
using LoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private void CheckLocalFilesExist(List<TVItemModel> webBaseList)
        {
            int index = 0;
            foreach (TVItemModel webBase in webBaseList)
            {
                index += 1;
                switch (webBase.TVItem.TVType)
                {
                    case TVTypeEnum.Address:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebAllAddresses.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.Area:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebArea_{ webBase.TVItem.TVItemID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.Classification:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebSubsector_{ webBase.TVItem.ParentID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.ClimateSite:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebClimateSite_{ webBase.TVItem.ParentID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");

                            fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebClimateDataValue_{ webBase.TVItem.TVItemID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.Contact:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebAllContacts.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.Country:
                       {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebCountry_{ webBase.TVItem.TVItemID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");

                            fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebAllCountries.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.Email:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebAllEmails.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.File:
                        {
                            switch (webBaseList[index - 1].TVItem.TVType)
                            {
                                case TVTypeEnum.Area:
                                    {
                                        FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebArea_{ webBaseList[index - 1].TVItem.TVItemID }.gz");
                                        Assert.True(fi.Exists, $"File not found { fi.FullName }");
                                    }
                                    break;
                                case TVTypeEnum.Country:
                                    {
                                        FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebCountry_{ webBaseList[index - 1].TVItem.TVItemID }.gz");
                                        Assert.True(fi.Exists, $"File not found { fi.FullName }");
                                    }
                                    break;
                                case TVTypeEnum.Infrastructure:
                                    {
                                        FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebInfrastructure_{ webBaseList[index - 1].TVItem.ParentID }.gz");
                                        Assert.True(fi.Exists, $"File not found { fi.FullName }");
                                    }
                                    break;
                                case TVTypeEnum.MikeScenario:
                                    {
                                        FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebMikeScenario_{ webBaseList[index - 1].TVItem.TVItemID }.gz");
                                        Assert.True(fi.Exists, $"File not found { fi.FullName }");
                                    }
                                    break;
                                case TVTypeEnum.Municipality:
                                    {
                                        FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebMunicipality_{ webBaseList[index - 1].TVItem.TVItemID }.gz");
                                        Assert.True(fi.Exists, $"File not found { fi.FullName }");
                                    }
                                    break;
                                case TVTypeEnum.MWQMSite:
                                    {
                                        FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebMWQMSite_{ webBaseList[index - 1].TVItem.ParentID }.gz");
                                        Assert.True(fi.Exists, $"File not found { fi.FullName }");
                                    }
                                    break;
                                case TVTypeEnum.PolSourceSite:
                                    {
                                        FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebPolSourceSite_{ webBaseList[index - 1].TVItem.ParentID }.gz");
                                        Assert.True(fi.Exists, $"File not found { fi.FullName }");
                                    }
                                    break;
                                case TVTypeEnum.Province:
                                    {
                                        FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebProvince_{ webBaseList[index - 1].TVItem.TVItemID }.gz");
                                        Assert.True(fi.Exists, $"File not found { fi.FullName }");
                                    }
                                    break;
                                case TVTypeEnum.Root:
                                    {
                                        FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebRoot.gz");
                                        Assert.True(fi.Exists, $"File not found { fi.FullName }");
                                    }
                                    break;
                                case TVTypeEnum.Sector:
                                    {
                                        FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebSector_{ webBaseList[index - 1].TVItem.TVItemID }.gz");
                                        Assert.True(fi.Exists, $"File not found { fi.FullName }");
                                    }
                                    break;
                                case TVTypeEnum.Subsector:
                                    {
                                        FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebSubsector_{ webBaseList[index - 1].TVItem.TVItemID }.gz");
                                        Assert.True(fi.Exists, $"File not found { fi.FullName }");
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case TVTypeEnum.HydrometricSite:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebHydrometricSite_{ webBase.TVItem.ParentID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");

                            fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebHydrometricDataValue_{ webBase.TVItem.TVItemID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.Infrastructure:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebInfrastructure_{ webBase.TVItem.ParentID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.MikeBoundaryConditionMesh:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebMikeScenario_{ webBase.TVItem.ParentID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.MikeBoundaryConditionWebTide:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebMikeScenario_{ webBase.TVItem.ParentID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.MikeScenario:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebMikeScenario_{ webBase.TVItem.TVItemID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");

                            fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebMunicipality_{ webBase.TVItem.ParentID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.MikeSource:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebMikeScenario_{ webBase.TVItem.ParentID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.Municipality:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebMunicipality_{ webBase.TVItem.TVItemID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");

                            fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebInfrastructure_{ webBase.TVItem.TVItemID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");

                            fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebMunicipalities_{ webBase.TVItem.ParentID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");

                            fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebAllMunicipalities.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.MWQMRun:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebMWQMRun_{ webBase.TVItem.ParentID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.MWQMSite:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebMWQMSite_{ webBase.TVItem.ParentID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.PolSourceSite:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebPolSourceSite_{ webBase.TVItem.ParentID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.Province:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebProvince_{ webBase.TVItem.TVItemID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");

                            fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebAllProvinces.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.RainExceedance:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebCountry_{ webBase.TVItem.ParentID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.Root:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebRoot.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.Sector:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebSector_{ webBase.TVItem.TVItemID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.Subsector:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebSubsector_{ webBase.TVItem.TVItemID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.Tel:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebAllTels.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    case TVTypeEnum.TideSite:
                        {
                            FileInfo fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebSubsector_{ webBase.TVItem.ParentID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");

                            fi = new FileInfo($@"{ CSSPJSONPathLocal }\WebTideSite_{ webBase.TVItem.ParentID }.gz");
                            Assert.True(fi.Exists, $"File not found { fi.FullName }");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
