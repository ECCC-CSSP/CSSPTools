using CSSPDBModels;
using CSSPEnums;
using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PolSourceGroupingExcelFileReadServices.Models;
using PolSourceGroupingExcelFileReadServices.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace GenerateRepopulateTestDB
{
    public partial class Startup
    {
        public async Task<bool> Generate()
        {
            Console.WriteLine("Generate Starting ...");

            string CSSPDB = Configuration.GetValue<string>("CSSPDB");

            Console.WriteLine("Reading PolSourceGroupingExcelFile ...");
            PolSourceGroupingExcelFileReadService polSourceGroupingExcelFileReadService = new PolSourceGroupingExcelFileReadService();

            FileInfo fiExcel = new FileInfo(Configuration.GetValue<string>("ExcelFileName"));

            if (!await polSourceGroupingExcelFileReadService.ReadExcelSheet(fiExcel.FullName, false))
            {
                return await Task.FromResult(false);
            }

            if (polSourceGroupingExcelFileReadService.GroupChoiceChildLevelList.Count == 0)
            {
                string ErrorText = $"Error _GroupChoiceChildLevelList is equal to 0";
                Console.WriteLine($"{ ErrorText }");

                return await Task.FromResult(false);
            }

            Console.WriteLine($"Reading Excel document and checking Done ...");

            List<PolSourceGrouping> polSourceGroupingToDeleteList = (from c in dbCSSPDB.PolSourceGroupings
                                                                     select c).ToList();

            try
            {
                dbCSSPDB.PolSourceGroupings.RemoveRange(polSourceGroupingToDeleteList);
                dbCSSPDB.SaveChanges();
            }
            catch (Exception)
            {
                int a = 34;
            }

            List<PolSourceGrouping> polSourceGroupingListToCreate = new List<PolSourceGrouping>();

            Console.WriteLine($"Starting Reading PolSourceGroupingList ...");

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileReadService.GroupChoiceChildLevelList)
            {

                PolSourceGrouping polSourceGrouping = new PolSourceGrouping()
                {
                    DBCommand = DBCommandEnum.Original,
                    CSSPID = int.Parse(groupChoiceChildLevel.CSSPID),
                    GroupName = groupChoiceChildLevel.Group,
                    Child = groupChoiceChildLevel.Child,
                    Hide = groupChoiceChildLevel.Hide,
                    LastUpdateDate_UTC = DateTime.UtcNow,
                    LastUpdateContactTVItemID = 2,
                };

                polSourceGroupingListToCreate.Add(polSourceGrouping);
            }

            try
            {
                dbCSSPDB.PolSourceGroupings.AddRange(polSourceGroupingListToCreate);
                dbCSSPDB.SaveChanges();
            }
            catch (Exception)
            {
                int a = 234;
                a = a + 1;
            }

            Console.WriteLine($"Saved in db PolSourceGroupingList ...");

            List<PolSourceGroupingLanguage> polSourceGroupingLanguageENList = new List<PolSourceGroupingLanguage>();

            Console.WriteLine($"Starting Reading PolSourceGroupingLanguageENList ...");

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileReadService.GroupChoiceChildLevelList)
            {

                PolSourceGroupingLanguage polSourceGroupingLanguageEN = new PolSourceGroupingLanguage()
                {
                    DBCommand = DBCommandEnum.Original,
                    Language = LanguageEnum.en,
                    Description = groupChoiceChildLevel.DescEN,
                    TranslationStatusDescription = TranslationStatusEnum.Translated,
                    Init = groupChoiceChildLevel.InitEN,
                    TranslationStatusInit = TranslationStatusEnum.Translated,
                    PolSourceGroupingID = (from c in polSourceGroupingListToCreate
                                           where c.CSSPID.ToString() == groupChoiceChildLevel.CSSPID
                                           select c.PolSourceGroupingID).FirstOrDefault(),
                    Report = groupChoiceChildLevel.ReportEN,
                    TranslationStatusReport = TranslationStatusEnum.Translated,
                    Text = groupChoiceChildLevel.TextEN,
                    TranslationStatusText = TranslationStatusEnum.Translated,
                    SourceName = groupChoiceChildLevel.EN,
                    TranslationStatusSourceName = TranslationStatusEnum.Translated,
                    SourceNameOrder = 0,
                    LastUpdateDate_UTC = DateTime.UtcNow,
                    LastUpdateContactTVItemID = 2,
                };

                polSourceGroupingLanguageENList.Add(polSourceGroupingLanguageEN);
            }

            try
            {
                dbCSSPDB.PolSourceGroupingLanguages.AddRange(polSourceGroupingLanguageENList);
                dbCSSPDB.SaveChanges();
            }
            catch (Exception)
            {
                int a = 234;
                a = a + 1;
            }

            Console.WriteLine($"Saved in db PolSourceGroupingLanguageENList ...");


            List<PolSourceGroupingLanguage> polSourceGroupingLanguageFRList = new List<PolSourceGroupingLanguage>();

            Console.WriteLine($"Starting Reading PolSourceGroupingLanguageFRList ...");

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileReadService.GroupChoiceChildLevelList)
            {

                PolSourceGroupingLanguage polSourceGroupingLanguageFR = new PolSourceGroupingLanguage()
                {
                    DBCommand = DBCommandEnum.Original,
                    Language = LanguageEnum.fr,
                    Description = groupChoiceChildLevel.DescFR,
                    TranslationStatusDescription = TranslationStatusEnum.Translated,
                    Init = groupChoiceChildLevel.InitFR,
                    TranslationStatusInit = TranslationStatusEnum.Translated,
                    PolSourceGroupingID = (from c in polSourceGroupingListToCreate
                                           where c.CSSPID.ToString() == groupChoiceChildLevel.CSSPID
                                           select c.PolSourceGroupingID).FirstOrDefault(),
                    Report = groupChoiceChildLevel.ReportFR,
                    TranslationStatusReport = TranslationStatusEnum.Translated,
                    Text = groupChoiceChildLevel.TextFR,
                    TranslationStatusText = TranslationStatusEnum.Translated,
                    SourceName = groupChoiceChildLevel.FR,
                    TranslationStatusSourceName = TranslationStatusEnum.Translated,
                    SourceNameOrder = 0,
                    LastUpdateDate_UTC = DateTime.UtcNow,
                    LastUpdateContactTVItemID = 2,
                };

                polSourceGroupingLanguageFRList.Add(polSourceGroupingLanguageFR);
            }


            try
            {
                dbCSSPDB.PolSourceGroupingLanguages.AddRange(polSourceGroupingLanguageFRList);
                dbCSSPDB.SaveChanges();
            }
            catch (Exception)
            {
                int a = 234;
                a = a + 1;
            }

            Console.WriteLine($"Saved in db PolSourceGroupingLanguageFRList ...");

            Console.WriteLine($"doing reordering ...");

            List<PolSourceGrouping> polSourceGroupingList = (from c in dbCSSPDB.PolSourceGroupings
                                                             select c).ToList();

            List<PolSourceGroupingLanguage> polSourceGroupingLanguageList = (from c in dbCSSPDB.PolSourceGroupingLanguages
                                                                             select c).ToList();

            foreach (PolSourceGrouping polSourceGrouping in polSourceGroupingList)
            {
                if (polSourceGrouping.CSSPID % 100 == 0)
                {
                    Console.WriteLine($"doing reordering {polSourceGrouping.CSSPID} ...");

                    PolSourceGrouping polSourceGroupingStart = polSourceGrouping;

                    string StartStr = polSourceGroupingStart.CSSPID.ToString().Substring(0, 3);

                    List<PolSourceGroupingLanguage> polSourceGroupingLanguageStartList = (from c in polSourceGroupingLanguageList
                                                                                          where c.PolSourceGroupingID == polSourceGroupingStart.PolSourceGroupingID
                                                                                          select c).ToList();

                    foreach (PolSourceGroupingLanguage polSourceGroupingLanguageStart in polSourceGroupingLanguageStartList)
                    {
                        polSourceGroupingLanguageStart.SourceName = polSourceGroupingLanguageStart.SourceName.Trim();
                        polSourceGroupingLanguageStart.SourceNameOrder = 0;
                    }

                    List<PolSourceGroupingLanguage> polSourceGroupingLanguageChildENList = (from c in polSourceGroupingList
                                                                                          from cl in polSourceGroupingLanguageList
                                                                                          where c.PolSourceGroupingID == cl.PolSourceGroupingID
                                                                                          && cl.Language == LanguageEnum.en
                                                                                          && c.CSSPID.ToString().StartsWith(StartStr)
                                                                                          && c.PolSourceGroupingID != polSourceGroupingStart.PolSourceGroupingID
                                                                                          orderby cl.SourceName
                                                                                          select cl).ToList();

                    int Ordinal = 1;
                    foreach (PolSourceGroupingLanguage polSourceGroupingLanguageChildEN in polSourceGroupingLanguageChildENList)
                    {
                        polSourceGroupingLanguageChildEN.SourceName = polSourceGroupingLanguageChildEN.SourceName.Trim();
                        polSourceGroupingLanguageChildEN.SourceNameOrder = Ordinal;
                        Ordinal += 1;
                    }

                    List<PolSourceGroupingLanguage> polSourceGroupingLanguageChildFRList = (from c in polSourceGroupingList
                                                                                          from cl in polSourceGroupingLanguageList
                                                                                          where c.PolSourceGroupingID == cl.PolSourceGroupingID
                                                                                          && cl.Language == LanguageEnum.fr
                                                                                          && c.CSSPID.ToString().StartsWith(StartStr)
                                                                                          && c.PolSourceGroupingID != polSourceGroupingStart.PolSourceGroupingID
                                                                                          orderby cl.SourceName
                                                                                          select cl).ToList();

                    Ordinal = 1;
                    foreach (PolSourceGroupingLanguage polSourceGroupingLanguageChildFR in polSourceGroupingLanguageChildFRList)
                    {
                        polSourceGroupingLanguageChildFR.SourceName = polSourceGroupingLanguageChildFR.SourceName.Trim();
                        polSourceGroupingLanguageChildFR.SourceNameOrder = Ordinal;
                        Ordinal += 1;
                    }

                }
            }

            try
            {
                dbCSSPDB.SaveChanges();
            }
            catch (Exception)
            {
                int a = 34;
                a = a + 1;
            }

            Console.WriteLine($"Ordering saved in db ...");


            Console.WriteLine("");
            Console.WriteLine($"Done ...");
            Console.WriteLine("");
            Console.WriteLine("Generate Finished ...");

            return true;
        }
    }
}
