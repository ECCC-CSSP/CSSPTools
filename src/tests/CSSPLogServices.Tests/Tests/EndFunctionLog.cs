using ManageServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using CSSPEnums;
using System.ComponentModel.DataAnnotations;

namespace CSSPLogServices.Tests
{
    public partial class CSSPLogServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see under Setup.cs
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPLogService_EndFunctionLog_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                               select c).ToList();

            Assert.True(commandLogList.Count == 0);

            string ThisFunction = "ThisFunction";
            Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
            Assert.True(await CSSPLogService.FunctionLog($"<{ThisFunction}>"));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
            Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));

            Assert.True(await CSSPLogService.AppendError(new ValidationResult($"Some Error", new[] { "" })));

            Assert.True(await CSSPLogService.EndFunctionLog($"<{ThisFunction}>"));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.Equal("Unknown", CSSPLogService.CSSPAppName);
            Assert.Equal("Unknown", CSSPLogService.CSSPCommandName);

            commandLogList = (from c in dbManage.CommandLogs
                              select c).ToList();

            Assert.True(commandLogList.Count == 0);

        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
