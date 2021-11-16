using CSSPGenerateCodeBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSSPEnumsGenerateCodeHelper
{
    public partial class EnumsCodeWriter : GenerateCodeBase
    {
        /// <summary>
        /// Compares the enums between:
        ///     C:\CSSPTools\src\dlls\CSSPEnums\bin\Debug\netcoreapp3.1\CSSPEnums.dll
        ///     C:\CSSP Latest Code Old\CSSPEnumsDLL\CSSPEnumsDLL\bin\Debug\CSSPEnumsDLL.dll
        /// 
        /// Requires:
        ///     C:\CSSPTools\src\dlls\CSSPEnums\bin\Debug\netcoreapp3.1\CSSPEnums.dll
        ///     C:\CSSP Latest Code Old\CSSPEnumsDLL\CSSPEnumsDLL\bin\Debug\CSSPEnumsDLL.dll
        /// </summary>
        public void CompareEnumsAndOldEnums()
        {
            StatusTempEvent(new StatusEventArgs(""));
            ClearPermanentEvent(new StatusEventArgs("Starting ..."));
            StatusPermanentEvent(new StatusEventArgs(""));

            StringBuilder sb = new StringBuilder();
            FileInfo fiDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPEnums\bin\Debug\netcoreapp3.1\CSSPEnums.dll");
            FileInfo fiOldDLL = new FileInfo(@"C:\CSSP Latest Code Old\CSSPEnumsDLL\CSSPEnumsDLL\bin\Debug\CSSPEnumsDLL.dll");

            if (!fiDLL.Exists)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"File does not exist [{ fiDLL.FullName }]"));
                return;
            }

            if (!fiOldDLL.Exists)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"File does not exist [{ fiOldDLL.FullName }]"));
                return;
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
                //StatusPermanentEvent(new StatusEventArgs(type.Name));
                Type typeExist = (from c in typeList
                                  where c.Name == type.Name
                                  select c).FirstOrDefault();

                if (typeExist == null)
                {
                    StatusPermanentEvent(new StatusEventArgs($"{ type.Name } -------------- Not Found"));
                }
                else
                {
                    //StatusPermanentEvent(new StatusEventArgs($"{ type.Name } ok"));
                    List<string> EnumNameOldList = Enum.GetNames(type).ToList();
                    List<string> EnumNameList = Enum.GetNames(typeExist).ToList();

                    foreach (string EnumStr in EnumNameOldList)
                    {
                        if (EnumStr == "Error")
                        {
                            continue;
                        }
                        //StatusPermanentEvent(new StatusEventArgs($"\t{ EnumStr }"));
                        string EnumStrExist = (from c in EnumNameList
                                               where c == EnumStr
                                               select c).FirstOrDefault();

                        if (string.IsNullOrWhiteSpace(EnumStrExist))
                        {
                            StatusPermanentEvent(new StatusEventArgs($"{ type.Name }\t{ EnumStr } -------------- Not Found"));
                        }
                        else
                        {
                            //StatusPermanentEvent(new StatusEventArgs($"\t{ EnumStr } ok"));
                        }

                    }
                }
            }

            StatusTempEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs("Done ..."));

        }
    }
}
