/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MWQMSampleLanguageRoutingModule } from './mwqmsamplelanguage-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { MWQMSampleLanguageComponent } from './mwqmsamplelanguage.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MWQMSampleLanguageEditComponent } from './mwqmsamplelanguage-edit.component';

@NgModule({
  declarations: [MWQMSampleLanguageComponent, MWQMSampleLanguageEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    MWQMSampleLanguageRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class MWQMSampleLanguageModule { }
