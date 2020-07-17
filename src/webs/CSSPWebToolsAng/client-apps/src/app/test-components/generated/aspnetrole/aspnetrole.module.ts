/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AspNetRoleRoutingModule } from './aspnetrole-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { AspNetRoleComponent } from './aspnetrole.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AspNetRoleEditComponent } from './aspnetrole-edit.component';

@NgModule({
  declarations: [AspNetRoleComponent, AspNetRoleEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    AspNetRoleRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class AspNetRoleModule { }
