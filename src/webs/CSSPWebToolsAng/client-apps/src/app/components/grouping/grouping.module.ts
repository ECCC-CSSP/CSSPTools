import { NgModule } from '@angular/core';
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
  ]
})
export class GroupingModule { }
