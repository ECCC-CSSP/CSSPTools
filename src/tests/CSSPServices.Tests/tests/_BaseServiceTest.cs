using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using System.Threading;
using System.Text;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class _BaseServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public _BaseServiceTest() : base()
        {
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private

        #region Tests Functions public
        [TestMethod]
        public void _BaseService_Constructor_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BaseService baseService = new BaseService(new Query { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    // Variables
                    Assert.AreEqual(@"E:\inetpub\wwwroot\cssp\App_Data\", baseService.BasePath);
                    Assert.AreEqual(6378137.0D, baseService.R);
                    Assert.AreEqual(Math.PI / 180.0D, baseService.d2r);
                    Assert.AreEqual(180.0D / Math.PI, baseService.r2d);

                    // Properties
                    Assert.AreEqual(dbTestDB, baseService.db);
                    Assert.AreEqual(true, baseService.CanSendEmail);
                    Assert.AreEqual(ContactID, baseService.ContactID);
                    Assert.AreEqual("ec.pccsm-cssp.ec@canada.ca", baseService.FromEmail);
                    Assert.AreEqual(culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en, baseService.LanguageRequest);
                    Assert.AreEqual(culture, Thread.CurrentThread.CurrentCulture);
                    Assert.AreEqual(culture, Thread.CurrentThread.CurrentUICulture);

                    // Query
                    Assert.AreEqual(false, baseService.Query.HasErrors);
                    Assert.AreEqual(culture.TwoLetterISOLanguageName, baseService.Query.Lang);
                    Assert.AreEqual(culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(null, baseService.Query.ModelType);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual(0, baseService.Query.ValidationResults.Count());
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);
                }
            }
        }
        [TestMethod]
        public void BaseService_FillQuery_Good_Test()
        {
            string lang;
            int skip;
            int take;
            string ascByName;
            string descByName;
            string where;
            string extra;

            foreach (CultureInfo culture in AllowableCulture)
            {
                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BaseService baseService = new BaseService(new Query(), dbTestDB, ContactID);

                    // FillQuery empty
                    baseService.Query = baseService.FillQuery(typeof(Address));

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery lang = "fr"
                    lang = "fr";
                    baseService.Query = baseService.FillQuery(typeof(Address), lang: lang);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.fr, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery skip = 1
                    skip = 1;
                    baseService.Query = baseService.FillQuery(typeof(Address), skip: skip);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(1, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery take = 2
                    take = 2;
                    baseService.Query = baseService.FillQuery(typeof(Address), take: take);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(2, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery Asc = "AddressID,StreetType,StreetNumber,StreetName"
                    ascByName = "AddressID,StreetType,StreetNumber,StreetName";
                    baseService.Query = baseService.FillQuery(modelType: typeof(Address), asc: ascByName);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual(ascByName, baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual(4, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual("AddressID", baseService.Query.AscList[0]);
                    Assert.AreEqual("StreetType", baseService.Query.AscList[1]);
                    Assert.AreEqual("StreetNumber", baseService.Query.AscList[2]);
                    Assert.AreEqual("StreetName", baseService.Query.AscList[3]);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery Desc = "AddressID,StreetType,StreetNumber,StreetName"
                    descByName = "AddressID,StreetType,StreetNumber,StreetName";
                    baseService.Query = baseService.FillQuery(modelType: typeof(Address), desc: descByName);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual(descByName, baseService.Query.Desc);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(4, baseService.Query.DescList.Count);
                    Assert.AreEqual("AddressID", baseService.Query.DescList[0]);
                    Assert.AreEqual("StreetType", baseService.Query.DescList[1]);
                    Assert.AreEqual("StreetNumber", baseService.Query.DescList[2]);
                    Assert.AreEqual("StreetName", baseService.Query.DescList[3]);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery Asc  = "AddressID, StreetType, StreetNumber ,StreetName" with spaces
                    ascByName = "AddressID, StreetType, StreetNumber ,StreetName";
                    baseService.Query = baseService.FillQuery(modelType: typeof(Address), asc: ascByName);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual(ascByName, baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual(4, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual("AddressID", baseService.Query.AscList[0]);
                    Assert.AreEqual("StreetType", baseService.Query.AscList[1]);
                    Assert.AreEqual("StreetNumber", baseService.Query.AscList[2]);
                    Assert.AreEqual("StreetName", baseService.Query.AscList[3]);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery Desc  = "AddressID, StreetType, StreetNumber ,StreetName" with spaces
                    descByName = "AddressID, StreetType, StreetNumber ,StreetName";
                    baseService.Query = baseService.FillQuery(modelType: typeof(Address), desc: descByName);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual(descByName, baseService.Query.Desc);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(4, baseService.Query.DescList.Count);
                    Assert.AreEqual("AddressID", baseService.Query.DescList[0]);
                    Assert.AreEqual("StreetType", baseService.Query.DescList[1]);
                    Assert.AreEqual("StreetNumber", baseService.Query.DescList[2]);
                    Assert.AreEqual("StreetName", baseService.Query.DescList[3]);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery Asc "AddressID,StreetType" and Desc "StreetNumber,StreetName"
                    ascByName = "AddressID,StreetType";
                    descByName = "StreetNumber,StreetName";
                    baseService.Query = baseService.FillQuery(modelType: typeof(Address), asc: ascByName, desc: descByName);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual(ascByName, baseService.Query.Asc);
                    Assert.AreEqual(descByName, baseService.Query.Desc);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual(2, baseService.Query.AscList.Count);
                    Assert.AreEqual(2, baseService.Query.DescList.Count);
                    Assert.AreEqual("AddressID", baseService.Query.AscList[0]);
                    Assert.AreEqual("StreetType", baseService.Query.AscList[1]);
                    Assert.AreEqual("StreetNumber", baseService.Query.DescList[0]);
                    Assert.AreEqual("StreetName", baseService.Query.DescList[1]);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery where = "Bonjour,EQ,4|Testing,LT,Allo"
                    where = "AddressID,LT,400|StreetType,EQ,Rouge";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual(2, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("AddressID", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.LessThan, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("400", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual("StreetType", baseService.Query.WhereInfoList[1].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[1].WhereOperator);
                    Assert.AreEqual("Rouge", baseService.Query.WhereInfoList[1].Value);

                    // FillQuery where = "AddressID, LT ,400 | StreetName   ,   EQ,    Rouge    " with spaces
                    where = "AddressID, LT ,400 | StreetName   ,   EQ,    Rouge    ";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual(2, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("AddressID", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.LessThan, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("400", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual("StreetName", baseService.Query.WhereInfoList[1].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[1].WhereOperator);
                    Assert.AreEqual("Rouge", baseService.Query.WhereInfoList[1].Value);

                    // FillQuery where = "AddressID,EQ,4" - System.Int32
                    where = "AddressID,EQ,4";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("AddressID", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("4", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual(4, baseService.Query.WhereInfoList[0].ValueInt);

                    // FillQuery where = "FixLength,EQ,true" - System.Boolean
                    where = "FixLength,EQ,true";
                    baseService.Query = baseService.FillQuery(typeof(BoxModelResult), where: where);

                    Assert.AreEqual(typeof(BoxModelResult), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("FixLength", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("true", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual(true, baseService.Query.WhereInfoList[0].ValueBool);

                    // FillQuery where = "LastUpdateDate_UTC,EQ,2018-04-05" - System.DateTime
                    where = "LastUpdateDate_UTC,EQ,2018-04-05";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("LastUpdateDate_UTC", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("2018-04-05", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual(new DateTime(2018, 4, 5), baseService.Query.WhereInfoList[0].ValueDateTime);

                    // FillQuery where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34Z" - System.DateTime
                    where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34Z"; // the Z designate the GMT time zone
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("LastUpdateDate_UTC", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("2018-04-05 06:45:34Z", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual(new DateTime(2018, 4, 5, 6, 45, 34).ToLocalTime(), baseService.Query.WhereInfoList[0].ValueDateTime);

                    // FillQuery where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34" - System.DateTime
                    where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34"; // without the Z designate the local time zone
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("LastUpdateDate_UTC", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("2018-04-05 06:45:34", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual(new DateTime(2018, 4, 5, 6, 45, 34), baseService.Query.WhereInfoList[0].ValueDateTime);

                    // FillQuery where = "Radius_m,EQ,23.34" - System.Double
                    where = "Radius_m,EQ,23.3";
                    baseService.Query = baseService.FillQuery(typeof(BoxModelResult), where: where);

                    Assert.AreEqual(typeof(BoxModelResult), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("Radius_m", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("23.3", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual(23.3D, baseService.Query.WhereInfoList[0].ValueDouble);

                    // FillQuery where = "StreetType,EQ,Road" - Enumeration with text
                    where = "StreetType,EQ,Road";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("StreetType", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("Road", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual((int)StreetTypeEnum.Road, baseService.Query.WhereInfoList[0].ValueInt);
                    Assert.AreEqual(StreetTypeEnum.Road.ToString(), baseService.Query.WhereInfoList[0].ValueEnumText);

                    // FillQuery where = "StreetType,EQ,Road" - Enumeration with number
                    where = "StreetType,EQ,2";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Asc);
                    Assert.AreEqual("", baseService.Query.Desc);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual(0, baseService.Query.AscList.Count);
                    Assert.AreEqual(0, baseService.Query.DescList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("StreetType", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("2", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual((int)StreetTypeEnum.Road, baseService.Query.WhereInfoList[0].ValueInt);
                    Assert.AreEqual(StreetTypeEnum.Road.ToString(), baseService.Query.WhereInfoList[0].ValueEnumText);
                }
            }
        }
        [TestMethod]
        public void BaseService_FillQuery_Bad_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BaseService baseService = new BaseService(new Query(), dbTestDB, ContactID);

                    // Testing ErrorMessage for ModelType == null
                    baseService.Query = baseService.FillQuery(null);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._ShouldNotBeNullOrEmpty, "ModelType"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Lang == es
                    string lang = "es";

                    baseService.Query = baseService.FillQuery(typeof(Address), lang: lang);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(CSSPServicesRes.AllowableLanguagesAreFRAndEN, baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);

                    // Testing ErrorMessage for Skip < 0
                    int skip = -1;

                    baseService.Query = baseService.FillQuery(typeof(Address), skip: skip);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._ShouldBeAbove_, "Skip", "-1"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Skip > 1000000
                    skip = 1000001;

                    baseService.Query = baseService.FillQuery(typeof(Address), skip: skip);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._ShouldBeBelow_, "Skip", "1000000"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Take < 1
                    int take = 0;

                    baseService.Query = baseService.FillQuery(typeof(Address), take: take);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._ShouldBeAbove_, "Take", "0"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Take > 1000000
                    take = 1000001;

                    baseService.Query = baseService.FillQuery(typeof(Address), take: take);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._ShouldBeBelow_, "Take", "1000000"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Asc 
                    string Asc = "AddressID_Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), asc: Asc);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Desc 
                    string Desc = "AddressID_Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), desc: Desc);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Order with multiple PropertyNames
                    Asc = "AddressID,StreetName,AddressID_Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), asc: Asc);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Order with multiple PropertyNames
                    Desc = "AddressID,StreetName,AddressID_Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), desc: Desc);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Order with multiple PropertyNames with space
                    Asc = "AddressID, StreetName, AddressID_Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), asc: Asc);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Order with multiple PropertyNames with space
                    Desc = "AddressID, StreetName, AddressID_Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), asc: Desc);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where 
                    string where = "aAddressID,GT,4,eifj";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedToHaveValidStringFormatEx_, "Where", "TVItemID,GT,5|TVItemID,LT,20"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where 
                    where = "aAddressID,GT,";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedToHaveValidStringFormatEx_, "Where", "TVItemID,GT,5|TVItemID,LT,20"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  with spaces
                    where = "aAddressID, GT,4,eifj";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedToHaveValidStringFormatEx_, "Where", "TVItemID,GT,5|TVItemID,LT,20"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where _DoesNotExistForModelType_
                    where = "AddressID2,GT,2";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID2", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeTrueOrFalseFor_OfModel_ System.Boolean
                    where = "FixLength,EQ,falseNot";

                    baseService.Query = baseService.FillQuery(typeof(BoxModelResult), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeTrueOrFalseFor_OfModel_, "falseNot", "FixLength", typeof(BoxModelResult).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeADateFor_OfModel_  System.DateTime
                    where = "LastUpdateDate_UTC,EQ,2018-04-05Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeADateFor_OfModel_, "2018-04-05Not", "LastUpdateDate_UTC", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where _NeedsToBeANumberFor_ForModel   System.Double
                    where = "Snow_cm,GT,aStringButShouldBeANumber";

                    baseService.Query = baseService.FillQuery(typeof(ClimateDataValue), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeANumberFor_OfModel_, "aStringButShouldBeANumber", "Snow_cm", typeof(ClimateDataValue).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where _NeedsToBeANumberFor_ForModel   System.Int16, System.Int32, System.Int64
                    where = "AddressID,GT,aStringButShouldBeANumber";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeANumberFor_OfModel_, "aStringButShouldBeANumber", "AddressID", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeANumberFor_OfModel_       Enumeration
                    where = "StreetType,EQ,2NotANumber";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeANumberFor_OfModel_, "2NotANumber", "StreetType", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeAValidEnumNumberFor_OfModel_
                    where = "StreetType,EQ,2222";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    List<int> EnumValueList = (from c in Enum.GetValues(typeof(StreetTypeEnum)) as int[] select c).ToList();
                    List<string> EnumValueTextList = (from c in Enum.GetNames(typeof(StreetTypeEnum)) as string[] select c).ToList();
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0, count = EnumValueList.Count; i < count; i++)
                    {
                        sb.Append($"{ EnumValueList[i] } = { EnumValueTextList[i] }, ");
                    }
                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeAValidEnumNumberFor_OfModel_AllowableValuesAre_, "2222", "StreetType", typeof(Address).Name, $"[{ sb.ToString() }]"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeAValidEnumNumberFor_OfModel_
                    where = "StreetType,EQ,NotAnOption";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeAValidEnumTextFor_OfModel_AllowableValuesAre_, "NotAnOption", "StreetType", typeof(Address).Name, $"[{ sb.ToString() }]"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  WhereOperator_For_OfModel_IsNotValidOnlyEQIsAllowed    Enum should only allow EQ
                    where = "StreetType,LT,2";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes.WhereOperator_For_OfModel_IsNotValidOnlyEQIsAllowed, "LT", "StreetType", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  WhereOperator_NotImplementedYet
                    where = "AddressID,Not,2";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes.WhereOperator_NotValidAllowableValuesAre_, "Not", "[EQ = EQUAL, LT = LESS THAN, GT = GREATER THAN, C = CONTAINS, SW = STARTS WITH, EW = ENDS WITH]"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);
                }
            }
        }
        #endregion Tests Functions public
    }
}
