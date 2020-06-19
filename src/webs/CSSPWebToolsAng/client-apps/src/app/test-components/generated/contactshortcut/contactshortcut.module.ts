/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ContactShortcutRoutingModule } from './contactshortcut-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { ContactShortcutComponent } from './contactshortcut.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ContactShortcutEditComponent } from './contactshortcut-edit.component';

@NgModule({
  declarations: [ContactShortcutComponent, ContactShortcutEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    ContactShortcutRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class ContactShortcutModule { }
