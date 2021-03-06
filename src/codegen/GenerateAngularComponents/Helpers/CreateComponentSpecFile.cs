﻿using GenerateCodeBaseServices.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GenerateAngularComponents
{
    public partial class Startup
    {
        private void CreateComponentSpecFile(DLLTypeInfo dllTypeInfoModels, List<DLLTypeInfo> DLLTypeInfoCSSPDBModelsList)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"/*");
            sb.AppendLine($@" * Auto generated from { AppDomain.CurrentDomain.BaseDirectory }{ AppDomain.CurrentDomain.FriendlyName}.exe");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */");
            sb.AppendLine(@"");

            sb.AppendLine(@"import { async, ComponentFixture, TestBed } from '@angular/core/testing';");
            sb.AppendLine(@"");
            sb.AppendLine($@"import {{ { dllTypeInfoModels.Name }Component }} from './{ dllTypeInfoModels.Name.ToLower() }.component';");
            sb.AppendLine(@"");
            sb.AppendLine($@"describe('{ dllTypeInfoModels.Name }Component', () => {{");
            sb.AppendLine($@"  let component: { dllTypeInfoModels.Name }Component;");
            sb.AppendLine($@"  let fixture: ComponentFixture<{ dllTypeInfoModels.Name }Component>;");
            sb.AppendLine(@"");
            sb.AppendLine(@"  beforeEach(async(() => {");
            sb.AppendLine(@"    TestBed.configureTestingModule({");
            sb.AppendLine($@"      declarations: [ { dllTypeInfoModels.Name }Component ]");
            sb.AppendLine(@"    })");
            sb.AppendLine(@"    .compileComponents();");
            sb.AppendLine(@"  }));");
            sb.AppendLine(@"");
            sb.AppendLine(@"  beforeEach(() => {");
            sb.AppendLine($@"    fixture = TestBed.createComponent({ dllTypeInfoModels.Name }Component);");
            sb.AppendLine(@"    component = fixture.componentInstance;");
            sb.AppendLine(@"    fixture.detectChanges();");
            sb.AppendLine(@"  });");
            sb.AppendLine(@"");
            sb.AppendLine(@"  it('should create', () => {");
            sb.AppendLine(@"    expect(component).toBeTruthy();");
            sb.AppendLine(@"  });");
            sb.AppendLine(@"});");

            DirectoryInfo di = new DirectoryInfo(Configuration.GetValue<string>("OutputDir").Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()));
            if (!di.Exists)
            {
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    string ErrorText = ex.Message + ex.InnerException != null ? ex.InnerException.Message : "";
                    Console.WriteLine(ErrorText);
                    return;
                }
            }

            FileInfo fiOutputGen = new FileInfo(Configuration.GetValue<string>("ComponentSpecFileName").Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()).Replace("{TypeNameLower}", dllTypeInfoModels.Name.ToLower()));
            using (StreamWriter sw2 = fiOutputGen.CreateText())
            {
                sw2.Write(sb.ToString());
                Console.WriteLine($"Created { fiOutputGen.FullName }");
            }
        }
    }
}
