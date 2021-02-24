using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCompareOldAndNewEnums
{
    public partial class Startup
    {
        public async Task<bool> CompareDLLs()
        {
            string NewEnumsDLL = "NewEnumsDLL";
            string OldEnumsDLL = "OldEnumsDLL";

            Console.WriteLine("CompareDLLs Starting...");


            FileInfo fiDLL = new FileInfo(Configuration.GetValue<string>(NewEnumsDLL));
            FileInfo fiOldDLL = new FileInfo(Configuration.GetValue<string>(OldEnumsDLL));

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
                    Console.WriteLine($"Type [{ type.Name }] not found");
                    return false;
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
                            Console.WriteLine($"Type [{type.Name}] Enum [{EnumStr}] not found");
                            return false;
                        }
                        else
                        {
                            // nothing
                        }
                    }
                }
            }

            Console.WriteLine("CompareDLLs Finished...");

            return true;
        }
    }
}
