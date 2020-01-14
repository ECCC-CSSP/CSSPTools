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
using System.Threading;
using System.Text;

namespace CSSPServices.Tests
{

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
        [Fact]
        public void _BaseService_Constructor_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BaseService baseService = new BaseService(new Query { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    // Variables
                    Assert.Equal(@"E:\inetpub\wwwroot\cssp\App_Data\", baseService.BasePath);
                    Assert.Equal(6378137.0D, baseService.R);
                    Assert.Equal(Math.PI / 180.0D, baseService.d2r);
                    Assert.Equal(180.0D / Math.PI, baseService.r2d);

                    // Properties
                    Assert.Equal(dbTestDB, baseService.db);
                    Assert.True(baseService.CanSendEmail);
                    Assert.Equal(ContactID, baseService.ContactID);
                    Assert.Equal("ec.pccsm-cssp.ec@canada.ca", baseService.FromEmail);
                    Assert.Equal(culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en, baseService.LanguageRequest);
                    Assert.Equal(culture, Thread.CurrentThread.CurrentCulture);
                    Assert.Equal(culture, Thread.CurrentThread.CurrentUICulture);

                    // Query
                    Assert.False(baseService.Query.HasErrors);
                    Assert.Equal(culture.TwoLetterISOLanguageName, baseService.Query.Lang);
                    Assert.Equal(culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en, baseService.Query.Language);
                    Assert.Null(baseService.Query.ModelType);
                    Assert.Equal("", baseService.Query.Asc);
                    var a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    Assert.Equal("", baseService.Query.Desc);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    a = baseService.Query.ValidationResults.Count();
                    Assert.Equal(0, a);
                    Assert.Equal("", baseService.Query.Where);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(0, a);
                }
            }
        }
        [Fact]
        public void BaseService_FillQuery_Good_Test()
        {
            string lang;
            int skip;
            int take;
            string ascByName;
            string descByName;
            string where;

            foreach (CultureInfo culture in AllowableCulture)
            {
                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BaseService baseService = new BaseService(new Query(), dbTestDB, ContactID);

                    // FillQuery empty
                    baseService.Query = baseService.FillQuery(typeof(Address));

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal("", baseService.Query.Where);
                    var a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(0, a);

                    // FillQuery lang = "fr"
                    lang = "fr";
                    baseService.Query = baseService.FillQuery(typeof(Address), lang: lang);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.fr, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal("", baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(0, a);

                    // FillQuery skip = 1
                    skip = 1;
                    baseService.Query = baseService.FillQuery(typeof(Address), skip: skip);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(1, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal("", baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(0, a);

                    // FillQuery take = 2
                    take = 2;
                    baseService.Query = baseService.FillQuery(typeof(Address), take: take);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(2, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal("", baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(0, a);

                    // FillQuery Asc = "AddressID,StreetType,StreetNumber,StreetName"
                    ascByName = "AddressID,StreetType,StreetNumber,StreetName";
                    baseService.Query = baseService.FillQuery(modelType: typeof(Address), asc: ascByName);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal(ascByName, baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal("", baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(4, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    Assert.Equal("AddressID", baseService.Query.AscList[0]);
                    Assert.Equal("StreetType", baseService.Query.AscList[1]);
                    Assert.Equal("StreetNumber", baseService.Query.AscList[2]);
                    Assert.Equal("StreetName", baseService.Query.AscList[3]);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(0, a);

                    // FillQuery Desc = "AddressID,StreetType,StreetNumber,StreetName"
                    descByName = "AddressID,StreetType,StreetNumber,StreetName";
                    baseService.Query = baseService.FillQuery(modelType: typeof(Address), desc: descByName);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal(descByName, baseService.Query.Desc);
                    Assert.Equal("", baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(4, a);
                    Assert.Equal("AddressID", baseService.Query.DescList[0]);
                    Assert.Equal("StreetType", baseService.Query.DescList[1]);
                    Assert.Equal("StreetNumber", baseService.Query.DescList[2]);
                    Assert.Equal("StreetName", baseService.Query.DescList[3]);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(0, a);

                    // FillQuery Asc  = "AddressID, StreetType, StreetNumber ,StreetName" with spaces
                    ascByName = "AddressID, StreetType, StreetNumber ,StreetName";
                    baseService.Query = baseService.FillQuery(modelType: typeof(Address), asc: ascByName);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal(ascByName, baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal("", baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(4, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    Assert.Equal("AddressID", baseService.Query.AscList[0]);
                    Assert.Equal("StreetType", baseService.Query.AscList[1]);
                    Assert.Equal("StreetNumber", baseService.Query.AscList[2]);
                    Assert.Equal("StreetName", baseService.Query.AscList[3]);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(0, a);

                    // FillQuery Desc  = "AddressID, StreetType, StreetNumber ,StreetName" with spaces
                    descByName = "AddressID, StreetType, StreetNumber ,StreetName";
                    baseService.Query = baseService.FillQuery(modelType: typeof(Address), desc: descByName);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal(descByName, baseService.Query.Desc);
                    Assert.Equal("", baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    Assert.Equal(4, baseService.Query.DescList.Count);
                    Assert.Equal("AddressID", baseService.Query.DescList[0]);
                    Assert.Equal("StreetType", baseService.Query.DescList[1]);
                    Assert.Equal("StreetNumber", baseService.Query.DescList[2]);
                    Assert.Equal("StreetName", baseService.Query.DescList[3]);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(0, a);

                    // FillQuery Asc "AddressID,StreetType" and Desc "StreetNumber,StreetName"
                    ascByName = "AddressID,StreetType";
                    descByName = "StreetNumber,StreetName";
                    baseService.Query = baseService.FillQuery(modelType: typeof(Address), asc: ascByName, desc: descByName);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal(ascByName, baseService.Query.Asc);
                    Assert.Equal(descByName, baseService.Query.Desc);
                    Assert.Equal("", baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(2, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(2, a);
                    Assert.Equal("AddressID", baseService.Query.AscList[0]);
                    Assert.Equal("StreetType", baseService.Query.AscList[1]);
                    Assert.Equal("StreetNumber", baseService.Query.DescList[0]);
                    Assert.Equal("StreetName", baseService.Query.DescList[1]);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(0, a);

                    // FillQuery where = "Bonjour,EQ,4|Testing,LT,Allo"
                    where = "AddressID,LT,400|StreetType,EQ,Rouge";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal(where, baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(2, a);
                    Assert.Equal("AddressID", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.Equal(WhereOperatorEnum.LessThan, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.Equal("400", baseService.Query.WhereInfoList[0].Value);
                    Assert.Equal("StreetType", baseService.Query.WhereInfoList[1].PropertyName);
                    Assert.Equal(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[1].WhereOperator);
                    Assert.Equal("Rouge", baseService.Query.WhereInfoList[1].Value);

                    // FillQuery where = "AddressID, LT ,400 | StreetName   ,   EQ,    Rouge    " with spaces
                    where = "AddressID, LT ,400 | StreetName   ,   EQ,    Rouge    ";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal(where, baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    Assert.Equal(2, baseService.Query.WhereInfoList.Count);
                    Assert.Equal("AddressID", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.Equal(WhereOperatorEnum.LessThan, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.Equal("400", baseService.Query.WhereInfoList[0].Value);
                    Assert.Equal("StreetName", baseService.Query.WhereInfoList[1].PropertyName);
                    Assert.Equal(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[1].WhereOperator);
                    Assert.Equal("Rouge", baseService.Query.WhereInfoList[1].Value);

                    // FillQuery where = "AddressID,EQ,4" - System.Int32
                    where = "AddressID,EQ,4";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal(where, baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(1, a);
                    Assert.Equal("AddressID", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.Equal(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.Equal("4", baseService.Query.WhereInfoList[0].Value);
                    Assert.Equal(4, baseService.Query.WhereInfoList[0].ValueInt);

                    // FillQuery where = "FixLength,EQ,true" - System.Boolean
                    where = "FixLength,EQ,true";
                    baseService.Query = baseService.FillQuery(typeof(BoxModelResult), where: where);

                    Assert.Equal(typeof(BoxModelResult), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal(where, baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(1, a);
                    Assert.Equal("FixLength", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.Equal(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.Equal("true", baseService.Query.WhereInfoList[0].Value);
                    Assert.True(baseService.Query.WhereInfoList[0].ValueBool);

                    // FillQuery where = "LastUpdateDate_UTC,EQ,2018-04-05" - System.DateTime
                    where = "LastUpdateDate_UTC,EQ,2018-04-05";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal(where, baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(1, a);
                    Assert.Equal("LastUpdateDate_UTC", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.Equal(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.Equal("2018-04-05", baseService.Query.WhereInfoList[0].Value);
                    Assert.Equal(new DateTime(2018, 4, 5), baseService.Query.WhereInfoList[0].ValueDateTime);

                    // FillQuery where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34Z" - System.DateTime
                    where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34Z"; // the Z designate the GMT time zone
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal(where, baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(1, a);
                    Assert.Equal("LastUpdateDate_UTC", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.Equal(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.Equal("2018-04-05 06:45:34Z", baseService.Query.WhereInfoList[0].Value);
                    Assert.Equal(new DateTime(2018, 4, 5, 6, 45, 34).ToLocalTime(), baseService.Query.WhereInfoList[0].ValueDateTime);

                    // FillQuery where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34" - System.DateTime
                    where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34"; // without the Z designate the local time zone
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal(where, baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(1, a);
                    Assert.Equal("LastUpdateDate_UTC", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.Equal(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.Equal("2018-04-05 06:45:34", baseService.Query.WhereInfoList[0].Value);
                    Assert.Equal(new DateTime(2018, 4, 5, 6, 45, 34), baseService.Query.WhereInfoList[0].ValueDateTime);

                    // FillQuery where = "Radius_m,EQ,23.34" - System.Double
                    where = "Radius_m,EQ,23.3";
                    baseService.Query = baseService.FillQuery(typeof(BoxModelResult), where: where);

                    Assert.Equal(typeof(BoxModelResult), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal(where, baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(1, a);
                    Assert.Equal("Radius_m", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.Equal(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.Equal("23.3", baseService.Query.WhereInfoList[0].Value);
                    Assert.Equal(23.3D, baseService.Query.WhereInfoList[0].ValueDouble);

                    // FillQuery where = "StreetType,EQ,Road" - Enumeration with text
                    where = "StreetType,EQ,Road";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal(where, baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(1, a);
                    Assert.Equal("StreetType", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.Equal(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.Equal("Road", baseService.Query.WhereInfoList[0].Value);
                    Assert.Equal((int)StreetTypeEnum.Road, baseService.Query.WhereInfoList[0].ValueInt);
                    Assert.Equal(StreetTypeEnum.Road.ToString(), baseService.Query.WhereInfoList[0].ValueEnumText);

                    // FillQuery where = "StreetType,EQ,Road" - Enumeration with number
                    where = "StreetType,EQ,2";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.Equal(typeof(Address), baseService.Query.ModelType);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);
                    Assert.Equal(0, baseService.Query.Skip);
                    Assert.Equal(200, baseService.Query.Take);
                    Assert.Equal("", baseService.Query.Asc);
                    Assert.Equal("", baseService.Query.Desc);
                    Assert.Equal(where, baseService.Query.Where);
                    a = baseService.Query.AscList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.DescList.Count;
                    Assert.Equal(0, a);
                    a = baseService.Query.WhereInfoList.Count;
                    Assert.Equal(1, a);
                    Assert.Equal("StreetType", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.Equal(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.Equal("2", baseService.Query.WhereInfoList[0].Value);
                    Assert.Equal((int)StreetTypeEnum.Road, baseService.Query.WhereInfoList[0].ValueInt);
                    Assert.Equal(StreetTypeEnum.Road.ToString(), baseService.Query.WhereInfoList[0].ValueEnumText);
                }
            }
        }
        [Fact]
        public void BaseService_FillQuery_Bad_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BaseService baseService = new BaseService(new Query(), dbTestDB, ContactID);

                    // Testing ErrorMessage for ModelType == null
                    baseService.Query = baseService.FillQuery(null);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._ShouldNotBeNullOrEmpty, "ModelType"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Lang == es
                    string lang = "es";

                    baseService.Query = baseService.FillQuery(typeof(Address), lang: lang);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(CSSPServicesRes.AllowableLanguagesAreFRAndEN, baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(LanguageEnum.en, baseService.Query.Language);

                    // Testing ErrorMessage for Skip < 0
                    int skip = -1;

                    baseService.Query = baseService.FillQuery(typeof(Address), skip: skip);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._ShouldBeAbove_, "Skip", "-1"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Skip > 1000000
                    skip = 1000001;

                    baseService.Query = baseService.FillQuery(typeof(Address), skip: skip);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._ShouldBeBelow_, "Skip", "1000000"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Take < 1
                    int take = 0;

                    baseService.Query = baseService.FillQuery(typeof(Address), take: take);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._ShouldBeAbove_, "Take", "0"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Take > 1000000
                    take = 1000001;

                    baseService.Query = baseService.FillQuery(typeof(Address), take: take);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._ShouldBeBelow_, "Take", "1000000"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Asc 
                    string Asc = "AddressID_Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), asc: Asc);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Desc 
                    string Desc = "AddressID_Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), desc: Desc);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Order with multiple PropertyNames
                    Asc = "AddressID,StreetName,AddressID_Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), asc: Asc);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Order with multiple PropertyNames
                    Desc = "AddressID,StreetName,AddressID_Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), desc: Desc);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Order with multiple PropertyNames with space
                    Asc = "AddressID, StreetName, AddressID_Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), asc: Asc);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Order with multiple PropertyNames with space
                    Desc = "AddressID, StreetName, AddressID_Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), asc: Desc);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where 
                    string where = "aAddressID,GT,4,eifj";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._NeedToHaveValidStringFormatEx_, "Where", "TVItemID,GT,5|TVItemID,LT,20"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where 
                    where = "aAddressID,GT,";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._NeedToHaveValidStringFormatEx_, "Where", "TVItemID,GT,5|TVItemID,LT,20"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  with spaces
                    where = "aAddressID, GT,4,eifj";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._NeedToHaveValidStringFormatEx_, "Where", "TVItemID,GT,5|TVItemID,LT,20"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where _DoesNotExistForModelType_
                    where = "AddressID2,GT,2";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID2", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeTrueOrFalseFor_OfModel_ System.Boolean
                    where = "FixLength,EQ,falseNot";

                    baseService.Query = baseService.FillQuery(typeof(BoxModelResult), where: where);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._NeedsToBeTrueOrFalseFor_OfModel_, "falseNot", "FixLength", typeof(BoxModelResult).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeADateFor_OfModel_  System.DateTime
                    where = "LastUpdateDate_UTC,EQ,2018-04-05Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._NeedsToBeADateFor_OfModel_, "2018-04-05Not", "LastUpdateDate_UTC", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where _NeedsToBeANumberFor_ForModel   System.Double
                    where = "Snow_cm,GT,aStringButShouldBeANumber";

                    baseService.Query = baseService.FillQuery(typeof(ClimateDataValue), where: where);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._NeedsToBeANumberFor_OfModel_, "aStringButShouldBeANumber", "Snow_cm", typeof(ClimateDataValue).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where _NeedsToBeANumberFor_ForModel   System.Int16, System.Int32, System.Int64
                    where = "AddressID,GT,aStringButShouldBeANumber";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._NeedsToBeANumberFor_OfModel_, "aStringButShouldBeANumber", "AddressID", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeANumberFor_OfModel_       Enumeration
                    where = "StreetType,EQ,2NotANumber";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._NeedsToBeANumberFor_OfModel_, "2NotANumber", "StreetType", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._NeedsToBeAValidEnumNumberFor_OfModel_AllowableValuesAre_, "2222", "StreetType", typeof(Address).Name, $"[{ sb.ToString() }]"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeAValidEnumNumberFor_OfModel_
                    where = "StreetType,EQ,NotAnOption";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes._NeedsToBeAValidEnumTextFor_OfModel_AllowableValuesAre_, "NotAnOption", "StreetType", typeof(Address).Name, $"[{ sb.ToString() }]"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  WhereOperator_For_OfModel_IsNotValidOnlyEQIsAllowed    Enum should only allow EQ
                    where = "StreetType,LT,2";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes.WhereOperator_For_OfModel_IsNotValidOnlyEQIsAllowed, "LT", "StreetType", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  WhereOperator_NotImplementedYet
                    where = "AddressID,Not,2";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.True(baseService.Query.HasErrors);
                    Assert.Equal(string.Format(CSSPServicesRes.WhereOperator_NotValidAllowableValuesAre_, "Not", "[EQ = EQUAL, LT = LESS THAN, GT = GREATER THAN, C = CONTAINS, SW = STARTS WITH, EW = ENDS WITH]"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);
                }
            }
        }
        #endregion Tests Functions public
    }
}
