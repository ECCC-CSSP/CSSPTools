using ExecuteDotNetCommandServices.Models;
using ExecuteDotNetCommandServices.Resources;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExecuteDotNetCommandServices.Services
{
    public partial class ExecuteDotNetCommandService : IExecuteDotNetCommandService
    {
        private async Task<bool> ReadArgs(string[] args)
        {
            if (args.Count() != 3)
            {
                actionCommandDBService.ErrorText.AppendLine($"{ ExecuteDotNetCommandServicesRes.ApplicationRequires3ParametersSeparatedBySpace }");
                actionCommandDBService.ErrorText.AppendLine("");
                actionCommandDBService.ErrorText.AppendLine($"{ ExecuteDotNetCommandServicesRes.Example } ExecuteDotNetCommand en-CA run CSSPEnums");
                actionCommandDBService.ErrorText.AppendLine("");
                actionCommandDBService.ErrorText.AppendLine($"\t#0:\t{ ExecuteDotNetCommandServicesRes.CultureOptionsEnCAFrCA }");
                actionCommandDBService.ErrorText.AppendLine("");
                actionCommandDBService.ErrorText.AppendLine($"\t#1:\t{ ExecuteDotNetCommandServicesRes.ActionOptionsRunTestBuild }");
                actionCommandDBService.ErrorText.AppendLine("");
                actionCommandDBService.ErrorText.AppendLine($"\t#2:\t{ ExecuteDotNetCommandServicesRes.SolutionFileNameExampleCSSPRunsCSSPModelsCSSPServices }");
                actionCommandDBService.ErrorText.AppendLine("");
                return await Task.FromResult(false);
            }
            else
            {
                if (!(Args0Allowables.Contains(args[0])))
                {
                    string culture = Args0Allowables[0];

                    if (args.Count() > 0)
                    {
                        if (Args0Allowables.Contains(args[0]))
                        {
                            culture = args[0];
                        }
                    }

                    args[0] = culture;
                }
                else
                {
                    ExecuteDotNetCommandServicesRes.Culture = new CultureInfo(args[0]);
                    dotNetCommand.CultureName = args[0];
                }

                if (!(Args1Allowables.Contains(args[1])))
                {
                    actionCommandDBService.ErrorText.AppendLine($"\t#1:\t{ string.Format(ExecuteDotNetCommandServicesRes.Parameter_ShouldBe_, "1", string.Join(" || ", Args1Allowables)) }");
                    actionCommandDBService.ErrorText.AppendLine("");
                    return await Task.FromResult(false);
                }
                else
                {
                    dotNetCommand.Action = args[1];
                }

                if (args[1] == "run")
                {
                    if (!(ArgsRunAllowables.Contains(args[2])))
                    {
                        actionCommandDBService.ErrorText.AppendLine($"\t#2:\t{ string.Format(ExecuteDotNetCommandServicesRes.Parameter_ShouldBe_, "2", string.Join(" || ", ArgsRunAllowables)) }");
                        actionCommandDBService.ErrorText.AppendLine("");
                        return await Task.FromResult(false);
                    }
                    else
                    {
                        dotNetCommand.Command = args[2];
                    }
                }
                if (args[1] == "test")
                {
                    if (!(ArgsTestAllowables.Contains(args[2])))
                    {
                        actionCommandDBService.ErrorText.AppendLine($"\t#2:\t{ string.Format(ExecuteDotNetCommandServicesRes.Parameter_ShouldBe_, "2", string.Join(" || ", ArgsTestAllowables)) }");
                        actionCommandDBService.ErrorText.AppendLine("");
                        return await Task.FromResult(false);
                    }
                    else
                    {
                        dotNetCommand.Command = args[2];
                    }
                }
                if (args[1] == "build")
                {
                    if (!(ArgsBuildAllowables.Contains(args[2])))
                    {
                        actionCommandDBService.ErrorText.AppendLine($"\t#2:\t{ string.Format(ExecuteDotNetCommandServicesRes.Parameter_ShouldBe_, "2", string.Join(" || ", ArgsBuildAllowables)) }");
                        actionCommandDBService.ErrorText.AppendLine("");
                        return await Task.FromResult(false);
                    }
                    else
                    {
                        dotNetCommand.Command = args[2];
                    }
                }
            }

            return await Task.FromResult(true);
        }
    }
}
