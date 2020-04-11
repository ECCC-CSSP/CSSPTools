using CompareEnumsAndOldEnums.Models;
using CompareEnumsAndOldEnums.Resources;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompareEnumsAndOldEnums.Services
{
    public class GenerateService : IGenerateService
    {
        #region Variables
        private readonly GenerateCodeStatusContext _generateCodeStatusContext;
        #endregion Variables

        #region Constructors
        public GenerateService(GenerateCodeStatusContext generateCodeStatusContext)
        {
            _generateCodeStatusContext = generateCodeStatusContext;
        }
        #endregion Constructors

        #region Functions public
        public async Task<string> Start(IConfigurationRoot configuration)
        {
            string Command = configuration.GetValue<string>("Command");

            StringBuilder sbStatus = new StringBuilder();
            StatusAndResults statusAndResults = new StatusAndResults();
            string retStr = "";

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiDB = new FileInfo($@"{appDataPath}\CSSP\GenerateCodeStatus.db");

            string connStrDB = configuration.GetConnectionString("DataConnection").Replace("DataSource=", "");

            if (!fiDB.Exists)
            {
                sbStatus.AppendLine($"{ String.Format(AppRes.ErrorFileDoesNotExist_, fiDB.FullName) }");
                return sbStatus.ToString();
            }

            if (fiDB.FullName != connStrDB)
            {
                sbStatus.AppendLine($"{ String.Format(AppRes.ConnStrDBNotEqual_, fiDB.FullName) }");
                return sbStatus.ToString();
            }

            sbStatus.AppendLine($"{ AppRes.Starting }...");

            statusAndResults = (from c in _generateCodeStatusContext.StatusAndResults
                                where c.Command == Command
                                select c).FirstOrDefault();

            if (statusAndResults == null)
            {
                statusAndResults = new StatusAndResults();
                retStr = await AddStatusAndResults(statusAndResults, Command, sbStatus, 0);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                statusAndResults = (from c in _generateCodeStatusContext.StatusAndResults
                                    where c.Command == Command
                                    select c).FirstOrDefault();

                if (statusAndResults == null)
                {
                    sbStatus.AppendLine($"{ String.Format(AppRes.CouldNotCreateNewStatusAndResultsItemInDB_, fiDB.FullName) }");
                    return sbStatus.ToString();
                }
            }

            FileInfo fiDLL = new FileInfo(configuration.GetValue<string>("NewEnumsDll"));
            FileInfo fiOldDLL = new FileInfo(configuration.GetValue<string>("OldEnumsDll"));

            if (!fiDLL.Exists)
            {
                sbStatus.AppendLine($"{ String.Format(AppRes.ErrorFileDoesNotExist_, fiDLL.FullName) }");
                retStr = await UpdateStatus(statusAndResults, sbStatus, 0);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                return sbStatus.ToString();
            }

            if (!fiOldDLL.Exists)
            {
                sbStatus.AppendLine($"{ String.Format(AppRes.ErrorFileDoesNotExist_, fiOldDLL.FullName) }");
                retStr = await UpdateStatus(statusAndResults, sbStatus, 0);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                return sbStatus.ToString();
            }

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            List<Type> typeList = importAssembly.GetTypes().ToList();

            var importAssemblyOld = Assembly.LoadFile(fiOldDLL.FullName);
            List<Type> typeOldList = importAssemblyOld.GetTypes().ToList();

            foreach (Type type in typeOldList)
            {
                if (type.Name.EndsWith("Service") || type.Name.EndsWith("Res") || type.Name.EndsWith("TextOrdered") || type.Name.StartsWith("<>"))
                {
                    continue;
                }
                Type typeExist = (from c in typeList
                                  where c.Name == type.Name
                                  select c).FirstOrDefault();

                if (typeExist == null)
                {
                    sbStatus.AppendLine($"{ String.Format(AppRes.Type_NotFound, type.Name) }");
                    retStr = await UpdateStatus(statusAndResults, sbStatus, 0);
                    if (!string.IsNullOrWhiteSpace(retStr))
                    {
                        return retStr;
                    }

                    return sbStatus.ToString();
                }
                else
                {
                    List<string> EnumNameOldList = Enum.GetNames(type).ToList();
                    List<string> EnumNameList = Enum.GetNames(typeExist).ToList();

                    foreach (string EnumStr in EnumNameOldList)
                    {
                        if (EnumStr == "Error")
                        {
                            continue;
                        }

                        string EnumStrExist = (from c in EnumNameList
                                               where c == EnumStr
                                               select c).FirstOrDefault();

                        if (string.IsNullOrWhiteSpace(EnumStrExist))
                        {
                            sbStatus.AppendLine($"{ String.Format(AppRes.Type_Enum_NotFound, type.Name, EnumStr) }");
                            retStr = await UpdateStatus(statusAndResults, sbStatus, 0);
                            if (!string.IsNullOrWhiteSpace(retStr))
                            {
                                return retStr;
                            }

                            return sbStatus.ToString();
                        }
                        else
                        {
                            // nothing
                        }

                    }
                }
            }

            sbStatus.AppendLine($"{ AppRes.Done }...");
            retStr = await UpdateStatus(statusAndResults, sbStatus, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return sbStatus.ToString();
        }
        #endregion Functions public

        #region Functions private
        private async Task<string> UpdateStatus(StatusAndResults statusAndResults, StringBuilder sbStatus, int percentCompleted)
        {
            if (statusAndResults == null)
            {
                sbStatus.AppendLine($"{ String.Format(AppRes.Error_IsNull, "statusAndResults") }");
                return $"{ String.Format(AppRes.Error_IsNull, "statusAndResults") }";
            }

            statusAndResults.StatusText = sbStatus.ToString();
            statusAndResults.PercentCompleted = percentCompleted;
            statusAndResults.LastUpdateDate = DateTime.UtcNow.ToString();

            try
            {
                _generateCodeStatusContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }
        private async Task<string> AddStatusAndResults(StatusAndResults statusAndResults, string command, StringBuilder sbStatus, int percentCompleted)
        {
            if (statusAndResults == null)
            {
                sbStatus.AppendLine($"{ String.Format(AppRes.Error_IsNull, "statusAndResults") }");
                return $"{ String.Format(AppRes.Error_IsNull, "statusAndResults") }";
            }

            statusAndResults.Command = command;
            statusAndResults.StatusText = sbStatus.ToString();
            statusAndResults.PercentCompleted = percentCompleted;
            statusAndResults.LastUpdateDate = DateTime.UtcNow.ToString();

            try
            {
                _generateCodeStatusContext.StatusAndResults.Add(statusAndResults);
                _generateCodeStatusContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }
        #endregion Functions private
    }
}