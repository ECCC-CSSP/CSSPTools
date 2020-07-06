/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { InfrastructureRoutingModule } from './infrastructure-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { InfrastructureComponent } from './infrastructure.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InfrastructureEditComponent } from './infrastructure-edit.component';

@NgModule({
  declarations: [InfrastructureComponent, InfrastructureEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    InfrastructureRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class InfrastructureModule { }
