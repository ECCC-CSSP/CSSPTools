/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { WebMWQMSiteRoutingModule } from './webmwqmsite-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { WebMWQMSiteComponent } from './webmwqmsite.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { WebMWQMSiteEditComponent } from './webmwqmsite-edit.component';

@NgModule({
  declarations: [WebMWQMSiteComponent, WebMWQMSiteEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    WebMWQMSiteRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class WebMWQMSiteModule { }
