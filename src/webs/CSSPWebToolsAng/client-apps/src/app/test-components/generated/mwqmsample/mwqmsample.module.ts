/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MWQMSampleRoutingModule } from './mwqmsample-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { MWQMSampleComponent } from './mwqmsample.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MWQMSampleEditComponent } from './mwqmsample-edit.component';

@NgModule({
  declarations: [MWQMSampleComponent, MWQMSampleEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    MWQMSampleRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class MWQMSampleModule { }
