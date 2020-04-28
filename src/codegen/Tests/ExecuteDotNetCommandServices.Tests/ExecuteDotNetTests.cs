using ExecuteDotNetCommandServices.Models;
using ExecuteDotNetCommandServices.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExecuteDotNetCommandServices.Tests
{
    public partial class Tests
    {
        #region Variables
        #endregion Variables

        #region Constructors
        #endregion Constructors

        #region Functions public
        [Fact]
        public async Task ExecuteDotNet_Good_Test()
        {
            generateCodeStatusDBService.Error = new StringBuilder();

            executeDotNetCommandService.dotNetCommand = dotNetCommand;

            await executeDotNetCommandService.ExecuteDotNet(dotNetCommand.SolutionFileName);

            Assert.Equal("", generateCodeStatusDBService.Error.ToString());
        }
        #endregion Functions public
    }
}
