/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CSSPForeignKeyAttributeRoutingModule } from './csspforeignkeyattribute-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { CSSPForeignKeyAttributeComponent } from './csspforeignkeyattribute.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CSSPForeignKeyAttributeEditComponent } from './csspforeignkeyattribute-edit.component';

@NgModule({
  declarations: [CSSPForeignKeyAttributeComponent, CSSPForeignKeyAttributeEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    CSSPForeignKeyAttributeRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class CSSPForeignKeyAttributeModule { }
