﻿using ConfigServices.Services;
using CultureServices.Resources;
using GenerateCodeBaseServices.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AngularComponentsGeneratedServices.Services
{
    public partial class AngularComponentsGeneratedService : ConfigService, IAngularComponentsGeneratedService
    {
        private void CreateComponentFile(DLLTypeInfo dllTypeInfoModels, List<DLLTypeInfo> DLLTypeInfoCSSPModelsList)
        {
            List<string> usedPropTypeList = new List<string>();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"/*");
            sb.AppendLine($@" * Auto generated from { AppDomain.CurrentDomain.BaseDirectory }{ AppDomain.CurrentDomain.FriendlyName}.exe");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */");
            sb.AppendLine(@"");

            sb.AppendLine(@"import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';");
            sb.AppendLine($@"import {{ { dllTypeInfoModels.Name }Service }} from './{ dllTypeInfoModels.Name.ToLower() }.service';");
            sb.AppendLine($@"import {{ LoadLocales{ dllTypeInfoModels.Name }Text }} from './{ dllTypeInfoModels.Name.ToLower() }.locales';");
            sb.AppendLine(@"import { Router } from '@angular/router';");
            sb.AppendLine(@"import { Subscription } from 'rxjs';");
            bool HasEnums = false;
            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList)
            {
                if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute)
                {
                    if (!usedPropTypeList.Contains(dllPropertyInfo.CSSPProp.PropType))
                    {
                        HasEnums = true;
                        sb.AppendLine($@"import {{ { dllPropertyInfo.CSSPProp.PropType }_GetIDText, { dllPropertyInfo.CSSPProp.PropType }_GetOrderedText }} from '../../../enums/generated/{ dllPropertyInfo.CSSPProp.PropType }';");

                        usedPropTypeList.Add(dllPropertyInfo.CSSPProp.PropType);
                    }
                }
            }
            sb.AppendLine($@"import {{ { dllTypeInfoModels.Name } }} from '../../../models/generated/{ dllTypeInfoModels.Name }.model';");
            sb.AppendLine(@"import { FormBuilder, Validators, FormGroup } from '@angular/forms';");
            if (HasEnums)
            {
                sb.AppendLine(@"import { EnumIDAndText } from '../../../models/enumidandtext.model';");
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"@Component({");
            sb.AppendLine($@"  selector: 'app-{ dllTypeInfoModels.Name.ToLower() }',");
            sb.AppendLine($@"  templateUrl: './{ dllTypeInfoModels.Name.ToLower() }.component.html',");
            sb.AppendLine($@"  styleUrls: ['./{ dllTypeInfoModels.Name.ToLower() }.component.css'],");
            sb.AppendLine(@"  changeDetection: ChangeDetectionStrategy.OnPush");
            sb.AppendLine(@"})");
            sb.AppendLine($@"export class { dllTypeInfoModels.Name }Component implements OnInit, OnDestroy {{");
            sb.AppendLine(@"  sub: Subscription;");

            usedPropTypeList = new List<string>();
            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList)
            {
                if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute)
                {
                    if (!usedPropTypeList.Contains(dllPropertyInfo.CSSPProp.PropType))
                    {
                        string PropNameFirstLetterLowerCase = dllPropertyInfo.CSSPProp.PropName;
                        PropNameFirstLetterLowerCase = PropNameFirstLetterLowerCase[0].ToString().ToLower() + PropNameFirstLetterLowerCase.Substring(1);
                        sb.AppendLine($@"  { PropNameFirstLetterLowerCase }List: EnumIDAndText[];");

                        usedPropTypeList.Add(PropNameFirstLetterLowerCase);
                    }
                }
            }
            sb.AppendLine($@"  { dllTypeInfoModels.Name.ToLower() }FormPut: FormGroup;");
            sb.AppendLine($@"  { dllTypeInfoModels.Name.ToLower() }FormPost: FormGroup;");
            sb.AppendLine(@"");
            sb.AppendLine($@"  constructor(public { dllTypeInfoModels.Name.ToLower() }Service: { dllTypeInfoModels.Name }Service, public router: Router, public fb: FormBuilder) {{ }}");
            sb.AppendLine(@"");
            sb.AppendLine($@"  Get{ dllTypeInfoModels.Name }List() {{");
            sb.AppendLine($@"    this.sub = this.{ dllTypeInfoModels.Name.ToLower() }Service.Get{ dllTypeInfoModels.Name }List(this.router).subscribe();");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine($@"  Put{ dllTypeInfoModels.Name }({ dllTypeInfoModels.Name.ToLower() }: { dllTypeInfoModels.Name }) {{");
            sb.AppendLine($@"    this.sub = this.{ dllTypeInfoModels.Name.ToLower() }Service.Put{ dllTypeInfoModels.Name }({ dllTypeInfoModels.Name.ToLower() }, this.router).subscribe();");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine($@"  Post{ dllTypeInfoModels.Name }({ dllTypeInfoModels.Name.ToLower() }: { dllTypeInfoModels.Name }) {{");
            sb.AppendLine($@"    this.sub = this.{ dllTypeInfoModels.Name.ToLower() }Service.Post{ dllTypeInfoModels.Name }({ dllTypeInfoModels.Name.ToLower() }, this.router).subscribe();");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine($@"  Delete{ dllTypeInfoModels.Name }({ dllTypeInfoModels.Name.ToLower() }: { dllTypeInfoModels.Name }) {{");
            sb.AppendLine($@"    this.sub = this.{ dllTypeInfoModels.Name.ToLower() }Service.Delete{ dllTypeInfoModels.Name }({ dllTypeInfoModels.Name.ToLower() }, this.router).subscribe();");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");

            usedPropTypeList = new List<string>();
            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList)
            {
                if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute)
                {
                    if (!usedPropTypeList.Contains(dllPropertyInfo.CSSPProp.PropType))
                    {
                        sb.AppendLine($@"  Get{ dllPropertyInfo.CSSPProp.PropType }Text(enumID: number) {{");
                        sb.AppendLine($@"    return { dllPropertyInfo.CSSPProp.PropType }_GetIDText(enumID)");
                        sb.AppendLine(@"  }");
                        sb.AppendLine(@"");

                        usedPropTypeList.Add(dllPropertyInfo.CSSPProp.PropType);
                    }
                }
            }
            sb.AppendLine(@"  ngOnInit(): void {");
            sb.AppendLine($@"    LoadLocales{ dllTypeInfoModels.Name }Text(this.{ dllTypeInfoModels.Name.ToLower() }Service);");

            usedPropTypeList = new List<string>();
            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList)
            {
                if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute)
                {
                    if (!usedPropTypeList.Contains(dllPropertyInfo.CSSPProp.PropType))
                    {
                        string PropNameFirstLetterLowerCase = dllPropertyInfo.CSSPProp.PropName;
                        PropNameFirstLetterLowerCase = PropNameFirstLetterLowerCase[0].ToString().ToLower() + PropNameFirstLetterLowerCase.Substring(1);
                        sb.AppendLine($@"    this.{ PropNameFirstLetterLowerCase }List = { dllPropertyInfo.CSSPProp.PropType }_GetOrderedText();");

                        usedPropTypeList.Add(PropNameFirstLetterLowerCase);
                    }
                }
            }

            sb.AppendLine(@"    this.FillFormBuilderGroup('Add');");
            sb.AppendLine(@"    this.FillFormBuilderGroup('Update');");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine(@"  ngOnDestroy() {");
            sb.AppendLine(@"    if (this.sub) {");
            sb.AppendLine(@"      this.sub.unsubscribe();");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine(@"  FillFormBuilderGroup(AddOrUpdate: string) {");
            sb.AppendLine($@"    if (this.{ dllTypeInfoModels.Name.ToLower() }Service.{ dllTypeInfoModels.Name.ToLower() }List.length) {{");
            sb.AppendLine(@"      let formGroup: FormGroup = this.fb.group(");
            sb.AppendLine(@"        {");

            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList)
            {
                sb.AppendLine($@"          { dllPropertyInfo.CSSPProp.PropName }: [");
                sb.AppendLine($@"            {{");
                if (dllPropertyInfo.CSSPProp.IsKey)
                {
                    sb.AppendLine($@"              value: (AddOrUpdate === 'Add' ? 0 : (this.{ dllTypeInfoModels.Name.ToLower() }Service.{ dllTypeInfoModels.Name.ToLower() }List[0]?.{ dllPropertyInfo.CSSPProp.PropName })),");
                }
                else
                {
                    sb.AppendLine($@"              value: this.{ dllTypeInfoModels.Name.ToLower() }Service.{ dllTypeInfoModels.Name.ToLower() }List[0]?.{ dllPropertyInfo.CSSPProp.PropName },");
                }
                sb.AppendLine($@"              disabled: false");
                sb.AppendLine($@"            }}],");
                //sb.AppendLine($@"            }}, Validators.required],");
            }
            sb.AppendLine(@"        }");
            sb.AppendLine(@"      );");
            sb.AppendLine(@"");
            sb.AppendLine(@"      if (AddOrUpdate === 'Add') {");
            sb.AppendLine($@"        this.{ dllTypeInfoModels.Name.ToLower() }FormPost = formGroup");
            sb.AppendLine(@"      }");
            sb.AppendLine(@"      else {");
            sb.AppendLine($@"        this.{ dllTypeInfoModels.Name.ToLower() }FormPut = formGroup;");
            sb.AppendLine(@"      }");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"}");

            DirectoryInfo di = new DirectoryInfo(Config.GetValue<string>("OutputDir").Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()));
            if (!di.Exists)
            {
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    string ErrorText = ex.Message + ex.InnerException != null ? ex.InnerException.Message : "";
                    ActionCommandDBService.ErrorText.AppendLine(ErrorText);
                    return;
                }
            }

            FileInfo fiOutputGen = new FileInfo(Config.GetValue<string>("ComponentFileName").Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()).Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()));
            using (StreamWriter sw2 = fiOutputGen.CreateText())
            {
                sw2.Write(sb.ToString());
                ActionCommandDBService.ExecutionStatusText.AppendLine($"{ string.Format(CultureServicesRes.Created_, fiOutputGen.FullName) }");
            }

            fiOutputGen = new FileInfo(Config.GetValue<string>("ComponentFileName").Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()).Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()));
            if (fiOutputGen.Exists)
            {
                string fileLine = "Last Write Time [" + fiOutputGen.LastWriteTime.ToString("yyyy MMMM dd HH:mm:ss") + "] " + fiOutputGen.FullName;
                ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
            }
            else
            {
                string fileLine = "Not Created" + fiOutputGen.FullName;
                ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
            }

        }
    }
}
