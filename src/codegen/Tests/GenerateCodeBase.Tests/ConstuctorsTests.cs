using GenerateCodeStatusDB.Models;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenerateCodeBase.Tests
{
    public partial class Tests
    {
        #region Variables
        #endregion Variables

        #region Constructors
        #endregion Constructors

        #region Functions public
        [Fact]
        public void Constructor_Good_Test()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                Assert.Equal(culture, generateCodeStatusDBService.Culture.Name);
                Assert.Equal("GenerateCodeBase.Tests", generateCodeStatusDBService.Command);
                Assert.Equal("", generateCodeStatusDBService.Error.ToString());
                Assert.Equal("", generateCodeStatusDBService.Status.ToString());

                generateCodeStatusDBService.GetOrCreate();
                generateCodeStatusDBService.Error.Append("Bonjour in Error");
                generateCodeStatusDBService.Status.Append("Testing Status");
                generateCodeStatusDBService.Update(33);

                Assert.Equal("Bonjour in Error", generateCodeStatusDBService.Error.ToString());
                Assert.Equal("Testing Status", generateCodeStatusDBService.Status.ToString());

                GenerateCodeStatus generateCodeStatus = generateCodeStatusDBService.Get().GetAwaiter().GetResult();

                Assert.NotNull(generateCodeStatus);
                Assert.Equal("Bonjour in Error", generateCodeStatus.ErrorText);
                Assert.Equal("Testing Status", generateCodeStatus.StatusText);
                Assert.Equal(33, generateCodeStatus.PercentCompleted);

                generateCodeStatusDBService.Delete();

                generateCodeStatus = generateCodeStatusDBService.Get().GetAwaiter().GetResult();

                Assert.Null(generateCodeStatus);
            }
        }
        #endregion Functions public
    }
}
