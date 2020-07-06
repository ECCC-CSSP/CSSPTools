/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MapInfoPointRoutingModule } from './mapinfopoint-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { MapInfoPointComponent } from './mapinfopoint.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MapInfoPointEditComponent } from './mapinfopoint-edit.component';

@NgModule({
  declarations: [MapInfoPointComponent, MapInfoPointEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    MapInfoPointRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class MapInfoPointModule { }
