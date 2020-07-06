/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BoxModelResultRoutingModule } from './boxmodelresult-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { BoxModelResultComponent } from './boxmodelresult.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BoxModelResultEditComponent } from './boxmodelresult-edit.component';

@NgModule({
  declarations: [BoxModelResultComponent, BoxModelResultEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    BoxModelResultRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class BoxModelResultModule { }
