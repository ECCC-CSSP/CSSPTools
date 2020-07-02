/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AspNetRoleClaimRoutingModule } from './aspnetroleclaim-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { AspNetRoleClaimComponent } from './aspnetroleclaim.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AspNetRoleClaimEditComponent } from './aspnetroleclaim-edit.component';

@NgModule({
  declarations: [AspNetRoleClaimComponent, AspNetRoleClaimEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    AspNetRoleClaimRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class AspNetRoleClaimModule { }
