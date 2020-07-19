/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { WebPolSourceGroupingRoutingModule } from './webpolsourcegrouping-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { WebPolSourceGroupingComponent } from './webpolsourcegrouping.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { WebPolSourceGroupingEditComponent } from './webpolsourcegrouping-edit.component';

@NgModule({
  declarations: [WebPolSourceGroupingComponent, WebPolSourceGroupingEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    WebPolSourceGroupingRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class WebPolSourceGroupingModule { }
