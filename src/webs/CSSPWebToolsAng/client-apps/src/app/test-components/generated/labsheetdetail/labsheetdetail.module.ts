/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { LabSheetDetailRoutingModule } from './labsheetdetail-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { LabSheetDetailComponent } from './labsheetdetail.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LabSheetDetailEditComponent } from './labsheetdetail-edit.component';

@NgModule({
  declarations: [LabSheetDetailComponent, LabSheetDetailEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    LabSheetDetailRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class LabSheetDetailModule { }
