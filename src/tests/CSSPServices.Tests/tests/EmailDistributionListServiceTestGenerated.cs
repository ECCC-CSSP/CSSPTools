 /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.Security.Principal;
using System.Globalization;
using CSSPServices.Resources;
using CSSPModels.Resources;
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{

    public partial class EmailDistributionListServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private EmailDistributionListService emailDistributionListService { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListServiceTest() : base()
        {
            //emailDistributionListService = new EmailDistributionListService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Fact]
        public void EmailDistributionList_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    EmailDistributionList emailDistributionList = GetFilledRandomEmailDistributionList("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = emailDistributionListService.GetEmailDistributionListList().Count();

                    Assert.Equal(count, (from c in dbTestDB.EmailDistributionLists select c).Count());

                    emailDistributionListService.Add(emailDistributionList);
                    if (emailDistributionList.HasErrors)
                    {
                        Assert.Equal("", emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.True(emailDistributionListService.GetEmailDistributionListList().Where(c => c == emailDistributionList).Any());
                    emailDistributionListService.Update(emailDistributionList);
                    if (emailDistributionList.HasErrors)
                    {
                        Assert.Equal("", emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count + 1, emailDistributionListService.GetEmailDistributionListList().Count());
                    emailDistributionListService.Delete(emailDistributionList);
                    if (emailDistributionList.HasErrors)
                    {
                        Assert.Equal("", emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count, emailDistributionListService.GetEmailDistributionListList().Count());

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Fact]
        public void EmailDistributionList_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = emailDistributionListService.GetEmailDistributionListList().Count();

                    EmailDistributionList emailDistributionList = GetFilledRandomEmailDistributionList("");

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // emailDistributionList.EmailDistributionListID   (Int32)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.EmailDistributionListID = 0;
                    emailDistributionListService.Update(emailDistributionList);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListID"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.EmailDistributionListID = 10000000;
                    emailDistributionListService.Update(emailDistributionList);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListID", emailDistributionList.EmailDistributionListID.ToString()), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Country)]
                    // emailDistributionList.ParentTVItemID   (Int32)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.ParentTVItemID = 0;
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ParentTVItemID", emailDistributionList.ParentTVItemID.ToString()), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.ParentTVItemID = 1;
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.Equal(string.Format(CSSPServicesRes._IsNotOfType_, "ParentTVItemID", "Country"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // emailDistributionList.Ordinal   (Int32)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.Ordinal = -1;
                    Assert.False(emailDistributionListService.Add(emailDistributionList));
                    Assert.Equal(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "1000"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, emailDistributionListService.GetEmailDistributionListList().Count());
                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.Ordinal = 1001;
                    Assert.False(emailDistributionListService.Add(emailDistributionList));
                    Assert.Equal(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "1000"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, emailDistributionListService.GetEmailDistributionListList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // emailDistributionList.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.LastUpdateDate_UTC = new DateTime();
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.Equal(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // emailDistributionList.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.LastUpdateContactTVItemID = 0;
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", emailDistributionList.LastUpdateContactTVItemID.ToString()), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.LastUpdateContactTVItemID = 1;
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.Equal(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // emailDistributionList.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // emailDistributionList.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated Properties

        #region Tests Generated for GetEmailDistributionListWithEmailDistributionListID(emailDistributionList.EmailDistributionListID)
        [Fact]
        public void GetEmailDistributionListWithEmailDistributionListID__emailDistributionList_EmailDistributionListID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    EmailDistributionList emailDistributionList = (from c in dbTestDB.EmailDistributionLists select c).FirstOrDefault();
                    Assert.NotNull(emailDistributionList);

                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListWithEmailDistributionListID(emailDistributionList.EmailDistributionListID)

        #region Tests Generated for GetEmailDistributionListList()
        [Fact]
        public void GetEmailDistributionListList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    EmailDistributionList emailDistributionList = (from c in dbTestDB.EmailDistributionLists select c).FirstOrDefault();
                    Assert.NotNull(emailDistributionList);

                    List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                    emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).Take(200).ToList();

                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList()

        #region Tests Generated for GetEmailDistributionListList() Skip Take
        [Fact]
        public void GetEmailDistributionListList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 1, 1, "", "");

                    List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                    emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).Skip(1).Take(1).ToList();

                        List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                        emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        CheckEmailDistributionListFields(emailDistributionListList);
                        Assert.Equal(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() Skip Take

        #region Tests Generated for GetEmailDistributionListList() Skip Take Asc
        [Fact]
        public void GetEmailDistributionListList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 1, 1,  "EmailDistributionListID", "", "");

                    List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                    emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).OrderBy(c => c.EmailDistributionListID).Skip(1).Take(1).ToList();

                        List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                        emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        CheckEmailDistributionListFields(emailDistributionListList);
                        Assert.Equal(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() Skip Take Asc

        #region Tests Generated for GetEmailDistributionListList() Skip Take 2 Asc
        [Fact]
        public void GetEmailDistributionListList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 1, 1, "EmailDistributionListID,ParentTVItemID", "", "");

                    List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                    emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).OrderBy(c => c.EmailDistributionListID).ThenBy(c => c.ParentTVItemID).Skip(1).Take(1).ToList();

                        List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                        emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        CheckEmailDistributionListFields(emailDistributionListList);
                        Assert.Equal(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() Skip Take 2 Asc

        #region Tests Generated for GetEmailDistributionListList() Skip Take Asc Where
        [Fact]
        public void GetEmailDistributionListList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListID", "", "EmailDistributionListID,EQ,4");

                    List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                    emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).Where(c => c.EmailDistributionListID == 4).OrderBy(c => c.EmailDistributionListID).Skip(0).Take(1).ToList();

                        List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                        emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        CheckEmailDistributionListFields(emailDistributionListList);
                        Assert.Equal(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() Skip Take Asc Where

        #region Tests Generated for GetEmailDistributionListList() Skip Take Asc 2 Where
        [Fact]
        public void GetEmailDistributionListList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                     EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                     emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListID", "", "EmailDistributionListID,GT,2|EmailDistributionListID,LT,5");

                     List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                     emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).Where(c => c.EmailDistributionListID > 2 && c.EmailDistributionListID < 5).Skip(0).Take(1).OrderBy(c => c.EmailDistributionListID).ToList();

                        List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                        emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        CheckEmailDistributionListFields(emailDistributionListList);
                        Assert.Equal(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() Skip Take Asc 2 Where

        #region Tests Generated for GetEmailDistributionListList() Skip Take Desc
        [Fact]
        public void GetEmailDistributionListList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 1, 1, "", "EmailDistributionListID", "");

                    List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                    emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).OrderByDescending(c => c.EmailDistributionListID).Skip(1).Take(1).ToList();

                        List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                        emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        CheckEmailDistributionListFields(emailDistributionListList);
                        Assert.Equal(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() Skip Take Desc

        #region Tests Generated for GetEmailDistributionListList() Skip Take 2 Desc
        [Fact]
        public void GetEmailDistributionListList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 1, 1, "", "EmailDistributionListID,ParentTVItemID", "");

                    List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                    emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).OrderByDescending(c => c.EmailDistributionListID).ThenByDescending(c => c.ParentTVItemID).Skip(1).Take(1).ToList();

                        List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                        emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        CheckEmailDistributionListFields(emailDistributionListList);
                        Assert.Equal(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() Skip Take 2 Desc

        #region Tests Generated for GetEmailDistributionListList() Skip Take Desc Where
        [Fact]
        public void GetEmailDistributionListList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListID", "", "EmailDistributionListID,EQ,4");

                    List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                    emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).Where(c => c.EmailDistributionListID == 4).OrderByDescending(c => c.EmailDistributionListID).Skip(0).Take(1).ToList();

                        List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                        emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        CheckEmailDistributionListFields(emailDistributionListList);
                        Assert.Equal(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() Skip Take Desc Where

        #region Tests Generated for GetEmailDistributionListList() Skip Take Desc 2 Where
        [Fact]
        public void GetEmailDistributionListList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 0, 1, "", "EmailDistributionListID", "EmailDistributionListID,GT,2|EmailDistributionListID,LT,5");

                    List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                    emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).Where(c => c.EmailDistributionListID > 2 && c.EmailDistributionListID < 5).OrderByDescending(c => c.EmailDistributionListID).Skip(0).Take(1).ToList();

                        List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                        emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        CheckEmailDistributionListFields(emailDistributionListList);
                        Assert.Equal(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() Skip Take Desc 2 Where

        #region Tests Generated for GetEmailDistributionListList() 2 Where
        [Fact]
        public void GetEmailDistributionListList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "EmailDistributionListID,GT,2|EmailDistributionListID,LT,5");

                    List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                    emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).Where(c => c.EmailDistributionListID > 2 && c.EmailDistributionListID < 5).ToList();

                        List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                        emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        CheckEmailDistributionListFields(emailDistributionListList);
                        Assert.Equal(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() 2 Where

        #region Functions private
        private void CheckEmailDistributionListFields(List<EmailDistributionList> emailDistributionListList)
        {
            Assert.NotNull(emailDistributionListList[0].EmailDistributionListID);
            Assert.NotNull(emailDistributionListList[0].ParentTVItemID);
            Assert.NotNull(emailDistributionListList[0].Ordinal);
            Assert.NotNull(emailDistributionListList[0].LastUpdateDate_UTC);
            Assert.NotNull(emailDistributionListList[0].LastUpdateContactTVItemID);
            Assert.NotNull(emailDistributionListList[0].HasErrors);
        }
        private EmailDistributionList GetFilledRandomEmailDistributionList(string OmitPropName)
        {
            EmailDistributionList emailDistributionList = new EmailDistributionList();

            if (OmitPropName != "ParentTVItemID") emailDistributionList.ParentTVItemID = 5;
            if (OmitPropName != "Ordinal") emailDistributionList.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionList.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionList.LastUpdateContactTVItemID = 2;

            return emailDistributionList;
        }
        #endregion Functions private
    }
}
