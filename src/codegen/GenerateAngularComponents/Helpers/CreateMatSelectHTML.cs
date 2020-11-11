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
        private void CreateMatSelectHTML(DLLPropertyInfo dllPropertyInfo, StringBuilder sb)
        {
            sb.AppendLine($@"      <mat-select formControlName=""{ dllPropertyInfo.CSSPProp.PropName }"">");
            string PropNameFirstLetterLowerCase = dllPropertyInfo.CSSPProp.PropName;
            PropNameFirstLetterLowerCase = PropNameFirstLetterLowerCase[0].ToString().ToLower() + PropNameFirstLetterLowerCase.Substring(1);
            sb.AppendLine($@"        <mat-option *ngFor=""let a of { PropNameFirstLetterLowerCase }List"" [value]=""a.EnumID"">");
            sb.AppendLine(@"          {{ a.EnumText }}");
            sb.AppendLine(@"        </mat-option>");
            sb.AppendLine(@"      </mat-select>");
        }
    }
}
