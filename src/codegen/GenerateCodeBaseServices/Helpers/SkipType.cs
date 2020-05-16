using CSSPEnums;
using GenerateCodeBaseServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCodeBaseServices.Services
{
    public partial class GenerateCodeBaseService : IGenerateCodeBaseService
    {
        public bool SkipType(Type type)
        {
            if (type.Name.StartsWith("<")
                || type.Name.StartsWith("CSSPModelsRes")
                || type.Name.StartsWith("Application")
                || type.Name.StartsWith("CSSPDBContext")
                || type.Name.StartsWith("TestDBContext")
                || type.Name.StartsWith("CSSPAfter")
                || type.Name.StartsWith("CSSPAllowNull")
                || type.Name.StartsWith("CSSPBigger")
                || type.Name.StartsWith("CSSPEnumType")
                || type.Name.StartsWith("CSSPExist")
                || type.Name.StartsWith("CSSPFill")
                || type.Name.StartsWith("CSSPEnumTypeText")
                || type.Name.StartsWith("CSSPDescriptionENAttribute")
                || type.Name.StartsWith("CSSPDescriptionFRAttribute")
                || type.Name.StartsWith("CSSPDisplayENAttribute")
                || type.Name.StartsWith("CSSPDisplayFRAttribute")
                || type.Name == "CSSPError"
                || type.Name == "LastUpdate"
                || type.Name == "CSSPModelsRes"
                || type.Name == "AspNetUser")
            {
                return true;
            }

            return false;
        }
    }
}
