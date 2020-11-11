using GenerateCodeBaseServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GenerateCodeBaseHelper
{
    public static partial class GenerateCodeBase
    {
        public static bool FillDLLTypeInfoList(FileInfo fiDLL, List<DLLTypeInfo> DLLTypeInfoList)
        {
            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            List<Type> typeList = importAssembly.GetTypes().ToList();

            int count = 0;
            foreach (Type type in typeList)
            {
                if (type.Name.StartsWith("<") || type.FullName.StartsWith("CSSPWebAPIs.Models"))
                {
                    continue;
                }

                DLLTypeInfo dllTypeInfo = new DLLTypeInfo
                {
                    Type = type,
                    Name = type.Name,
                    IsEnum = false
                };
                if (type.GetTypeInfo().BaseType == typeof(Enum))
                {
                    dllTypeInfo.IsEnum = true;
                }

                dllTypeInfo.HasNotMappedAttribute = type.CustomAttributes.Where(c => c.AttributeType.Name == "NotMappedAttribute").Any();

                foreach (FieldInfo fieldInfo in type.GetFields())
                {
                    if (!fieldInfo.FieldType.Name.EndsWith("Enum"))
                    {
                        continue;
                    }

                    DLLFieldInfo dllFieldInfo = new DLLFieldInfo();
                    dllFieldInfo.FieldInfo = fieldInfo;
                    dllFieldInfo.Name = fieldInfo.Name;

                    dllTypeInfo.FieldInfoList.Add(dllFieldInfo);
                }

                foreach (PropertyInfo propertyInfo in type.GetProperties())
                {
                    bool CanReadPropertyType = false;
                    try
                    {
                        var PropertyType = propertyInfo.PropertyType;
                        CanReadPropertyType = true;
                    }
                    catch (Exception)
                    {
                        // not used
                    }
                    if (!CanReadPropertyType)
                    {
                        continue;
                    }
                    if (propertyInfo.PropertyType.Name.StartsWith("<"))
                    {
                        continue;
                    }

                    count += 1;
                    if (count % 200 == 0)
                    {
                        ////////////////////////StatusTempEvent(new StatusEventArgs($"Reading type file [{ fiDLL.Name }] [{ type.Name }] [{ propertyInfo.Name }]"));
                    }

                    DLLPropertyInfo dllPropertyInfo = new DLLPropertyInfo();
                    dllPropertyInfo.PropertyInfo = propertyInfo;

                    CSSPProp csspProp = new CSSPProp();
                    if (!FillCSSPProp(propertyInfo, csspProp, type))
                    {
                        //////////////CSSPErrorEvent(new CSSPErrorEventArgs("CSSPError while filling CSSPProp"));
                        return false;
                    }
                    dllPropertyInfo.CSSPProp = csspProp;

                    dllTypeInfo.PropertyInfoList.Add(dllPropertyInfo);
                }

                foreach (MethodInfo methodInfo in type.GetMethods())
                {
                    if (methodInfo.Name.StartsWith("<"))
                    {
                        continue;
                    }

                    count += 1;
                    if (count % 200 == 0)
                    {
                        ////////////////////////StatusTempEvent(new StatusEventArgs($"Reading type file [{ fiDLL.Name }] [{ type.Name }] [{ methodInfo.Name }]"));
                    }

                    if (methodInfo.DeclaringType.FullName.StartsWith("CSSP"))
                    {
                        DLLMethodInfo dllMethodInfo = new DLLMethodInfo();
                        dllMethodInfo.MethodInfo = methodInfo;
                        dllMethodInfo.Name = methodInfo.Name;
                        dllMethodInfo.DeclaringType = methodInfo.DeclaringType;

                        string DeclaringTypeName = methodInfo.DeclaringType.FullName;
                        if (DeclaringTypeName.StartsWith("System.Nullable"))
                        {
                            DeclaringTypeName = DeclaringTypeName.Substring(DeclaringTypeName.IndexOf("[[") + 2);
                            DeclaringTypeName = DeclaringTypeName.Substring(DeclaringTypeName.IndexOf(".") + 1);
                            DeclaringTypeName = DeclaringTypeName.Substring(0, DeclaringTypeName.IndexOf(","));
                        }

                        dllMethodInfo.DeclaringTypeName = DeclaringTypeName;

                        try
                        {
                            foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
                            {
                                DLLParameterInfo dllParameterInfo = new DLLParameterInfo();
                                dllParameterInfo.ParameterInfo = parameterInfo;
                                dllParameterInfo.Name = parameterInfo.Name;

                                dllMethodInfo.ParameterInfoList.Add(dllParameterInfo);
                            }

                        }
                        catch (Exception)
                        {
                            // nothing
                        }

                        dllTypeInfo.MethodInfoList.Add(dllMethodInfo);
                    }
                }

                DLLTypeInfoList.Add(dllTypeInfo);
            }


            return false;
        }
    }
}
