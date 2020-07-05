/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HelpDocRoutingModule } from './helpdoc-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { HelpDocComponent } from './helpdoc.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HelpDocEditComponent } from './helpdoc-edit.component';

@NgModule({
  declarations: [HelpDocComponent, HelpDocEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    HelpDocRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class HelpDocModule { }
