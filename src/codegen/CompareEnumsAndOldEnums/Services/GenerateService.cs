using CompareEnumsAndOldEnums.Resources;
using Microsoft.Extensions.Configuration;
using StatusAndResultsDBService.Models;
using StatusAndResultsDBService.Services;
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
        #endregion Variables

        #region Constructors
        public GenerateService()
        {
        }
        #endregion Constructors

        #region Functions public
        public async Task Start(IConfigurationRoot configuration, IStatusAndResultsService statusAndResultsService)
        {
            string Command = configuration.GetValue<string>("Command");

            StringBuilder sbError = new StringBuilder();
            StringBuilder sbStatus = new StringBuilder();
            StatusAndResults statusAndResults = new StatusAndResults();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string dbFileNamePartial = configuration.GetValue<string>("DBFileName");

            FileInfo fiDB = new FileInfo(dbFileNamePartial.Replace("{AppDataPath}", appDataPath));

            Console.WriteLine($"{ AppRes.Starting }...");

            sbStatus.AppendLine($"{ AppRes.Starting }...");

            statusAndResults = await statusAndResultsService.Get(Command);

            if (statusAndResults == null)
            {
                statusAndResults = await statusAndResultsService.Create(Command);
                if (statusAndResults == null)
                {
                    return;
                }

                statusAndResults = await statusAndResultsService.Get(Command);

                if (statusAndResults == null)
                {
                    return;
                }
            }

            FileInfo fiDLL = new FileInfo(configuration.GetValue<string>("NewEnumsDll"));
            FileInfo fiOldDLL = new FileInfo(configuration.GetValue<string>("OldEnumsDll"));

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
                    sbError.AppendLine($"{ String.Format(AppRes.Type_NotFound, type.Name) }");
                    statusAndResults = await statusAndResultsService.Update(Command, sbError.ToString(), sbStatus.ToString(), 0);
                    return;
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
                            sbError.AppendLine($"{ String.Format(AppRes.Type_Enum_NotFound, type.Name, EnumStr) }");
                            statusAndResults = await statusAndResultsService.Update(Command, sbError.ToString(), sbStatus.ToString(), 0);
                            return;
                        }
                        else
                        {
                            // nothing
                        }

                    }
                }
            }

            Console.WriteLine($"{ AppRes.Done }...");

            sbStatus.AppendLine($"{ AppRes.Done }...");
            statusAndResults = await statusAndResultsService.Update(Command, sbError.ToString(), sbStatus.ToString(), 100);
            return;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}