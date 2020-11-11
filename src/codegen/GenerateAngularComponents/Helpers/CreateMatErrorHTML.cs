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
        private void CreateMatErrorHTML(DLLTypeInfo dllTypeInfoModels, DLLPropertyInfo dllPropertyInfo, StringBuilder sb)
        {
            sb.AppendLine($@"      <mat-error *ngIf=""{ dllTypeInfoModels.Name.ToLower() }FormEdit.controls.{ dllPropertyInfo.CSSPProp.PropName }.errors; let e;"">");

            // repllicated
            sb.AppendLine($@"        <span>{{{{ e | json }}}}<br /></span>");

            // doing required
            if (!dllPropertyInfo.CSSPProp.IsNullable)
            {
                sb.AppendLine($@"        <span *ngIf=""e.required"">Is Required<br /></span>");
            }
            // doing min
            if (dllPropertyInfo.CSSPProp.HasCSSPRangeAttribute && dllPropertyInfo.CSSPProp.Min != null)
            {
                sb.AppendLine($@"        <span *ngIf=""e.min"">Min - { dllPropertyInfo.CSSPProp.Min }<br /></span>");
            }
            // doing max
            if (dllPropertyInfo.CSSPProp.HasCSSPRangeAttribute && dllPropertyInfo.CSSPProp.Max != null)
            {
                sb.AppendLine($@"        <span *ngIf=""e.min"">Max - { dllPropertyInfo.CSSPProp.Max }<br /></span>");
            }
            // doing email
            if (dllPropertyInfo.CSSPProp.HasDataTypeAttribute)
            {
                if (dllPropertyInfo.CSSPProp.dataType == DataType.EmailAddress)
                {
                    sb.AppendLine($@"        <span *ngIf=""e.email"">Need valid Email<br /></span>");
                }
            }
            // doing minLength
            if (dllPropertyInfo.CSSPProp.HasCSSPMinLengthAttribute)
            {
                sb.AppendLine($@"        <span *ngIf=""e.minlength"">MinLength - { dllPropertyInfo.CSSPProp.Min }<br /></span>");
            }
            // doing maxLength
            if (dllPropertyInfo.CSSPProp.HasCSSPMaxLengthAttribute)
            {
                sb.AppendLine($@"        <span *ngIf=""e.maxlength"">MaxLength - { dllPropertyInfo.CSSPProp.Max }<br /></span>");
            }
            //// doing pattern
            //if (dllPropertyInfo.CSSPProp.)
            //{
            //    sbValidators.Append($@" Validators.maxLength({ dllPropertyInfo.CSSPProp.Max }),");
            //}


            sb.AppendLine(@"      </mat-error>");
        }
    }
}
