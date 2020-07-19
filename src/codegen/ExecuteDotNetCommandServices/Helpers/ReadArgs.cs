using CSSPCultureServices.Resources;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ExecuteDotNetCommandServices.Services
{
    public partial class ExecuteDotNetCommandService : IExecuteDotNetCommandService
    {
        private async Task<bool> ReadArgs(string[] args)
        {
            if (args.Count() != 3)
            {
                ActionCommandDBService.ErrorText.AppendLine($"{ CSSPCultureServicesRes.ApplicationRequires3ParametersSeparatedBySpace }");
                ActionCommandDBService.ErrorText.AppendLine("");
                ActionCommandDBService.ErrorText.AppendLine($"{ CSSPCultureServicesRes.Example } ExecuteDotNetCommand en-CA run CSSPEnums");
                ActionCommandDBService.ErrorText.AppendLine("");
                ActionCommandDBService.ErrorText.AppendLine($"\t#0:\t{ CSSPCultureServicesRes.CSSPCultureOptionsEnCAFrCA }");
                ActionCommandDBService.ErrorText.AppendLine("");
                ActionCommandDBService.ErrorText.AppendLine($"\t#1:\t{ CSSPCultureServicesRes.ActionOptionsRunTestBuild }");
                ActionCommandDBService.ErrorText.AppendLine("");
                ActionCommandDBService.ErrorText.AppendLine($"\t#2:\t{ CSSPCultureServicesRes.SolutionFileNameExampleCSSPRunsCSSPModelsCSSPServices }");
                ActionCommandDBService.ErrorText.AppendLine("");
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
                    CSSPCultureServicesRes.Culture = new CultureInfo(args[0]);
                    dotNetCommand.CultureName = args[0];
                }

                if (!(Args1Allowables.Contains(args[1])))
                {
                    ActionCommandDBService.ErrorText.AppendLine($"\t#1:\t{ string.Format(CSSPCultureServicesRes.Parameter_ShouldBe_, "1", string.Join(" || ", Args1Allowables)) }");
                    ActionCommandDBService.ErrorText.AppendLine("");
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
                        ActionCommandDBService.ErrorText.AppendLine($"\t#2:\t{ string.Format(CSSPCultureServicesRes.Parameter_ShouldBe_, "2", string.Join(" || ", ArgsRunAllowables)) }");
                        ActionCommandDBService.ErrorText.AppendLine("");
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
                        ActionCommandDBService.ErrorText.AppendLine($"\t#2:\t{ string.Format(CSSPCultureServicesRes.Parameter_ShouldBe_, "2", string.Join(" || ", ArgsTestAllowables)) }");
                        ActionCommandDBService.ErrorText.AppendLine("");
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
                        ActionCommandDBService.ErrorText.AppendLine($"\t#2:\t{ string.Format(CSSPCultureServicesRes.Parameter_ShouldBe_, "2", string.Join(" || ", ArgsBuildAllowables)) }");
                        ActionCommandDBService.ErrorText.AppendLine("");
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
