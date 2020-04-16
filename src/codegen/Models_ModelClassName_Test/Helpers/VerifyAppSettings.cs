using Models_ModelClassName_Test.Resources;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_ModelClassName_Test
{
    partial class Program
    {
        private static string VerifyAppSettings()
        {
            bool hasError = false;
            List<string> ParamListShouldExist = new List<string>()
            {
                "Command", "Culture", "DBFileName", "CSSPEnums", "IEnumsGenerated", "EnumsGenerated"
            };

            Console.WriteLine(AppRes.VerifyAppSettingsFile);
            Console.WriteLine("");

            foreach (string param in ParamListShouldExist)
            {
                string retConf = configuration.GetValue<string>(param);

                if (!string.IsNullOrWhiteSpace(retConf))
                {
                    Console.WriteLine($"\tOK\t{param} { AppRes.Exist}");
                }
                else
                {
                    Console.WriteLine($"\tERROR\t{param} { AppRes.CouldNotFindParameter }");
                    hasError = true;
                }
            }
            Console.WriteLine("");

            foreach (string param in ParamListShouldExist)
            {
                string retConf = configuration.GetValue<string>(param);

                switch (param)
                {
                    case "Command":
                        {
                            string command = "EnumsGenerated_cs";
                            if (retConf != command)
                            {
                                Console.WriteLine($"\tERROR\t{param} {retConf} != " + command);
                                hasError = true;
                            }
                            else
                            {
                                Console.WriteLine($"\tOK\t{param} {retConf} == " + command);
                            }
                        }
                        break;
                    case "Culture":
                        {
                            if (!(retConf == "en-CA" || retConf == "fr-CA"))
                            {
                                Console.WriteLine($"\tERROR\t{param} {retConf} != en-CA || fr-CA");
                                hasError = true;
                            }
                            else
                            {
                                Console.WriteLine($"\tOK\t{param} {retConf} == en-CA || fr-CA");
                            }
                        }
                        break;
                    case "DBFileName":
                        {
                            string fileName = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db";
                            if (retConf != fileName)
                            {
                                Console.WriteLine($"\tERROR\t{param} {retConf} != " + fileName);
                                hasError = true;
                            }
                            else
                            {
                                Console.WriteLine($"\tOK\t{param} {retConf} == " + fileName);
                            }

                            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                            FileInfo fiDB = new FileInfo(retConf.Replace("{AppDataPath}", appDataPath));

                            if (!fiDB.Exists)
                            {
                                Console.WriteLine($"\tERROR\t{param} {retConf} != { fiDB.FullName }");
                                hasError = true;
                            }
                            else
                            {
                                Console.WriteLine($"\tOK\t{param} {retConf} = { fiDB.FullName }");
                            }
                        }
                        break;
                    case "CSSPModels":
                        {
                            string fileName = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\bin\\Debug\\netcoreapp3.1\\CSSPModels.dll";
                            if (retConf != fileName)
                            {
                                Console.WriteLine($"\tERROR\t{param} {retConf} != " + fileName);
                                hasError = true;
                            }
                            else
                            {
                                Console.WriteLine($"\tOK\t{param} {retConf} == " + fileName);
                            }

                            FileInfo fiTest = new FileInfo(retConf);
                            if (!fiTest.Exists)
                            {
                                Console.WriteLine($"\tERROR\t{param} {retConf} { AppRes.ErrorFileDoesNotExist_}");
                                hasError = true;
                            }
                            else
                            {
                                Console.WriteLine($"\tOK\t{param} {retConf} { AppRes.Exist}");
                            }
                        }
                        break;
                    case "IEnumsGenerated":
                        {
                            string fileName = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Generated\\IEnumsGenerated.cs";
                            if (retConf != fileName)
                            {
                                Console.WriteLine($"\tERROR\t{param} {retConf} != " + fileName);
                                hasError = true;
                            }
                            else
                            {
                                Console.WriteLine($"\tOK\t{param} {retConf} == " + fileName);
                            }

                            FileInfo fiTest = new FileInfo(retConf);
                            if (!fiTest.Exists)
                            {
                                Console.WriteLine($"\tERROR\t{param} {retConf} { AppRes.ErrorFileDoesNotExist_}");
                                hasError = true;
                            }
                            else
                            {
                                Console.WriteLine($"\tOK\t{param} {retConf} { AppRes.Exist}");
                            }
                        }
                        break;
                    case "EnumsGenerated":
                        {
                            string fileName = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Generated\\EnumsGenerated.cs";
                            if (retConf != fileName)
                            {
                                Console.WriteLine($"\tERROR\t{param} {retConf} != " + fileName);
                                hasError = true;
                            }
                            else
                            {
                                Console.WriteLine($"\tOK\t{param} {retConf} == " + fileName);
                            }

                            FileInfo fiTest = new FileInfo(retConf);
                            if (!fiTest.Exists)
                            {
                                Console.WriteLine($"\tERROR\t{param} {retConf} { AppRes.ErrorFileDoesNotExist_}");
                                hasError = true;
                            }
                            else
                            {
                                Console.WriteLine($"\tOK\t{param} {retConf} { AppRes.Exist}");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("");

            if (hasError)
            {
                return "ERROR";
            }

            return "";
        }
    }
}
