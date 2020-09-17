import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { RootRoutingModule } from './root-routing.module';
import { MaterialModule } from '../../app-material.module';
import { RootComponent } from './root.component';

@NgModule({
  declarations: [ RootComponent ],
  imports: [
    CommonModule,
    RouterModule,
    RootRoutingModule,
    MaterialModule
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class RootModule { }
