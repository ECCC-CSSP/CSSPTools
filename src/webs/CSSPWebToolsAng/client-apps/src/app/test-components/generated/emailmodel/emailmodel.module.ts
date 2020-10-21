/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { EmailModelRoutingModule } from './emailmodel-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { EmailModelComponent } from './emailmodel.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmailModelEditComponent } from './emailmodel-edit.component';

@NgModule({
  declarations: [EmailModelComponent, EmailModelEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    EmailModelRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class EmailModelModule { }
