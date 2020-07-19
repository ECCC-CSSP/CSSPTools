/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { WebDrogueRunRoutingModule } from './webdroguerun-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { WebDrogueRunComponent } from './webdroguerun.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { WebDrogueRunEditComponent } from './webdroguerun-edit.component';

@NgModule({
  declarations: [WebDrogueRunComponent, WebDrogueRunEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    WebDrogueRunRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class WebDrogueRunModule { }
