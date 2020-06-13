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
        private void CreateServiceFile(DLLTypeInfo dllTypeInfoModels, List<DLLTypeInfo> DLLTypeInfoCSSPModelsList)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"/*");
            sb.AppendLine($@" * Auto generated from { AppDomain.CurrentDomain.BaseDirectory }{ AppDomain.CurrentDomain.FriendlyName}.exe");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */");
            sb.AppendLine(@"");

            sb.AppendLine(@"import { Injectable } from '@angular/core';");
            sb.AppendLine($@"import {{ { dllTypeInfoModels.Name }TextModel }} from './{ dllTypeInfoModels.Name.ToLower() }.models';");
            sb.AppendLine(@"import { BehaviorSubject, of } from 'rxjs';");
            sb.AppendLine($@"import {{ LoadLocales{ dllTypeInfoModels.Name }Text }} from './{ dllTypeInfoModels.Name.ToLower() }.locales';");
            sb.AppendLine(@"import { Router } from '@angular/router';");
            sb.AppendLine(@"import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';");
            sb.AppendLine(@"import { map, catchError } from 'rxjs/operators';");
            sb.AppendLine($@"import {{ { dllTypeInfoModels.Name } }} from '../../../models/generated/{ dllTypeInfoModels.Name }.model';");
            sb.AppendLine(@"import { HttpRequestModel } from '../../../models/http.model';");
            sb.AppendLine(@"");
            sb.AppendLine(@"@Injectable({");
            sb.AppendLine(@"  providedIn: 'root'");
            sb.AppendLine(@"})");
            sb.AppendLine($@"export class { dllTypeInfoModels.Name }Service {{");
            sb.AppendLine(@"  /* Variables */");
            sb.AppendLine($@"  { dllTypeInfoModels.Name.ToLower() }TextModel$: BehaviorSubject<{ dllTypeInfoModels.Name }TextModel> = new BehaviorSubject<{ dllTypeInfoModels.Name }TextModel>(<{ dllTypeInfoModels.Name }TextModel>{{}});");
            sb.AppendLine($@"  { dllTypeInfoModels.Name.ToLower() }ListModel$: BehaviorSubject<{ dllTypeInfoModels.Name }[]> = new BehaviorSubject<{ dllTypeInfoModels.Name }[]>(<{ dllTypeInfoModels.Name }[]>{{}});");
            sb.AppendLine($@"  { dllTypeInfoModels.Name.ToLower() }GetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{{}});");
            sb.AppendLine($@"  { dllTypeInfoModels.Name.ToLower() }PutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{{}});");
            sb.AppendLine($@"  { dllTypeInfoModels.Name.ToLower() }PostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{{}});");
            sb.AppendLine($@"  { dllTypeInfoModels.Name.ToLower() }DeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{{}});");
            sb.AppendLine($@"  { dllTypeInfoModels.Name.ToLower() }List: { dllTypeInfoModels.Name }[] = [];");
            sb.AppendLine(@"  private oldURL: string;");
            sb.AppendLine(@"  private router: Router;");
            sb.AppendLine(@"");
            sb.AppendLine(@"  /* Constructors */");
            sb.AppendLine(@"  constructor(private httpClient: HttpClient) {");
            sb.AppendLine($@"    LoadLocales{ dllTypeInfoModels.Name }Text(this);");
            sb.AppendLine($@"    this.{ dllTypeInfoModels.Name.ToLower() }TextModel$.next(<{ dllTypeInfoModels.Name }TextModel>{{ Title: ""Something2 for text"" }});") ;
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine(@"  /* Functions public */");
            sb.AppendLine($@"  Get{ dllTypeInfoModels.Name }List(router: Router) {{");
            sb.AppendLine($@"    this.BeforeHttpClient(this.{ dllTypeInfoModels.Name.ToLower() }GetModel$, router);");
            sb.AppendLine(@"");
            sb.AppendLine($@"    return this.httpClient.get<{ dllTypeInfoModels.Name }[]>('/api/{ dllTypeInfoModels.Name }').pipe(");
            sb.AppendLine(@"      map((x: any) => {");
            sb.AppendLine($@"        this.DoSuccess(this.{ dllTypeInfoModels.Name.ToLower() }GetModel$, x, 'Get', null);");
            sb.AppendLine(@"      }),");
            sb.AppendLine(@"      catchError(e => of(e).pipe(map(e => {");
            sb.AppendLine($@"        this.DoCatchError(this.{ dllTypeInfoModels.Name.ToLower() }GetModel$, e, 'Get');");
            sb.AppendLine(@"      })))");
            sb.AppendLine(@"    );");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine($@"  Put{ dllTypeInfoModels.Name }({ dllTypeInfoModels.Name.ToLower() }: { dllTypeInfoModels.Name }, router: Router) {{");
            sb.AppendLine($@"    this.BeforeHttpClient(this.{ dllTypeInfoModels.Name.ToLower() }PutModel$, router);");
            sb.AppendLine(@"");
            sb.AppendLine($@"    return this.httpClient.put<{ dllTypeInfoModels.Name }>('/api/{ dllTypeInfoModels.Name }', { dllTypeInfoModels.Name.ToLower() }, {{ headers: new HttpHeaders() }}).pipe(");
            sb.AppendLine(@"      map((x: any) => {");
            sb.AppendLine($@"        this.DoSuccess(this.{ dllTypeInfoModels.Name.ToLower() }PutModel$, x, 'Put', { dllTypeInfoModels.Name.ToLower() });");
            sb.AppendLine(@"      }),");
            sb.AppendLine(@"      catchError(e => of(e).pipe(map(e => {");
            sb.AppendLine($@"        this.DoCatchError(this.{ dllTypeInfoModels.Name.ToLower() }PutModel$, e, 'Put');");
            sb.AppendLine(@"      })))");
            sb.AppendLine(@"    );");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine($@"  Post{ dllTypeInfoModels.Name }({ dllTypeInfoModels.Name.ToLower() }: { dllTypeInfoModels.Name }, router: Router) {{");
            sb.AppendLine($@"    this.BeforeHttpClient(this.{ dllTypeInfoModels.Name.ToLower() }PostModel$, router);");
            sb.AppendLine(@"");
            sb.AppendLine($@"    return this.httpClient.post<{ dllTypeInfoModels.Name }>('/api/{ dllTypeInfoModels.Name }', { dllTypeInfoModels.Name.ToLower() }, {{ headers: new HttpHeaders() }}).pipe(");
            sb.AppendLine(@"      map((x: any) => {");
            sb.AppendLine($@"        this.DoSuccess(this.{ dllTypeInfoModels.Name.ToLower() }PostModel$, x, 'Post', { dllTypeInfoModels.Name.ToLower() });");
            sb.AppendLine(@"      }),");
            sb.AppendLine(@"      catchError(e => of(e).pipe(map(e => {");
            sb.AppendLine($@"        this.DoCatchError(this.{ dllTypeInfoModels.Name.ToLower() }PostModel$, e, 'Post');");
            sb.AppendLine(@"      })))");
            sb.AppendLine(@"    );");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine($@"  Delete{ dllTypeInfoModels.Name }({ dllTypeInfoModels.Name.ToLower() }: { dllTypeInfoModels.Name }, router: Router) {{");
            sb.AppendLine($@"    this.BeforeHttpClient(this.{ dllTypeInfoModels.Name.ToLower() }DeleteModel$, router);");
            sb.AppendLine(@"");
            sb.AppendLine($@"    return this.httpClient.delete<boolean>(`/api/{ dllTypeInfoModels.Name }/${{ { dllTypeInfoModels.Name.ToLower() }.{ dllTypeInfoModels.Name }ID }}`).pipe(");
            sb.AppendLine(@"      map((x: any) => {");
            sb.AppendLine($@"        this.DoSuccess(this.{ dllTypeInfoModels.Name.ToLower() }DeleteModel$, x, 'Delete', { dllTypeInfoModels.Name.ToLower() });");
            sb.AppendLine(@"      }),");
            sb.AppendLine(@"      catchError(e => of(e).pipe(map(e => {");
            sb.AppendLine($@"        this.DoCatchError(this.{ dllTypeInfoModels.Name.ToLower() }DeleteModel$, e, 'Delete');");
            sb.AppendLine(@"      })))");
            sb.AppendLine(@"    );");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine(@"  /* Functions private */");
            sb.AppendLine(@"  private BeforeHttpClient(httpRequestModel$: BehaviorSubject<HttpRequestModel>, router: Router) {");
            sb.AppendLine(@"    this.router = router;");
            sb.AppendLine(@"    this.oldURL = router.url;");
            sb.AppendLine(@"    httpRequestModel$.next(<HttpRequestModel>{ Working: true, Error: null, Status: null });");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine(@"  private DoCatchError(httpRequestModel$: BehaviorSubject<HttpRequestModel>, e: any, command: string) {");
            sb.AppendLine($@"    this.{ dllTypeInfoModels.Name.ToLower() }ListModel$.next(null);");
            sb.AppendLine(@"    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: <HttpErrorResponse>e, Status: 'Error' });");
            sb.AppendLine(@"");
            sb.AppendLine($@"    this.{ dllTypeInfoModels.Name.ToLower() }List = [];");
            sb.AppendLine($@"    console.debug(`{ dllTypeInfoModels.Name } ${{ command }} ERROR. Return: ${{ <HttpErrorResponse>e }}`);");
            sb.AppendLine(@"    this.DoReload();");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine(@"  private DoReload() {");
            sb.AppendLine(@"    this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {");
            sb.AppendLine(@"      this.router.navigate([`/${this.oldURL}`]);");
            sb.AppendLine(@"    });");
            sb.AppendLine(@"  }");
            sb.AppendLine(@"");
            sb.AppendLine($@"  private DoSuccess(httpRequestModel$: BehaviorSubject<HttpRequestModel>, x: any, command: string, { dllTypeInfoModels.Name.ToLower() }?: { dllTypeInfoModels.Name }) {{");
            sb.AppendLine($@"    console.debug(`{ dllTypeInfoModels.Name } ${{ command }} OK. Return: ${{ x }}`);");
            sb.AppendLine(@"    if (command === 'Get') {");
            sb.AppendLine($@"      this.{ dllTypeInfoModels.Name.ToLower() }ListModel$.next(<{ dllTypeInfoModels.Name }[]>x);");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"    if (command === 'Put') {");
            sb.AppendLine($@"      this.{ dllTypeInfoModels.Name.ToLower() }ListModel$.getValue()[0] = <{ dllTypeInfoModels.Name }>x;");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"    if (command === 'Post') {");
            sb.AppendLine($@"      this.{ dllTypeInfoModels.Name.ToLower() }ListModel$.getValue().push(<{ dllTypeInfoModels.Name }>x);");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"    if (command === 'Delete') {");
            sb.AppendLine($@"      const index = this.{ dllTypeInfoModels.Name.ToLower() }ListModel$.getValue().indexOf({ dllTypeInfoModels.Name.ToLower() });");
            sb.AppendLine($@"      this.{ dllTypeInfoModels.Name.ToLower() }ListModel$.getValue().splice(index, 1);");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"");
            sb.AppendLine($@"    this.{ dllTypeInfoModels.Name.ToLower() }ListModel$.next(this.{ dllTypeInfoModels.Name.ToLower() }ListModel$.getValue());");
            sb.AppendLine(@"    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: null, Status: 'ok' });");
            sb.AppendLine($@"    this.{ dllTypeInfoModels.Name.ToLower() }List = this.{ dllTypeInfoModels.Name.ToLower() }ListModel$.getValue();");
            sb.AppendLine(@"    this.DoReload();");
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

            FileInfo fiOutputGen = new FileInfo(Config.GetValue<string>("ServiceFileName").Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()).Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()));
            using (StreamWriter sw2 = fiOutputGen.CreateText())
            {
                sw2.Write(sb.ToString());
                ActionCommandDBService.ExecutionStatusText.AppendLine($"{ string.Format(CultureServicesRes.Created_, fiOutputGen.FullName) }");
            }

            fiOutputGen = new FileInfo(Config.GetValue<string>("ServiceFileName").Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()).Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()));
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
