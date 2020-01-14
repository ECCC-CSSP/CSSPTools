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

    public partial class ResetPasswordServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ResetPasswordService resetPasswordService { get; set; }
        #endregion Properties

        #region Constructors
        public ResetPasswordServiceTest() : base()
        {
            //resetPasswordService = new ResetPasswordService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Fact]
        public void ResetPassword_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ResetPassword resetPassword = GetFilledRandomResetPassword("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = resetPasswordService.GetResetPasswordList().Count();

                    Assert.Equal(count, (from c in dbTestDB.ResetPasswords select c).Count());

                    resetPasswordService.Add(resetPassword);
                    if (resetPassword.HasErrors)
                    {
                        Assert.Equal("", resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.True(resetPasswordService.GetResetPasswordList().Where(c => c == resetPassword).Any());
                    resetPasswordService.Update(resetPassword);
                    if (resetPassword.HasErrors)
                    {
                        Assert.Equal("", resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count + 1, resetPasswordService.GetResetPasswordList().Count());
                    resetPasswordService.Delete(resetPassword);
                    if (resetPassword.HasErrors)
                    {
                        Assert.Equal("", resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count, resetPasswordService.GetResetPasswordList().Count());

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Fact]
        public void ResetPassword_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = resetPasswordService.GetResetPasswordList().Count();

                    ResetPassword resetPassword = GetFilledRandomResetPassword("");

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // resetPassword.ResetPasswordID   (Int32)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ResetPasswordID = 0;
                    resetPasswordService.Update(resetPassword);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "ResetPasswordID"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ResetPasswordID = 10000000;
                    resetPasswordService.Update(resetPassword);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ResetPassword", "ResetPasswordID", resetPassword.ResetPasswordID.ToString()), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [DataType(DataType.EmailAddress)]
                    // [StringLength(256))]
                    // resetPassword.Email   (String)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("Email");
                    Assert.False(resetPasswordService.Add(resetPassword));
                    Assert.Equal(1, resetPassword.ValidationResults.Count());
                    Assert.True(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "Email")).Any());
                    Assert.Null(resetPassword.Email);
                    Assert.Equal(count, resetPasswordService.GetResetPasswordList().Count());

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.Email = GetRandomString("", 257);
                    Assert.False(resetPasswordService.Add(resetPassword));
                    Assert.Equal(string.Format(CSSPServicesRes._MaxLengthIs_, "Email", "256"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, resetPasswordService.GetResetPasswordList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // resetPassword.ExpireDate_Local   (DateTime)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ExpireDate_Local = new DateTime();
                    resetPasswordService.Add(resetPassword);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "ExpireDate_Local"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ExpireDate_Local = new DateTime(1979, 1, 1);
                    resetPasswordService.Add(resetPassword);
                    Assert.Equal(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ExpireDate_Local", "1980"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(8))]
                    // resetPassword.Code   (String)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("Code");
                    Assert.False(resetPasswordService.Add(resetPassword));
                    Assert.Equal(1, resetPassword.ValidationResults.Count());
                    Assert.True(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "Code")).Any());
                    Assert.Null(resetPassword.Code);
                    Assert.Equal(count, resetPasswordService.GetResetPasswordList().Count());

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.Code = GetRandomString("", 9);
                    Assert.False(resetPasswordService.Add(resetPassword));
                    Assert.Equal(string.Format(CSSPServicesRes._MaxLengthIs_, "Code", "8"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, resetPasswordService.GetResetPasswordList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // resetPassword.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.LastUpdateDate_UTC = new DateTime();
                    resetPasswordService.Add(resetPassword);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    resetPasswordService.Add(resetPassword);
                    Assert.Equal(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // resetPassword.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.LastUpdateContactTVItemID = 0;
                    resetPasswordService.Add(resetPassword);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", resetPassword.LastUpdateContactTVItemID.ToString()), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.LastUpdateContactTVItemID = 1;
                    resetPasswordService.Add(resetPassword);
                    Assert.Equal(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // resetPassword.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // resetPassword.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated Properties

        #region Tests Generated for GetResetPasswordWithResetPasswordID(resetPassword.ResetPasswordID)
        [Fact]
        public void GetResetPasswordWithResetPasswordID__resetPassword_ResetPasswordID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ResetPassword resetPassword = (from c in dbTestDB.ResetPasswords select c).FirstOrDefault();
                    Assert.NotNull(resetPassword);

                }
            }
        }
        #endregion Tests Generated for GetResetPasswordWithResetPasswordID(resetPassword.ResetPasswordID)

        #region Tests Generated for GetResetPasswordList()
        [Fact]
        public void GetResetPasswordList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ResetPassword resetPassword = (from c in dbTestDB.ResetPasswords select c).FirstOrDefault();
                    Assert.NotNull(resetPassword);

                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    resetPasswordDirectQueryList = (from c in dbTestDB.ResetPasswords select c).Take(200).ToList();

                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList()

        #region Tests Generated for GetResetPasswordList() Skip Take
        [Fact]
        public void GetResetPasswordList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 1, 1, "", "");

                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    resetPasswordDirectQueryList = (from c in dbTestDB.ResetPasswords select c).Skip(1).Take(1).ToList();

                        List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                        resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        CheckResetPasswordFields(resetPasswordList);
                        Assert.Equal(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() Skip Take

        #region Tests Generated for GetResetPasswordList() Skip Take Asc
        [Fact]
        public void GetResetPasswordList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 1, 1,  "ResetPasswordID", "", "");

                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    resetPasswordDirectQueryList = (from c in dbTestDB.ResetPasswords select c).OrderBy(c => c.ResetPasswordID).Skip(1).Take(1).ToList();

                        List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                        resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        CheckResetPasswordFields(resetPasswordList);
                        Assert.Equal(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() Skip Take Asc

        #region Tests Generated for GetResetPasswordList() Skip Take 2 Asc
        [Fact]
        public void GetResetPasswordList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 1, 1, "ResetPasswordID,Email", "", "");

                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    resetPasswordDirectQueryList = (from c in dbTestDB.ResetPasswords select c).OrderBy(c => c.ResetPasswordID).ThenBy(c => c.Email).Skip(1).Take(1).ToList();

                        List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                        resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        CheckResetPasswordFields(resetPasswordList);
                        Assert.Equal(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() Skip Take 2 Asc

        #region Tests Generated for GetResetPasswordList() Skip Take Asc Where
        [Fact]
        public void GetResetPasswordList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 0, 1, "ResetPasswordID", "", "ResetPasswordID,EQ,4");

                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    resetPasswordDirectQueryList = (from c in dbTestDB.ResetPasswords select c).Where(c => c.ResetPasswordID == 4).OrderBy(c => c.ResetPasswordID).Skip(0).Take(1).ToList();

                        List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                        resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        CheckResetPasswordFields(resetPasswordList);
                        Assert.Equal(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() Skip Take Asc Where

        #region Tests Generated for GetResetPasswordList() Skip Take Asc 2 Where
        [Fact]
        public void GetResetPasswordList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                     ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                     resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 0, 1, "ResetPasswordID", "", "ResetPasswordID,GT,2|ResetPasswordID,LT,5");

                     List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                     resetPasswordDirectQueryList = (from c in dbTestDB.ResetPasswords select c).Where(c => c.ResetPasswordID > 2 && c.ResetPasswordID < 5).Skip(0).Take(1).OrderBy(c => c.ResetPasswordID).ToList();

                        List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                        resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        CheckResetPasswordFields(resetPasswordList);
                        Assert.Equal(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() Skip Take Asc 2 Where

        #region Tests Generated for GetResetPasswordList() Skip Take Desc
        [Fact]
        public void GetResetPasswordList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 1, 1, "", "ResetPasswordID", "");

                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    resetPasswordDirectQueryList = (from c in dbTestDB.ResetPasswords select c).OrderByDescending(c => c.ResetPasswordID).Skip(1).Take(1).ToList();

                        List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                        resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        CheckResetPasswordFields(resetPasswordList);
                        Assert.Equal(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() Skip Take Desc

        #region Tests Generated for GetResetPasswordList() Skip Take 2 Desc
        [Fact]
        public void GetResetPasswordList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 1, 1, "", "ResetPasswordID,Email", "");

                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    resetPasswordDirectQueryList = (from c in dbTestDB.ResetPasswords select c).OrderByDescending(c => c.ResetPasswordID).ThenByDescending(c => c.Email).Skip(1).Take(1).ToList();

                        List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                        resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        CheckResetPasswordFields(resetPasswordList);
                        Assert.Equal(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() Skip Take 2 Desc

        #region Tests Generated for GetResetPasswordList() Skip Take Desc Where
        [Fact]
        public void GetResetPasswordList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 0, 1, "ResetPasswordID", "", "ResetPasswordID,EQ,4");

                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    resetPasswordDirectQueryList = (from c in dbTestDB.ResetPasswords select c).Where(c => c.ResetPasswordID == 4).OrderByDescending(c => c.ResetPasswordID).Skip(0).Take(1).ToList();

                        List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                        resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        CheckResetPasswordFields(resetPasswordList);
                        Assert.Equal(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() Skip Take Desc Where

        #region Tests Generated for GetResetPasswordList() Skip Take Desc 2 Where
        [Fact]
        public void GetResetPasswordList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 0, 1, "", "ResetPasswordID", "ResetPasswordID,GT,2|ResetPasswordID,LT,5");

                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    resetPasswordDirectQueryList = (from c in dbTestDB.ResetPasswords select c).Where(c => c.ResetPasswordID > 2 && c.ResetPasswordID < 5).OrderByDescending(c => c.ResetPasswordID).Skip(0).Take(1).ToList();

                        List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                        resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        CheckResetPasswordFields(resetPasswordList);
                        Assert.Equal(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() Skip Take Desc 2 Where

        #region Tests Generated for GetResetPasswordList() 2 Where
        [Fact]
        public void GetResetPasswordList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "ResetPasswordID,GT,2|ResetPasswordID,LT,5");

                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    resetPasswordDirectQueryList = (from c in dbTestDB.ResetPasswords select c).Where(c => c.ResetPasswordID > 2 && c.ResetPasswordID < 5).ToList();

                        List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                        resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        CheckResetPasswordFields(resetPasswordList);
                        Assert.Equal(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() 2 Where

        #region Functions private
        private void CheckResetPasswordFields(List<ResetPassword> resetPasswordList)
        {
            Assert.NotNull(resetPasswordList[0].ResetPasswordID);
            Assert.False(string.IsNullOrWhiteSpace(resetPasswordList[0].Email));
            Assert.NotNull(resetPasswordList[0].ExpireDate_Local);
            Assert.False(string.IsNullOrWhiteSpace(resetPasswordList[0].Code));
            Assert.NotNull(resetPasswordList[0].LastUpdateDate_UTC);
            Assert.NotNull(resetPasswordList[0].LastUpdateContactTVItemID);
            Assert.NotNull(resetPasswordList[0].HasErrors);
        }
        private ResetPassword GetFilledRandomResetPassword(string OmitPropName)
        {
            ResetPassword resetPassword = new ResetPassword();

            if (OmitPropName != "Email") resetPassword.Email = GetRandomEmail();
            if (OmitPropName != "ExpireDate_Local") resetPassword.ExpireDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Code") resetPassword.Code = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") resetPassword.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") resetPassword.LastUpdateContactTVItemID = 2;

            return resetPassword;
        }
        #endregion Functions private
    }
}
