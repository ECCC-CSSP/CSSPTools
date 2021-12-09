//namespace CSSPDBLocalServices.Tests;

//public partial class CSSPDBLocalServiceTest
//{
//    protected void CheckLocalJsonFileCreated(List<TVItemModel> tvItemModelList)
//    {
//        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

//        Assert.True(di.Exists);

//        List<FileInfo> fiList = di.GetFiles().ToList();

//        for (int i = 0, count = tvItemModelList.Count; i < count; i++)
//        {
//            List<string> FileNameList = new List<string>();

//            switch (tvItemModelList[i].TVItem.TVType)
//            {
//                case TVTypeEnum.Address:
//                    {
//                        FileNameList.Add($"{ WebTypeEnum.WebAllAddresses }.gz");
//                    }
//                    break;
//                case TVTypeEnum.Area:
//                    {
//                        FileNameList.Add($"{ WebTypeEnum.WebArea }_{ tvItemModelList[i].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                case TVTypeEnum.ClimateSite:
//                    {
//                        Assert.True(i > 0);

//                        FileNameList.Add($"{ WebTypeEnum.WebClimateSites }_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                case TVTypeEnum.Country:
//                    {
//                        FileNameList.Add($"{ WebTypeEnum.WebCountry}_{ tvItemModelList[i].TVItem.TVItemID }.gz");
//                        FileNameList.Add($"{ WebTypeEnum.WebAllCountries}.gz");
//                    }
//                    break;
//                case TVTypeEnum.Email:
//                    {
//                        FileNameList.Add($"{ WebTypeEnum.WebAllEmails}.gz");
//                    }
//                    break;
//                case TVTypeEnum.EmailDistributionList:
//                    {
//                        Assert.True(i > 0);

//                        FileNameList.Add($"{ WebTypeEnum.WebCountry}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                case TVTypeEnum.File:
//                    {
//                        Assert.True(i > 0);

//                        switch (tvItemModelList[i - 1].TVItem.TVType)
//                        {
//                            case TVTypeEnum.Area:
//                                {
//                                    FileNameList.Add($"{ WebTypeEnum.WebArea}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                                }
//                                break;
//                            case TVTypeEnum.Country:
//                                {
//                                    FileNameList.Add($"{ WebTypeEnum.WebCountry}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                                }
//                                break;
//                            case TVTypeEnum.Infrastructure:
//                                {
//                                    Assert.True(i > 1);

//                                    FileNameList.Add($"{ WebTypeEnum.WebMunicipality}_{ tvItemModelList[i - 2].TVItem.TVItemID }.gz");
//                                }
//                                break;
//                            case TVTypeEnum.Province:
//                                {
//                                    FileNameList.Add($"{ WebTypeEnum.WebProvince}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                                }
//                                break;
//                            case TVTypeEnum.MikeScenario:
//                                {
//                                    Assert.True(i > 1);

//                                    FileNameList.Add($"{ WebTypeEnum.WebMikeScenarios}_{ tvItemModelList[i - 2].TVItem.TVItemID }.gz");
//                                }
//                                break;
//                            case TVTypeEnum.Municipality:
//                                {
//                                    FileNameList.Add($"{ WebTypeEnum.WebMunicipality}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                                }
//                                break;
//                            case TVTypeEnum.MWQMSite:
//                                {
//                                    Assert.True(i > 1);

//                                    FileNameList.Add($"{ WebTypeEnum.WebMWQMSites}_{ tvItemModelList[i - 2].TVItem.TVItemID }.gz");
//                                }
//                                break;
//                            case TVTypeEnum.PolSourceSite:
//                                {
//                                    Assert.True(i > 1);

//                                    FileNameList.Add($"{ WebTypeEnum.WebPolSourceSites}_{ tvItemModelList[i - 2].TVItem.TVItemID }.gz");
//                                }
//                                break;
//                            case TVTypeEnum.Root:
//                                {
//                                    FileNameList.Add($"{ WebTypeEnum.WebRoot}.gz");
//                                }
//                                break;
//                            case TVTypeEnum.Sector:
//                                {
//                                    FileNameList.Add($"{ WebTypeEnum.WebSector}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                                }
//                                break;
//                            case TVTypeEnum.Subsector:
//                                {
//                                    FileNameList.Add($"{ WebTypeEnum.WebSubsector}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                                }
//                                break;
//                            default:
//                                break;
//                        }
//                    }
//                    break;
//                case TVTypeEnum.Infrastructure:
//                    {
//                        Assert.True(i > 0);

//                        FileNameList.Add($"{ WebTypeEnum.WebMunicipality}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                case TVTypeEnum.HydrometricSite:
//                    {
//                        Assert.True(i > 0);

//                        FileNameList.Add($"{ WebTypeEnum.WebProvince}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                case TVTypeEnum.MikeBoundaryConditionMesh:
//                    {
//                        Assert.True(i > 1);

//                        FileNameList.Add($"{ WebTypeEnum.WebMikeScenarios}_{ tvItemModelList[i - 2].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                case TVTypeEnum.MikeBoundaryConditionWebTide:
//                    {
//                        Assert.True(i > 1);

//                        FileNameList.Add($"{ WebTypeEnum.WebMikeScenarios}_{ tvItemModelList[i - 2].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                case TVTypeEnum.MikeScenario:
//                    {
//                        Assert.True(i > 0);

//                        FileNameList.Add($"{ WebTypeEnum.WebMikeScenarios}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                case TVTypeEnum.MikeSource:
//                    {
//                        Assert.True(i > 1);

//                        FileNameList.Add($"{ WebTypeEnum.WebMikeScenarios}_{ tvItemModelList[i - 2].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                case TVTypeEnum.Municipality:
//                    {
//                        FileNameList.Add($"{ WebTypeEnum.WebMunicipality}_{ tvItemModelList[i].TVItem.TVItemID }.gz");
//                        FileNameList.Add($"{ WebTypeEnum.WebAllMunicipalities}.gz");
//                    }
//                    break;
//                case TVTypeEnum.MWQMRun:
//                    {
//                        Assert.True(i > 0);

//                        FileNameList.Add($"{ WebTypeEnum.WebMWQMRuns}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                case TVTypeEnum.MWQMSite:
//                    {
//                        Assert.True(i > 0);

//                        FileNameList.Add($"{ WebTypeEnum.WebMWQMSites}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                case TVTypeEnum.PolSourceSite:
//                    {
//                        Assert.True(i > 0);

//                        FileNameList.Add($"{ WebTypeEnum.WebPolSourceSites}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                case TVTypeEnum.Province:
//                    {
//                        FileNameList.Add($"{ WebTypeEnum.WebProvince}_{ tvItemModelList[i].TVItem.TVItemID }.gz");
//                        FileNameList.Add($"{ WebTypeEnum.WebAllProvinces}.gz");
//                    }
//                    break;
//                case TVTypeEnum.RainExceedance:
//                    {
//                        Assert.True(i > 0);

//                        FileNameList.Add($"{ WebTypeEnum.WebCountry}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                case TVTypeEnum.Root:
//                    {
//                        FileNameList.Add($"{ WebTypeEnum.WebRoot}.gz");
//                    }
//                    break;
//                case TVTypeEnum.SamplingPlan:
//                    {
//                        Assert.True(i > 0);

//                        FileNameList.Add($"{ WebTypeEnum.WebProvince}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                case TVTypeEnum.Sector:
//                    {
//                        FileNameList.Add($"{ WebTypeEnum.WebSector}_{ tvItemModelList[i].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                case TVTypeEnum.Subsector:
//                    {
//                        FileNameList.Add($"{ WebTypeEnum.WebSubsector}_{ tvItemModelList[i].TVItem.TVItemID }.gz");
//                        FileNameList.Add($"{ WebTypeEnum.WebAllMWQMSubsectors}.gz");
//                    }
//                    break;
//                case TVTypeEnum.Tel:
//                    {
//                        FileNameList.Add($"{ WebTypeEnum.WebAllTels}.gz");
//                    }
//                    break;
//                case TVTypeEnum.TideSite:
//                    {
//                        Assert.True(i > 0);

//                        FileNameList.Add($"{ WebTypeEnum.WebTideSites}_{ tvItemModelList[i - 1].TVItem.TVItemID }.gz");
//                    }
//                    break;
//                default:
//                    break;
//            }

//            foreach (string FileName in FileNameList)
//            {
//                Assert.True((from c in fiList
//                             where c.Name == FileName
//                             select c).Any());
//            }
//        }
//    }
//}

