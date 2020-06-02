using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using System.Text;
using CSSPEnums;
using System.Security.Principal;
using System.Threading;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace CSSPWebAPIs.Tests
{
    public partial class TestHelper
    {
        #region Variables
        StringBuilder sb = new StringBuilder();
        Random random = new Random();
        #endregion Variables

        #region Properties
        public CSSPDBContext dbTestDB { get; set; }
        public CSSPDBContext dbMemoryTestDB { get; set; }
        public LanguageEnum LanguageRequest { get; set; }
        public List<CultureInfo> AllowableCulture { get; set; }
        public int ContactID = 2;
        public CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TestHelper()
        {

            AllowableCulture = new List<CultureInfo>() { new CultureInfo("en-CA"), new CultureInfo("fr-CA")/*, new CultureInfo("es-ES")*/ };

            ChangeCulture(new CultureInfo("en-CA"));

            //dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB);
            //dbMemoryTestDB = new CSSPDBContext(DatabaseTypeEnum.MemoryTestDB);
            random = new Random();

            //FillMemoryTestDBWithTestDBData();
        }

        #endregion Constructors

        #region Functions public
        public void ChangeCulture(CultureInfo culture)
        {
            LanguageRequest = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            if (culture.TwoLetterISOLanguageName == "fr")
            {
                LanguageRequest = LanguageEnum.fr;
            }
            else if (culture.TwoLetterISOLanguageName == "es")
            {
                LanguageRequest = LanguageEnum.es;
            }
            else
            {
                LanguageRequest = LanguageEnum.en;
            }
        }
        //public Contact GetRandomContact()
        //{

        //    ContactService contactService = new ContactService(LanguageRequest, dbMemoryTestDB, ContactID);

        //    int Count = contactService.GetRead().Count();

        //    if (Count == 0)
        //    {
        //        return new Contact() { ContactID = 0 };
        //    }

        //    int skip = random.Next(0, Count);

        //    Contact contact = contactService.GetRead().Skip(skip).Take(1).FirstOrDefault<Contact>();

        //    return contact;
        //}
        public DateTime GetRandomDateTime()
        {
            int Year = random.Next(2005, 2050);
            int Month = random.Next(1, 12);
            int Day = random.Next(1, 28);
            int Hour = random.Next(1, 24);
            int Minute = random.Next(0, 60);
            int Second = random.Next(0, 60);

            return new DateTime(Year, Month, Day, Hour, Minute, Second);
        }
        public double GetRandomDouble(double min, double max)
        {
            return min + (random.NextDouble() * (max - min));
        }
        public string GetRandomEmail()
        {
            string Part1 = GetRandomString("", 12);
            string Part2 = GetRandomString("", 12);
            string Part3 = GetRandomString("", 3);
            string Part4 = GetRandomString("", 2);
            string Part5 = GetRandomString("", 2);

            string Email = Part1 + "." + Part2 + "@" + Part3 + "." + Part4 + "." + Part5;

            return Email;
        }
        public float GetRandomFloat(float min, float max)
        {
            return (float)(min + (random.NextDouble() * (max - min)));
        }
        public Guid GetRandomGuid()
        {
            Guid guid = new Guid();

            return guid;
        }
        public int GetRandomInt(int min, int max)
        {
            int randomInt = 0;
            randomInt = random.Next(min, max);

            return randomInt;
        }
        public string GetRandomPassword()
        {
            string Part1 = GetRandomString("", 7);
            int Part2 = GetRandomInt(1, 20);

            string Password = Part1 + Part2 + "!";

            return Password;
        }
        public string GetRandomString(string startString, int length)
        {
            string retStr = startString;

            if (retStr.Length > length)
            {
                retStr = retStr.Substring(0, length);
            }
            else
            {
                int Count = length - retStr.Length;
                for (int i = 0; i < Count; i++)
                {
                    retStr += (char)random.Next(97, 122);
                }
            }

            return retStr;
        }
        public string GetRandomTel()
        {
            string Part1 = GetRandomInt(1, 1).ToString();
            string Part2 = GetRandomInt(506, 506).ToString();
            string Part3 = GetRandomInt(200, 900).ToString();
            string Part4 = GetRandomInt(1000, 9000).ToString();

            string Email = Part1 + " (" + Part2 + ") " + Part3 + "-" + Part4;

            return Email;
        }
        //public TVItem GetRandomTVItem(TVTypeEnum TVType)
        //{
        //    TVItemService tvItemService = new TVItemService(LanguageRequest, dbMemoryTestDB, ContactID);

        //    int Count = tvItemService.GetRead().Where(c => c.TVType == TVType).Count();

        //    if (Count == 0)
        //    {
        //        return new TVItem() { TVItemID = 0 };
        //    }

        //    int skip = random.Next(0, Count);

        //    return tvItemService.GetRead().Where(c => c.TVType == TVType).Skip(skip).Take(1).FirstOrDefault<TVItem>();
        //}
        public int GetRandomEnumType(Type enumType)
        {
            int retValue = 0;

            int count = Enum.GetNames(enumType).Count();

            int[] valArr = Enum.GetValues(enumType) as int[];

            List<int> valList = (from c in valArr.ToList()
                                 where c > 0
                                 orderby c
                                 select c).ToList();

            int Min = valList.ToList().Skip(1).FirstOrDefault();
            int Max = valList.ToList().OrderByDescending(c => c).FirstOrDefault();

            retValue = GetRandomInt(Min, Max);
            while (!valList.Where(c => c == retValue).Any())
            {
                retValue = GetRandomInt(Min, Max);
            }

            return retValue;
        }
        #endregion Functions public

        #region Functions private
        private void FillMemoryTestDBWithTestDBData()
        {
            #region TVItems
            List<TVItem> TVItemList = dbTestDB.TVItems.AsNoTracking().OrderBy(c => c.TVItemID).ToList();

            foreach (TVItem TVItem in TVItemList)
            {
                dbMemoryTestDB.TVItems.Add(TVItem);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion TVItems
            #region TVItemLanguages
            List<TVItemLanguage> TVItemLanguageList = dbTestDB.TVItemLanguages.AsNoTracking().OrderBy(c => c.TVItemLanguageID).ToList();

            foreach (TVItemLanguage TVItemLanguage in TVItemLanguageList)
            {
                dbMemoryTestDB.TVItemLanguages.Add(TVItemLanguage);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion TVItemLanguages
            #region Contacts
            List<Contact> ContactList = dbTestDB.Contacts.AsNoTracking().OrderBy(c => c.ContactID).ToList();

            foreach (Contact Contact in ContactList)
            {
                dbMemoryTestDB.Contacts.Add(Contact);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion Contacts
            //#region ContactLogins
            //List<ContactLogin> ContactLoginList = dbTestDB.ContactLogins.AsNoTracking().OrderBy(c => c.ContactLoginID).ToList();

            //foreach (ContactLogin ContactLogin in ContactLoginList)
            //{
            //    dbMemoryTestDB.ContactLogins.Add(ContactLogin);

            //    try
            //    {
            //        dbMemoryTestDB.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
            //    }
            //}
            //#endregion ContactLogins
            #region ClimateSites
            List<ClimateSite> ClimateSiteList = dbTestDB.ClimateSites.AsNoTracking().OrderBy(c => c.ClimateSiteID).ToList();

            foreach (ClimateSite ClimateSite in ClimateSiteList)
            {
                dbMemoryTestDB.ClimateSites.Add(ClimateSite);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion ClimateSites
            #region ClimateDataValues
            List<ClimateDataValue> ClimateDataValueList = dbTestDB.ClimateDataValues.AsNoTracking().OrderBy(c => c.ClimateDataValueID).ToList();

            foreach (ClimateDataValue ClimateDataValue in ClimateDataValueList)
            {
                dbMemoryTestDB.ClimateDataValues.Add(ClimateDataValue);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion ClimateDataValues
            #region HydrometricSites
            List<HydrometricSite> HydrometricSiteList = dbTestDB.HydrometricSites.AsNoTracking().OrderBy(c => c.HydrometricSiteID).ToList();

            foreach (HydrometricSite HydrometricSite in HydrometricSiteList)
            {
                dbMemoryTestDB.HydrometricSites.Add(HydrometricSite);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion HydrometricSites
            #region HydrometricDataValues
            List<HydrometricDataValue> HydrometricDataValueList = dbTestDB.HydrometricDataValues.AsNoTracking().OrderBy(c => c.HydrometricDataValueID).ToList();

            foreach (HydrometricDataValue HydrometricDataValue in HydrometricDataValueList)
            {
                dbMemoryTestDB.HydrometricDataValues.Add(HydrometricDataValue);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion HydrometricDataValues
            #region RatingCurves
            List<RatingCurve> RatingCurveList = dbTestDB.RatingCurves.AsNoTracking().OrderBy(c => c.RatingCurveID).ToList();

            foreach (RatingCurve RatingCurve in RatingCurveList)
            {
                dbMemoryTestDB.RatingCurves.Add(RatingCurve);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion RatingCurves
            #region RatingCurveValues
            List<RatingCurveValue> RatingCurveValueList = dbTestDB.RatingCurveValues.AsNoTracking().OrderBy(c => c.RatingCurveValueID).ToList();

            foreach (RatingCurveValue RatingCurveValue in RatingCurveValueList)
            {
                dbMemoryTestDB.RatingCurveValues.Add(RatingCurveValue);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion RatingCurveValues
            #region Infrastructures
            List<Infrastructure> InfrastructureList = dbTestDB.Infrastructures.AsNoTracking().OrderBy(c => c.InfrastructureID).ToList();

            foreach (Infrastructure Infrastructure in InfrastructureList)
            {
                dbMemoryTestDB.Infrastructures.Add(Infrastructure);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion Infrastructures
            #region InfrastructureLanguages
            List<InfrastructureLanguage> InfrastructureLanguageList = dbTestDB.InfrastructureLanguages.AsNoTracking().OrderBy(c => c.InfrastructureLanguageID).ToList();

            foreach (InfrastructureLanguage InfrastructureLanguage in InfrastructureLanguageList)
            {
                dbMemoryTestDB.InfrastructureLanguages.Add(InfrastructureLanguage);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion InfrastructureLanguages
            #region BoxModels
            List<BoxModel> BoxModelList = dbTestDB.BoxModels.AsNoTracking().OrderBy(c => c.BoxModelID).ToList();

            foreach (BoxModel BoxModel in BoxModelList)
            {
                dbMemoryTestDB.BoxModels.Add(BoxModel);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion BoxModels
            #region BoxModelLanguages
            List<BoxModelLanguage> BoxModelLanguageList = dbTestDB.BoxModelLanguages.AsNoTracking().OrderBy(c => c.BoxModelLanguageID).ToList();

            foreach (BoxModelLanguage BoxModelLanguage in BoxModelLanguageList)
            {
                dbMemoryTestDB.BoxModelLanguages.Add(BoxModelLanguage);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion BoxModelLanguages
            #region BoxModelResults
            List<BoxModelResult> BoxModelResultList = dbTestDB.BoxModelResults.AsNoTracking().OrderBy(c => c.BoxModelResultID).ToList();

            foreach (BoxModelResult BoxModelResult in BoxModelResultList)
            {
                dbMemoryTestDB.BoxModelResults.Add(BoxModelResult);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion BoxModelResults
            #region VPScenarios
            List<VPScenario> VPScenarioList = dbTestDB.VPScenarios.AsNoTracking().OrderBy(c => c.VPScenarioID).ToList();

            foreach (VPScenario VPScenario in VPScenarioList)
            {
                dbMemoryTestDB.VPScenarios.Add(VPScenario);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion VPScenarios
            #region VPScenarioLanguages
            List<VPScenarioLanguage> VPScenarioLanguageList = dbTestDB.VPScenarioLanguages.AsNoTracking().OrderBy(c => c.VPScenarioLanguageID).ToList();

            foreach (VPScenarioLanguage VPScenarioLanguage in VPScenarioLanguageList)
            {
                dbMemoryTestDB.VPScenarioLanguages.Add(VPScenarioLanguage);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion VPScenarioLanguages
            #region VPAmbients
            List<VPAmbient> VPAmbientList = dbTestDB.VPAmbients.AsNoTracking().OrderBy(c => c.VPAmbientID).ToList();

            foreach (VPAmbient VPAmbient in VPAmbientList)
            {
                dbMemoryTestDB.VPAmbients.Add(VPAmbient);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion VPAmbients
            #region VPResults
            List<VPResult> VPResultList = dbTestDB.VPResults.AsNoTracking().OrderBy(c => c.VPResultID).ToList();

            foreach (VPResult VPResult in VPResultList)
            {
                dbMemoryTestDB.VPResults.Add(VPResult);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion VPResults
            #region MWQMSites
            List<MWQMSite> MWQMSiteList = dbTestDB.MWQMSites.AsNoTracking().OrderBy(c => c.MWQMSiteID).ToList();

            foreach (MWQMSite MWQMSite in MWQMSiteList)
            {
                dbMemoryTestDB.MWQMSites.Add(MWQMSite);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion MWQMSites
            #region MWQMSiteStartEndDates
            List<MWQMSiteStartEndDate> MWQMSiteStartEndDateList = dbTestDB.MWQMSiteStartEndDates.AsNoTracking().OrderBy(c => c.MWQMSiteStartEndDateID).ToList();

            foreach (MWQMSiteStartEndDate MWQMSiteStartEndDate in MWQMSiteStartEndDateList)
            {
                dbMemoryTestDB.MWQMSiteStartEndDates.Add(MWQMSiteStartEndDate);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion MWQMSiteStartEndDates
            #region PolSourceSites
            List<PolSourceSite> PolSourceSiteList = dbTestDB.PolSourceSites.AsNoTracking().OrderBy(c => c.PolSourceSiteID).ToList();

            foreach (PolSourceSite PolSourceSite in PolSourceSiteList)
            {
                dbMemoryTestDB.PolSourceSites.Add(PolSourceSite);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion PolSourceSites
            #region PolSourceObservations
            List<PolSourceObservation> PolSourceObservationList = dbTestDB.PolSourceObservations.AsNoTracking().OrderBy(c => c.PolSourceObservationID).ToList();

            foreach (PolSourceObservation PolSourceObservation in PolSourceObservationList)
            {
                dbMemoryTestDB.PolSourceObservations.Add(PolSourceObservation);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion PolSourceObservations
            #region PolSourceObservationIssues
            List<PolSourceObservationIssue> PolSourceObservationIssueList = dbTestDB.PolSourceObservationIssues.AsNoTracking().OrderBy(c => c.PolSourceObservationIssueID).ToList();

            foreach (PolSourceObservationIssue PolSourceObservationIssue in PolSourceObservationIssueList)
            {
                dbMemoryTestDB.PolSourceObservationIssues.Add(PolSourceObservationIssue);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion PolSourceObservationIssues
            #region SamplingPlans
            List<SamplingPlan> SamplingPlanList = dbTestDB.SamplingPlans.AsNoTracking().OrderBy(c => c.SamplingPlanID).ToList();

            foreach (SamplingPlan SamplingPlan in SamplingPlanList)
            {
                dbMemoryTestDB.SamplingPlans.Add(SamplingPlan);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion SamplingPlans
            #region SamplingPlanSubsectors
            List<SamplingPlanSubsector> SamplingPlanSubsectorList = dbTestDB.SamplingPlanSubsectors.AsNoTracking().OrderBy(c => c.SamplingPlanSubsectorID).ToList();

            foreach (SamplingPlanSubsector SamplingPlanSubsector in SamplingPlanSubsectorList)
            {
                dbMemoryTestDB.SamplingPlanSubsectors.Add(SamplingPlanSubsector);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion SamplingPlanSubsectors
            #region SamplingPlanSubsectorSites
            List<SamplingPlanSubsectorSite> SamplingPlanSubsectorSiteList = dbTestDB.SamplingPlanSubsectorSites.AsNoTracking().OrderBy(c => c.SamplingPlanSubsectorSiteID).ToList();

            foreach (SamplingPlanSubsectorSite SamplingPlanSubsectorSite in SamplingPlanSubsectorSiteList)
            {
                dbMemoryTestDB.SamplingPlanSubsectorSites.Add(SamplingPlanSubsectorSite);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion SamplingPlanSubsectorSites
            #region MWQMRuns
            List<MWQMRun> MWQMRunList = dbTestDB.MWQMRuns.AsNoTracking().OrderBy(c => c.MWQMRunID).ToList();

            foreach (MWQMRun MWQMRun in MWQMRunList)
            {
                dbMemoryTestDB.MWQMRuns.Add(MWQMRun);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion MWQMRuns
            #region MWQMRunLanguages
            List<MWQMRunLanguage> MWQMRunLanguageList = dbTestDB.MWQMRunLanguages.AsNoTracking().OrderBy(c => c.MWQMRunLanguageID).ToList();

            foreach (MWQMRunLanguage MWQMRunLanguage in MWQMRunLanguageList)
            {
                dbMemoryTestDB.MWQMRunLanguages.Add(MWQMRunLanguage);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion MWQMRunLanguages
            #region UseOfSites
            List<UseOfSite> UseOfSiteList = dbTestDB.UseOfSites.AsNoTracking().OrderBy(c => c.UseOfSiteID).ToList();

            foreach (UseOfSite UseOfSite in UseOfSiteList)
            {
                dbMemoryTestDB.UseOfSites.Add(UseOfSite);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion UseOfSites
            #region MWQMSamples
            List<MWQMSample> MWQMSampleList = dbTestDB.MWQMSamples.AsNoTracking().OrderBy(c => c.MWQMSampleID).ToList();

            foreach (MWQMSample MWQMSample in MWQMSampleList)
            {
                dbMemoryTestDB.MWQMSamples.Add(MWQMSample);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion MWQMSamples
            #region MWQMSampleLanguages
            List<MWQMSampleLanguage> MWQMSampleLanguageList = dbTestDB.MWQMSampleLanguages.AsNoTracking().OrderBy(c => c.MWQMSampleLanguageID).ToList();

            foreach (MWQMSampleLanguage MWQMSampleLanguage in MWQMSampleLanguageList)
            {
                dbMemoryTestDB.MWQMSampleLanguages.Add(MWQMSampleLanguage);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion MWQMSampleLanguages
            #region MikeScenarios
            List<MikeScenario> MikeScenarioList = dbTestDB.MikeScenarios.AsNoTracking().OrderBy(c => c.MikeScenarioID).ToList();

            foreach (MikeScenario MikeScenario in MikeScenarioList)
            {
                dbMemoryTestDB.MikeScenarios.Add(MikeScenario);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion MikeScenarios
            #region MikeBoundaryConditions
            List<MikeBoundaryCondition> MikeBoundaryConditionList = dbTestDB.MikeBoundaryConditions.AsNoTracking().OrderBy(c => c.MikeBoundaryConditionID).ToList();

            foreach (MikeBoundaryCondition MikeBoundaryCondition in MikeBoundaryConditionList)
            {
                dbMemoryTestDB.MikeBoundaryConditions.Add(MikeBoundaryCondition);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion MikeBoundaryConditions
            #region MikeSources
            List<MikeSource> MikeSourceList = dbTestDB.MikeSources.AsNoTracking().OrderBy(c => c.MikeSourceID).ToList();

            foreach (MikeSource MikeSource in MikeSourceList)
            {
                dbMemoryTestDB.MikeSources.Add(MikeSource);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion MikeSources
            #region MikeSourceStartEnds
            List<MikeSourceStartEnd> MikeSourceStartEndList = dbTestDB.MikeSourceStartEnds.AsNoTracking().OrderBy(c => c.MikeSourceStartEndID).ToList();

            foreach (MikeSourceStartEnd MikeSourceStartEnd in MikeSourceStartEndList)
            {
                dbMemoryTestDB.MikeSourceStartEnds.Add(MikeSourceStartEnd);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion MikeSourceStartEnds
            #region LabSheets
            List<LabSheet> LabSheetList = dbTestDB.LabSheets.AsNoTracking().OrderBy(c => c.LabSheetID).ToList();

            foreach (LabSheet LabSheet in LabSheetList)
            {
                dbMemoryTestDB.LabSheets.Add(LabSheet);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion LabSheets
            #region LabSheetDetails
            List<LabSheetDetail> LabSheetDetailList = dbTestDB.LabSheetDetails.AsNoTracking().OrderBy(c => c.LabSheetDetailID).ToList();

            foreach (LabSheetDetail LabSheetDetail in LabSheetDetailList)
            {
                dbMemoryTestDB.LabSheetDetails.Add(LabSheetDetail);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion LabSheetDetails
            #region LabSheetTubeMPNDetails
            List<LabSheetTubeMPNDetail> LabSheetTubeMPNDetailList = dbTestDB.LabSheetTubeMPNDetails.AsNoTracking().OrderBy(c => c.LabSheetTubeMPNDetailID).ToList();

            foreach (LabSheetTubeMPNDetail LabSheetTubeMPNDetail in LabSheetTubeMPNDetailList)
            {
                dbMemoryTestDB.LabSheetTubeMPNDetails.Add(LabSheetTubeMPNDetail);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion LabSheetTubeMPNDetails
            #region Addresss
            List<Address> AddressList = dbTestDB.Addresses.AsNoTracking().OrderBy(c => c.AddressID).ToList();

            foreach (Address Address in AddressList)
            {
                dbMemoryTestDB.Addresses.Add(Address);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion Addresss
            #region Emails
            List<Email> EmailList = dbTestDB.Emails.AsNoTracking().OrderBy(c => c.EmailID).ToList();

            foreach (Email Email in EmailList)
            {
                dbMemoryTestDB.Emails.Add(Email);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion Emails
            #region Tels
            List<Tel> TelList = dbTestDB.Tels.AsNoTracking().OrderBy(c => c.TelID).ToList();

            foreach (Tel Tel in TelList)
            {
                dbMemoryTestDB.Tels.Add(Tel);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion Tels
            #region TVItemLinks
            List<TVItemLink> TVItemLinkList = dbTestDB.TVItemLinks.AsNoTracking().OrderBy(c => c.TVItemLinkID).ToList();

            foreach (TVItemLink TVItemLink in TVItemLinkList)
            {
                dbMemoryTestDB.TVItemLinks.Add(TVItemLink);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion TVItemLinks
            #region MWQMSubsectors
            List<MWQMSubsector> MWQMSubsectorList = dbTestDB.MWQMSubsectors.AsNoTracking().OrderBy(c => c.MWQMSubsectorID).ToList();

            foreach (MWQMSubsector MWQMSubsector in MWQMSubsectorList)
            {
                dbMemoryTestDB.MWQMSubsectors.Add(MWQMSubsector);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion MWQMSubsectors
            #region MWQMSubsectorLanguages
            List<MWQMSubsectorLanguage> MWQMSubsectorLanguageList = dbTestDB.MWQMSubsectorLanguages.AsNoTracking().OrderBy(c => c.MWQMSubsectorLanguageID).ToList();

            foreach (MWQMSubsectorLanguage MWQMSubsectorLanguage in MWQMSubsectorLanguageList)
            {
                dbMemoryTestDB.MWQMSubsectorLanguages.Add(MWQMSubsectorLanguage);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion MWQMSubsectorLanguages
            #region TVFiles
            List<TVFile> TVFileList = dbTestDB.TVFiles.AsNoTracking().OrderBy(c => c.TVFileID).ToList();

            foreach (TVFile TVFile in TVFileList)
            {
                dbMemoryTestDB.TVFiles.Add(TVFile);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion TVFiles
            #region TVFileLanguages
            List<TVFileLanguage> TVFileLanguageList = dbTestDB.TVFileLanguages.AsNoTracking().OrderBy(c => c.TVFileLanguageID).ToList();

            foreach (TVFileLanguage TVFileLanguage in TVFileLanguageList)
            {
                dbMemoryTestDB.TVFileLanguages.Add(TVFileLanguage);

                try
                {
                    dbMemoryTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.Equal("", ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                }
            }
            #endregion TVFileLanguages

        }
        #endregion Functions private


    }
}
