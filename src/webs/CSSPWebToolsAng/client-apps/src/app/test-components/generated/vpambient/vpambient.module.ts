/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { VPAmbientRoutingModule } from './vpambient-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { VPAmbientComponent } from './vpambient.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { VPAmbientEditComponent } from './vpambient-edit.component';

@NgModule({
  declarations: [VPAmbientComponent, VPAmbientEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    VPAmbientRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class VPAmbientModule { }
