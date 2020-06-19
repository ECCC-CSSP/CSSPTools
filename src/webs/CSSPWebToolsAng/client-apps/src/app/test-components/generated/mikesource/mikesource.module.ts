/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MikeSourceRoutingModule } from './mikesource-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { MikeSourceComponent } from './mikesource.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MikeSourceEditComponent } from './mikesource-edit.component';

@NgModule({
  declarations: [MikeSourceComponent, MikeSourceEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    MikeSourceRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class MikeSourceModule { }
