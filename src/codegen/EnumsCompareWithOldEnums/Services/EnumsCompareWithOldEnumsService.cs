using EnumsCompareWithOldEnums.Resources;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumsCompareWithOldEnums.Services
{
    public class EnumsCompareWithOldEnumsService : IEnumsCompareWithOldEnumsService
    {
        #region Variables
        private readonly IConfigurationRoot _configuration;
        private readonly IGenerateCodeStatusDBService _generateCodeStatusDBService;
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EnumsCompareWithOldEnumsService(IConfigurationRoot configuration, IGenerateCodeStatusDBService generateCodeStatusDBService)
        {
            _configuration = configuration;
            _generateCodeStatusDBService = generateCodeStatusDBService;
        }
        #endregion Constructors

        #region Functions public
        public async Task Start()
        {
            GenerateCodeStatus statusAndResults = new GenerateCodeStatus();
            string NewEnumsDLL = "NewEnumsDLL";
            string OldEnumsDLL = "OldEnumsDLL";

            statusAndResults = await _generateCodeStatusDBService.GetOrCreate();

            if (statusAndResults == null)
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ String.Format(AppRes.CouldNotGetOrCreateObject_InDB_, _generateCodeStatusDBService.Command, _generateCodeStatusDBService.DBFileFullName) }");
            }

            await _generateCodeStatusDBService.Update(0);

            FileInfo fiDLL = new FileInfo(_configuration.GetValue<string>(NewEnumsDLL));
            FileInfo fiOldDLL = new FileInfo(_configuration.GetValue<string>(OldEnumsDLL));

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
                    _generateCodeStatusDBService.Error.AppendLine($"{ String.Format(AppRes.Type_NotFound, type.Name) }");
                    await _generateCodeStatusDBService.Update(0);
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
                            _generateCodeStatusDBService.Error.AppendLine($"{ String.Format(AppRes.Type_Enum_NotFound, type.Name, EnumStr) }");
                            await _generateCodeStatusDBService.Update(0);
                            return;
                        }
                        else
                        {
                            // nothing
                        }

                    }
                }
            }

            return;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
