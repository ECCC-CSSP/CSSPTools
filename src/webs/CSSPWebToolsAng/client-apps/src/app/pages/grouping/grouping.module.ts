import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GroupingRoutingModule } from './grouping-routing.module';
import { MaterialModule } from '../../app-material.module';
import { GroupingComponent } from './grouping.component';

@NgModule({
  declarations: [ GroupingComponent ],
  imports: [
    CommonModule,
    RouterModule,
    GroupingRoutingModule,
    MaterialModule
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class GroupingModule { }
