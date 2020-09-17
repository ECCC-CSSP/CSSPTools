import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ShellComponent } from '../shell';
import { MaterialModule } from '../../app-material.module';
import { ShellRoutingModule } from '../shell/shell-routing.module';

@NgModule({
  declarations: [ShellComponent],
  imports: [
    CommonModule,
    RouterModule,
    ShellRoutingModule,
    MaterialModule
  ],
  exports: [ShellComponent],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class ShellModule { }
