﻿using ConfigServices.Services;
using CultureServices.Resources;
using GenerateCodeBaseServices.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            sb.AppendLine(@"import { Subscription } from 'rxjs';");
            bool HasEnums = false;
            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList)
            {
                if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute)
                {
                    if (!usedPropTypeList.Contains(dllPropertyInfo.CSSPProp.PropType))
                    {
                        HasEnums = true;
                        sb.AppendLine($@"import {{ { dllPropertyInfo.CSSPProp.PropType }_GetIDText }} from '../../../enums/generated/{ dllPropertyInfo.CSSPProp.PropType }';");

                        usedPropTypeList.Add(dllPropertyInfo.CSSPProp.PropType);
                    }
                }
            }
            sb.AppendLine($@"import {{ { dllTypeInfoModels.Name } }} from '../../../models/generated/{ dllTypeInfoModels.Name }.model';");
            sb.AppendLine(@"import { HttpClientService } from '../../../services/http-client.service';");
            sb.AppendLine(@"import { Router } from '@angular/router';");
            sb.AppendLine(@"import { HttpClientCommand } from '../../../enums/app.enums';");
            sb.AppendLine(@"");
            sb.AppendLine(@"@Component({");
            sb.AppendLine($@"  selector: 'app-{ dllTypeInfoModels.Name.ToLower() }',");
            sb.AppendLine($@"  templateUrl: './{ dllTypeInfoModels.Name.ToLower() }.component.html',");
            sb.AppendLine($@"  styleUrls: ['./{ dllTypeInfoModels.Name.ToLower() }.component.css'],");
            sb.AppendLine(@"  changeDetection: ChangeDetectionStrategy.OnPush");
            sb.AppendLine(@"})");
            sb.AppendLine($@"export class { dllTypeInfoModels.Name }Component implements OnInit, OnDestroy {{");
            sb.AppendLine(@"  sub: Subscription;");
            sb.AppendLine($@"  IDToShow: number;");
            sb.AppendLine($@"  showType?: HttpClientCommand = null;");
            sb.AppendLine(@"");
            sb.AppendLine($@"  constructor(public { dllTypeInfoModels.Name.ToLower() }Service: { dllTypeInfoModels.Name }Service, private router: Router, private httpClientService: HttpClientService) {{");
            sb.AppendLine($@"    httpClientService.oldURL = router.url;");
            sb.AppendLine($@"  }}");
            sb.AppendLine(@"");
            sb.AppendLine($@"  GetPutButtonColor({ dllTypeInfoModels.Name.ToLower() }: { dllTypeInfoModels.Name }) {{");
            sb.AppendLine($@"    if (this.IDToShow === { dllTypeInfoModels.Name.ToLower() }.{ dllTypeInfoModels.Name }ID && this.showType === HttpClientCommand.Put) {{");
            sb.AppendLine(@"      return 'primary';");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"    else {");
            sb.AppendLine(@"      return 'basic';");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"  }");
            sb.AppendLine($@"");
            sb.AppendLine($@"  GetPostButtonColor({ dllTypeInfoModels.Name.ToLower() }: { dllTypeInfoModels.Name }) {{");
            sb.AppendLine($@"    if (this.IDToShow === { dllTypeInfoModels.Name.ToLower() }.{ dllTypeInfoModels.Name }ID && this.showType === HttpClientCommand.Post) {{");
            sb.AppendLine(@"      return 'primary';");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"    else {");
            sb.AppendLine(@"      return 'basic';");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine($@"  ShowPut({ dllTypeInfoModels.Name.ToLower() }: { dllTypeInfoModels.Name }) {{");
            sb.AppendLine($@"    if (this.IDToShow === { dllTypeInfoModels.Name.ToLower() }.{ dllTypeInfoModels.Name }ID && this.showType === HttpClientCommand.Put) {{");
            sb.AppendLine(@"      this.IDToShow = 0;");
            sb.AppendLine(@"      this.showType = null;");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"    else {");
            sb.AppendLine($@"      this.IDToShow = { dllTypeInfoModels.Name.ToLower() }.{ dllTypeInfoModels.Name }ID;");
            sb.AppendLine(@"      this.showType = HttpClientCommand.Put;");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine($@"  ShowPost({ dllTypeInfoModels.Name.ToLower() }: { dllTypeInfoModels.Name }) {{");
            sb.AppendLine($@"    if (this.IDToShow === { dllTypeInfoModels.Name.ToLower() }.{ dllTypeInfoModels.Name }ID && this.showType === HttpClientCommand.Post) {{");
            sb.AppendLine(@"      this.IDToShow = 0;");
            sb.AppendLine(@"      this.showType = null;");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"    else {");
            sb.AppendLine($@"      this.IDToShow = { dllTypeInfoModels.Name.ToLower() }.{ dllTypeInfoModels.Name }ID;");
            sb.AppendLine(@"      this.showType = HttpClientCommand.Post;");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine(@"  GetPutEnum() {");
            sb.AppendLine(@"    return <number>HttpClientCommand.Put;");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine(@"  GetPostEnum() {");
            sb.AppendLine(@"    return <number>HttpClientCommand.Post;");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine($@"  Get{ dllTypeInfoModels.Name }List() {{");
            sb.AppendLine($@"    this.sub = this.{ dllTypeInfoModels.Name.ToLower() }Service.Get{ dllTypeInfoModels.Name }List().subscribe();");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine($@"  Delete{ dllTypeInfoModels.Name }({ dllTypeInfoModels.Name.ToLower() }: { dllTypeInfoModels.Name }) {{");
            sb.AppendLine($@"    this.sub = this.{ dllTypeInfoModels.Name.ToLower() }Service.Delete{ dllTypeInfoModels.Name }({ dllTypeInfoModels.Name.ToLower() }).subscribe();");
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
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine(@"  ngOnDestroy() {");
            sb.AppendLine(@"    if (this.sub) {");
            sb.AppendLine(@"      this.sub.unsubscribe();");
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
