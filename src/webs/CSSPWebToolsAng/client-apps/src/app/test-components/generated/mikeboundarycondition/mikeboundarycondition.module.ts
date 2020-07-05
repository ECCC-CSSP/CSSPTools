/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MikeBoundaryConditionRoutingModule } from './mikeboundarycondition-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { MikeBoundaryConditionComponent } from './mikeboundarycondition.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MikeBoundaryConditionEditComponent } from './mikeboundarycondition-edit.component';

@NgModule({
  declarations: [MikeBoundaryConditionComponent, MikeBoundaryConditionEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    MikeBoundaryConditionRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class MikeBoundaryConditionModule { }
