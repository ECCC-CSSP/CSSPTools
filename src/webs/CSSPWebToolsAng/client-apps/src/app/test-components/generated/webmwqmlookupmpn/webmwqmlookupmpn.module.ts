/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { WebMWQMLookupMPNRoutingModule } from './webmwqmlookupmpn-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { WebMWQMLookupMPNComponent } from './webmwqmlookupmpn.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { WebMWQMLookupMPNEditComponent } from './webmwqmlookupmpn-edit.component';

@NgModule({
  declarations: [WebMWQMLookupMPNComponent, WebMWQMLookupMPNEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    WebMWQMLookupMPNRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class WebMWQMLookupMPNModule { }
