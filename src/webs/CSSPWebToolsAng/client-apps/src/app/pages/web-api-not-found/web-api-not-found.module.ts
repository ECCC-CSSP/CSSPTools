import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { WebApiNotFoundComponent } from './web-api-not-found.component';
import { MaterialModule } from '../../app-material.module';
import { WebApiNotFoundRoutingModule } from './web-api-not-found-routing.module';

@NgModule({
  declarations: [WebApiNotFoundComponent],
  imports: [
    CommonModule,
    RouterModule,
    WebApiNotFoundRoutingModule,
    MaterialModule
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class WebApiNotFoundModule { }
