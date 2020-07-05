/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MWQMSiteRoutingModule } from './mwqmsite-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { MWQMSiteComponent } from './mwqmsite.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MWQMSiteEditComponent } from './mwqmsite-edit.component';

@NgModule({
  declarations: [MWQMSiteComponent, MWQMSiteEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    MWQMSiteRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class MWQMSiteModule { }
