/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MWQMSubsectorLanguageRoutingModule } from './mwqmsubsectorlanguage-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { MWQMSubsectorLanguageComponent } from './mwqmsubsectorlanguage.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MWQMSubsectorLanguageEditComponent } from './mwqmsubsectorlanguage-edit.component';

@NgModule({
  declarations: [MWQMSubsectorLanguageComponent, MWQMSubsectorLanguageEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    MWQMSubsectorLanguageRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class MWQMSubsectorLanguageModule { }
