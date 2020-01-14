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

    public partial class DocTemplateServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private DocTemplateService docTemplateService { get; set; }
        #endregion Properties

        #region Constructors
        public DocTemplateServiceTest() : base()
        {
            //docTemplateService = new DocTemplateService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Fact]
        public void DocTemplate_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    DocTemplate docTemplate = GetFilledRandomDocTemplate("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = docTemplateService.GetDocTemplateList().Count();

                    Assert.Equal(count, (from c in dbTestDB.DocTemplates select c).Count());

                    docTemplateService.Add(docTemplate);
                    if (docTemplate.HasErrors)
                    {
                        Assert.Equal("", docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.True(docTemplateService.GetDocTemplateList().Where(c => c == docTemplate).Any());
                    docTemplateService.Update(docTemplate);
                    if (docTemplate.HasErrors)
                    {
                        Assert.Equal("", docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count + 1, docTemplateService.GetDocTemplateList().Count());
                    docTemplateService.Delete(docTemplate);
                    if (docTemplate.HasErrors)
                    {
                        Assert.Equal("", docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count, docTemplateService.GetDocTemplateList().Count());

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Fact]
        public void DocTemplate_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = docTemplateService.GetDocTemplateList().Count();

                    DocTemplate docTemplate = GetFilledRandomDocTemplate("");

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // docTemplate.DocTemplateID   (Int32)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.DocTemplateID = 0;
                    docTemplateService.Update(docTemplate);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "DocTemplateID"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.DocTemplateID = 10000000;
                    docTemplateService.Update(docTemplate);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "DocTemplate", "DocTemplateID", docTemplate.DocTemplateID.ToString()), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // docTemplate.Language   (LanguageEnum)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.Language = (LanguageEnum)1000000;
                    docTemplateService.Add(docTemplate);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "Language"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // docTemplate.TVType   (TVTypeEnum)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.TVType = (TVTypeEnum)1000000;
                    docTemplateService.Add(docTemplate);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "TVType"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = File)]
                    // docTemplate.TVFileTVItemID   (Int32)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.TVFileTVItemID = 0;
                    docTemplateService.Add(docTemplate);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVFileTVItemID", docTemplate.TVFileTVItemID.ToString()), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.TVFileTVItemID = 1;
                    docTemplateService.Add(docTemplate);
                    Assert.Equal(string.Format(CSSPServicesRes._IsNotOfType_, "TVFileTVItemID", "File"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(150))]
                    // docTemplate.FileName   (String)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("FileName");
                    Assert.False(docTemplateService.Add(docTemplate));
                    Assert.Equal(1, docTemplate.ValidationResults.Count());
                    Assert.True(docTemplate.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "FileName")).Any());
                    Assert.Null(docTemplate.FileName);
                    Assert.Equal(count, docTemplateService.GetDocTemplateList().Count());

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.FileName = GetRandomString("", 151);
                    Assert.False(docTemplateService.Add(docTemplate));
                    Assert.Equal(string.Format(CSSPServicesRes._MaxLengthIs_, "FileName", "150"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, docTemplateService.GetDocTemplateList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // docTemplate.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.LastUpdateDate_UTC = new DateTime();
                    docTemplateService.Add(docTemplate);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    docTemplateService.Add(docTemplate);
                    Assert.Equal(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // docTemplate.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.LastUpdateContactTVItemID = 0;
                    docTemplateService.Add(docTemplate);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", docTemplate.LastUpdateContactTVItemID.ToString()), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.LastUpdateContactTVItemID = 1;
                    docTemplateService.Add(docTemplate);
                    Assert.Equal(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // docTemplate.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // docTemplate.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated Properties

        #region Tests Generated for GetDocTemplateWithDocTemplateID(docTemplate.DocTemplateID)
        [Fact]
        public void GetDocTemplateWithDocTemplateID__docTemplate_DocTemplateID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    DocTemplate docTemplate = (from c in dbTestDB.DocTemplates select c).FirstOrDefault();
                    Assert.NotNull(docTemplate);

                }
            }
        }
        #endregion Tests Generated for GetDocTemplateWithDocTemplateID(docTemplate.DocTemplateID)

        #region Tests Generated for GetDocTemplateList()
        [Fact]
        public void GetDocTemplateList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    DocTemplate docTemplate = (from c in dbTestDB.DocTemplates select c).FirstOrDefault();
                    Assert.NotNull(docTemplate);

                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).Take(200).ToList();

                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList()

        #region Tests Generated for GetDocTemplateList() Skip Take
        [Fact]
        public void GetDocTemplateList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 1, 1, "", "");

                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).Skip(1).Take(1).ToList();

                        List<DocTemplate> docTemplateList = new List<DocTemplate>();
                        docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        CheckDocTemplateFields(docTemplateList);
                        Assert.Equal(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() Skip Take

        #region Tests Generated for GetDocTemplateList() Skip Take Asc
        [Fact]
        public void GetDocTemplateList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 1, 1,  "DocTemplateID", "", "");

                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).OrderBy(c => c.DocTemplateID).Skip(1).Take(1).ToList();

                        List<DocTemplate> docTemplateList = new List<DocTemplate>();
                        docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        CheckDocTemplateFields(docTemplateList);
                        Assert.Equal(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() Skip Take Asc

        #region Tests Generated for GetDocTemplateList() Skip Take 2 Asc
        [Fact]
        public void GetDocTemplateList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 1, 1, "DocTemplateID,Language", "", "");

                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).OrderBy(c => c.DocTemplateID).ThenBy(c => c.Language).Skip(1).Take(1).ToList();

                        List<DocTemplate> docTemplateList = new List<DocTemplate>();
                        docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        CheckDocTemplateFields(docTemplateList);
                        Assert.Equal(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() Skip Take 2 Asc

        #region Tests Generated for GetDocTemplateList() Skip Take Asc Where
        [Fact]
        public void GetDocTemplateList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 0, 1, "DocTemplateID", "", "DocTemplateID,EQ,4");

                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).Where(c => c.DocTemplateID == 4).OrderBy(c => c.DocTemplateID).Skip(0).Take(1).ToList();

                        List<DocTemplate> docTemplateList = new List<DocTemplate>();
                        docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        CheckDocTemplateFields(docTemplateList);
                        Assert.Equal(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() Skip Take Asc Where

        #region Tests Generated for GetDocTemplateList() Skip Take Asc 2 Where
        [Fact]
        public void GetDocTemplateList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                     DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                     docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 0, 1, "DocTemplateID", "", "DocTemplateID,GT,2|DocTemplateID,LT,5");

                     List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                     docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).Where(c => c.DocTemplateID > 2 && c.DocTemplateID < 5).Skip(0).Take(1).OrderBy(c => c.DocTemplateID).ToList();

                        List<DocTemplate> docTemplateList = new List<DocTemplate>();
                        docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        CheckDocTemplateFields(docTemplateList);
                        Assert.Equal(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() Skip Take Asc 2 Where

        #region Tests Generated for GetDocTemplateList() Skip Take Desc
        [Fact]
        public void GetDocTemplateList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 1, 1, "", "DocTemplateID", "");

                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).OrderByDescending(c => c.DocTemplateID).Skip(1).Take(1).ToList();

                        List<DocTemplate> docTemplateList = new List<DocTemplate>();
                        docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        CheckDocTemplateFields(docTemplateList);
                        Assert.Equal(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() Skip Take Desc

        #region Tests Generated for GetDocTemplateList() Skip Take 2 Desc
        [Fact]
        public void GetDocTemplateList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 1, 1, "", "DocTemplateID,Language", "");

                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).OrderByDescending(c => c.DocTemplateID).ThenByDescending(c => c.Language).Skip(1).Take(1).ToList();

                        List<DocTemplate> docTemplateList = new List<DocTemplate>();
                        docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        CheckDocTemplateFields(docTemplateList);
                        Assert.Equal(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() Skip Take 2 Desc

        #region Tests Generated for GetDocTemplateList() Skip Take Desc Where
        [Fact]
        public void GetDocTemplateList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 0, 1, "DocTemplateID", "", "DocTemplateID,EQ,4");

                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).Where(c => c.DocTemplateID == 4).OrderByDescending(c => c.DocTemplateID).Skip(0).Take(1).ToList();

                        List<DocTemplate> docTemplateList = new List<DocTemplate>();
                        docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        CheckDocTemplateFields(docTemplateList);
                        Assert.Equal(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() Skip Take Desc Where

        #region Tests Generated for GetDocTemplateList() Skip Take Desc 2 Where
        [Fact]
        public void GetDocTemplateList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 0, 1, "", "DocTemplateID", "DocTemplateID,GT,2|DocTemplateID,LT,5");

                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).Where(c => c.DocTemplateID > 2 && c.DocTemplateID < 5).OrderByDescending(c => c.DocTemplateID).Skip(0).Take(1).ToList();

                        List<DocTemplate> docTemplateList = new List<DocTemplate>();
                        docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        CheckDocTemplateFields(docTemplateList);
                        Assert.Equal(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() Skip Take Desc 2 Where

        #region Tests Generated for GetDocTemplateList() 2 Where
        [Fact]
        public void GetDocTemplateList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "DocTemplateID,GT,2|DocTemplateID,LT,5");

                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).Where(c => c.DocTemplateID > 2 && c.DocTemplateID < 5).ToList();

                        List<DocTemplate> docTemplateList = new List<DocTemplate>();
                        docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        CheckDocTemplateFields(docTemplateList);
                        Assert.Equal(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() 2 Where

        #region Functions private
        private void CheckDocTemplateFields(List<DocTemplate> docTemplateList)
        {
            Assert.NotNull(docTemplateList[0].DocTemplateID);
            Assert.NotNull(docTemplateList[0].Language);
            Assert.NotNull(docTemplateList[0].TVType);
            Assert.NotNull(docTemplateList[0].TVFileTVItemID);
            Assert.False(string.IsNullOrWhiteSpace(docTemplateList[0].FileName));
            Assert.NotNull(docTemplateList[0].LastUpdateDate_UTC);
            Assert.NotNull(docTemplateList[0].LastUpdateContactTVItemID);
            Assert.NotNull(docTemplateList[0].HasErrors);
        }
        private DocTemplate GetFilledRandomDocTemplate(string OmitPropName)
        {
            DocTemplate docTemplate = new DocTemplate();

            if (OmitPropName != "Language") docTemplate.Language = LanguageRequest;
            if (OmitPropName != "TVType") docTemplate.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "TVFileTVItemID") docTemplate.TVFileTVItemID = 42;
            if (OmitPropName != "FileName") docTemplate.FileName = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") docTemplate.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") docTemplate.LastUpdateContactTVItemID = 2;

            return docTemplate;
        }
        #endregion Functions private
    }
}
