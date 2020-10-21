/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReportTypeModelRoutingModule } from './reporttypemodel-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { ReportTypeModelComponent } from './reporttypemodel.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ReportTypeModelEditComponent } from './reporttypemodel-edit.component';

@NgModule({
  declarations: [ReportTypeModelComponent, ReportTypeModelEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    ReportTypeModelRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class ReportTypeModelModule { }
