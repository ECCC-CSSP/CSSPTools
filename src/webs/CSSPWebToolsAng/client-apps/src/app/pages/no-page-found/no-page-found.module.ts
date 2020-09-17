import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { NoPageFoundComponent } from './no-page-found.component';
import { MaterialModule } from './../../app-material.module';
import { NoPageFoundRoutingModule } from './no-page-found-routing.module';

@NgModule({
  declarations: [NoPageFoundComponent],
  imports: [
    CommonModule,
    RouterModule,
    NoPageFoundRoutingModule,
    MaterialModule
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class NoPageFoundModule { }
