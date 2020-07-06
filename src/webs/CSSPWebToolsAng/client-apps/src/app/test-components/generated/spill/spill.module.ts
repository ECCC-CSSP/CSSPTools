/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SpillRoutingModule } from './spill-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { SpillComponent } from './spill.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SpillEditComponent } from './spill-edit.component';

@NgModule({
  declarations: [SpillComponent, SpillEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    SpillRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class SpillModule { }
