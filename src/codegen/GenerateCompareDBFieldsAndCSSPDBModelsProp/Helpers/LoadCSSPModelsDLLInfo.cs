using GenerateCodeBaseHelper;
using GenerateCodeBaseServices.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace GenerateCompareDBFieldsAndCSSPDBModelsProp
{
    partial class Startup
    {
        private async Task<bool> LoadCSSPDBModelsDLLInfo(List<TypeProp> typePropList)
        {
            FileInfo fiDLL = new FileInfo(Configuration.GetValue<string>("CSSPDBModels"));

            try
            {
                var importAssembly = Assembly.LoadFile(fiDLL.FullName);
                Type[] types = importAssembly.GetTypes();

                foreach (Type type in types)
                {
                    TypeProp typeProp = new TypeProp();
                    typeProp.type = type;
                    typeProp.Plurial = "s";
                    if (type.Name == "Address")
                    {
                        typeProp.Plurial = "es";
                    }

                    //if (type.Name == "AddressWeb")
                    //{
                    //    int seflij = 34;
                    //}
                    if (GenerateCodeBase.SkipType(type))
                    {
                        continue;
                    }

                    foreach (PropertyInfo propertyInfo in type.GetProperties())
                    {
                        if (propertyInfo.GetGetMethod().IsVirtual)
                        {
                            continue;
                        }

                        if (propertyInfo.Name == "ValidationResults")
                        {
                            continue;
                        }

                        CSSPProp csspProp = new CSSPProp();
                        if (!GenerateCodeBase.FillCSSPProp(propertyInfo, csspProp, type))
                        {
                            //ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                            return await Task.FromResult(false);
                        }

                        typeProp.csspPropList.Add(csspProp);
                    }


                    typePropList.Add(typeProp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
