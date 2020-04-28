using ExecuteDotNetCommandServices.Models;
using ExecuteDotNetCommandServices.Resources;
using ExecuteDotNetCommandServices.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task ReadArgsNumber_Good_Test()
        {
            foreach (string args0 in executeDotNetCommandService.Args0Allowables)
            {
                foreach (string args1 in executeDotNetCommandService.Args1Allowables)
                {
                    foreach (string args2 in executeDotNetCommandService.Args2Allowables)
                    {
                        string[] args = new List<string>(){args0, args1, args2 }.ToArray();

                        generateCodeStatusDBService.Error = new System.Text.StringBuilder();

                        await executeDotNetCommandService.ReadArgs(args);

                        Assert.Equal("", generateCodeStatusDBService.Error.ToString());
                    }
                }
            }
        }
        [Fact]
        public async Task ReadArgsNumber_Bad_args_Count_Test()
        {
            string[] args = new List<string>() { "not", "enough" }.ToArray();

            generateCodeStatusDBService.Error = new StringBuilder();

            await executeDotNetCommandService.ReadArgs(args);

            StringBuilder retError = new StringBuilder();
            retError.AppendLine($"{ AppRes.ApplicationRequires3ParametersSeparatedBySpace }");
            retError.AppendLine("");
            retError.AppendLine($"{ AppRes.Example } ExecuteDotNetCommand en-CA run CSSPEnums");
            retError.AppendLine("");
            retError.AppendLine($"\t#0:\t{ AppRes.CultureOptionsEnCAFrCA }");
            retError.AppendLine("");
            retError.AppendLine($"\t#1:\t{ AppRes.ActionOptionsRunTestBuild }");
            retError.AppendLine("");
            retError.AppendLine($"\t#2:\t{ AppRes.SolutionFileNameExampleCSSPRunsCSSPModelsCSSPServices }");
            retError.AppendLine("");

            Assert.Equal(retError.ToString(), generateCodeStatusDBService.Error.ToString());
        }
        [Fact]
        public async Task ReadArgsNumber_Bad_Args0_Test()
        {
            string[] args = new List<string>() { "es-CA", "run", "CSSPEnums" }.ToArray();

            generateCodeStatusDBService.Error = new StringBuilder();

            await executeDotNetCommandService.ReadArgs(args);

            StringBuilder retError = new StringBuilder();
            retError.AppendLine($"\t#0:\t{ string.Format(AppRes.Parameter_ShouldBe_, "0", string.Join(" || ", executeDotNetCommandService.Args0Allowables)) }");
            retError.AppendLine("");

            Assert.Equal(retError.ToString(), generateCodeStatusDBService.Error.ToString());
        }
        [Fact]
        public async Task ReadArgsNumber_Bad_Args1_Test()
        {
            string[] args = new List<string>() { "en-CA", "run_Error", "CSSPEnums" }.ToArray();

            generateCodeStatusDBService.Error = new StringBuilder();

            await executeDotNetCommandService.ReadArgs(args);

            StringBuilder retError = new StringBuilder();
            retError.AppendLine($"\t#1:\t{ string.Format(AppRes.Parameter_ShouldBe_, "1", string.Join(" || ", executeDotNetCommandService.Args1Allowables)) }");
            retError.AppendLine("");

            Assert.Equal(retError.ToString(), generateCodeStatusDBService.Error.ToString());
        }
        [Fact]
        public async Task ReadArgsNumber_Bad_Args2_Test()
        {
            string[] args = new List<string>() { "en-CA", "run", "CSSPEnums_Error" }.ToArray();

            generateCodeStatusDBService.Error = new StringBuilder();

            await executeDotNetCommandService.ReadArgs(args);

            StringBuilder retError = new StringBuilder();
            retError.AppendLine($"\t#2:\t{ string.Format(AppRes.Parameter_ShouldBe_, "2", string.Join(" || ", executeDotNetCommandService.Args2Allowables)) }");
            retError.AppendLine("");

            Assert.Equal(retError.ToString(), generateCodeStatusDBService.Error.ToString());
        }
        #endregion Functions public

    }
}
