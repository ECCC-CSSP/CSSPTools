/*
 * Manually edited
 * 
 */
using CultureServices.Resources;
using CultureServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using Xunit;

namespace CSSPModels.Tests
{

    public partial class __DisplayAndDescriptionResxChecksTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public __DisplayAndDescriptionResxChecksTests()
        {
        }
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public void Check_All_Filed_Culture_Models_Res_Test(string culture)
        {
            IConfiguration Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();

            FileInfo fiDLL = new FileInfo(Config.GetValue<string>("CSSPModels"));

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();

            foreach (Type type in types)
            {
                if (type.Name.StartsWith("<")
                    || type.Name.StartsWith("CSSPModelsRes")
                    || type.Name.StartsWith("Application")
                    || type.Name.StartsWith("CSSPDBContext")
                    || type.Name.StartsWith("TestDBContext")
                    || type.Name.StartsWith("InMemoryDBContext")
                    || type.Name.StartsWith("CSSPAfter")
                    || type.Name.StartsWith("CSSPAllowNull")
                    || type.Name.StartsWith("CSSPBigger")
                    || type.Name.StartsWith("CSSPCompare")
                    || type.Name.StartsWith("CSSPEnumType")
                    || type.Name.StartsWith("CSSPEnumTypeText")
                    || type.Name.StartsWith("CSSPExist")
                    || type.Name.StartsWith("CSSPFill")
                    || type.Name.StartsWith("CSSPMaxLengthAttribute")
                    || type.Name.StartsWith("CSSPMinLengthAttribute")
                    || type.Name.StartsWith("CSSPRangeAttribute")
                    || type.Name.StartsWith("CSSPRequiredAttribute")
                    || type.Name.StartsWith("CSSPRegularExpressionAttribute")
                    || type.Name == "LastUpdate"
                    || type.Name == "AspNetUser")
                {
                    continue;
                }

                foreach (PropertyInfo propertyInfo in type.GetProperties())
                {
                    Assert.NotEmpty(CultureModelsRes.ResourceManager.GetString($"{type.Name}_{propertyInfo.Name}_Description", new CultureInfo(culture)));
                    Assert.NotEmpty(CultureModelsRes.ResourceManager.GetString($"{type.Name}_{propertyInfo.Name}_Display", new CultureInfo(culture)));
                }
            }
        }
        #endregion Tests
    }
}