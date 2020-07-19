/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { WebClimateDataValueRoutingModule } from './webclimatedatavalue-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { WebClimateDataValueComponent } from './webclimatedatavalue.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { WebClimateDataValueEditComponent } from './webclimatedatavalue-edit.component';

@NgModule({
  declarations: [WebClimateDataValueComponent, WebClimateDataValueEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    WebClimateDataValueRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class WebClimateDataValueModule { }
