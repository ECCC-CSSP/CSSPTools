/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TideSiteRoutingModule } from './tidesite-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { TideSiteComponent } from './tidesite.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TideSiteEditComponent } from './tidesite-edit.component';

@NgModule({
  declarations: [TideSiteComponent, TideSiteEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    TideSiteRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class TideSiteModule { }
