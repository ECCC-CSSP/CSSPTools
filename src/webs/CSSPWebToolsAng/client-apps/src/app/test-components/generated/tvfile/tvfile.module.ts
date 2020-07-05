/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TVFileRoutingModule } from './tvfile-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { TVFileComponent } from './tvfile.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TVFileEditComponent } from './tvfile-edit.component';

@NgModule({
  declarations: [TVFileComponent, TVFileEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    TVFileRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class TVFileModule { }
