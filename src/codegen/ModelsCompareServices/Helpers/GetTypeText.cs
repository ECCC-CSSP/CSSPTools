using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.Extensions.Configuration;
using ModelsCompareServices.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace ModelsCompareServices.Services
{
    public partial class ModelsCompareService : IModelsCompareService
    {
        private string GetTypeText(string propTypeName)
        {
            switch (propTypeName)
            {
                case "Type":
                    return "Type";
                case "Boolean":
                    return "bool";
                case "Byte[]":
                    return "byte[]";
                case "DateTime":
                    return "DateTime";
                case "Double":
                    return "double";
                case "Single":
                    return "float";
                case "Int16":
                    return "int";
                case "Int32":
                    return "int";
                case "Int64":
                    return "long";
                case "String":
                    return "string";
                default:
                    return propTypeName;
            }
        }
    }
}
