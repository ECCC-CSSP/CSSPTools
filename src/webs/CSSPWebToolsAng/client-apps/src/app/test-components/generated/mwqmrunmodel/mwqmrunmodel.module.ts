/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MWQMRunModelRoutingModule } from './mwqmrunmodel-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { MWQMRunModelComponent } from './mwqmrunmodel.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MWQMRunModelEditComponent } from './mwqmrunmodel-edit.component';

@NgModule({
  declarations: [MWQMRunModelComponent, MWQMRunModelEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    MWQMRunModelRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class MWQMRunModelModule { }
