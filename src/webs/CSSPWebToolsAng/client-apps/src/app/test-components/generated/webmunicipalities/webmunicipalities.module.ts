/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { WebMunicipalitiesRoutingModule } from './webmunicipalities-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { WebMunicipalitiesComponent } from './webmunicipalities.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { WebMunicipalitiesEditComponent } from './webmunicipalities-edit.component';

@NgModule({
  declarations: [WebMunicipalitiesComponent, WebMunicipalitiesEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    WebMunicipalitiesRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class WebMunicipalitiesModule { }
