using GenerateCodeBaseServices.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace GenerateAngularComponents
{
    public partial class Startup
    {
        private void CreateMatInputHTML(DLLPropertyInfo dllPropertyInfo, StringBuilder sb)
        {
            if (dllPropertyInfo.CSSPProp.PropType == "Int16" || dllPropertyInfo.CSSPProp.PropType == "Int32"
                || dllPropertyInfo.CSSPProp.PropType == "Int64" || dllPropertyInfo.CSSPProp.PropType == "Single" || dllPropertyInfo.CSSPProp.PropType == "Double")
            {
                sb.AppendLine($@"      <input matInput type=""number"" formControlName=""{ dllPropertyInfo.CSSPProp.PropName }"">");
            }
            else if (dllPropertyInfo.CSSPProp.PropType == "String")
            {
                sb.AppendLine($@"      <input matInput type=""text"" formControlName=""{ dllPropertyInfo.CSSPProp.PropName }"">");
            }
            else // will need to do email ...
            {
                sb.AppendLine($@"      <input matInput type=""text"" formControlName=""{ dllPropertyInfo.CSSPProp.PropName }"">");
            }
        }
    }
}
