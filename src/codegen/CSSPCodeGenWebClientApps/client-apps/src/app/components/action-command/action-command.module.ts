import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ActionCommandRoutingModule } from './action-command-routing.module';
import { MaterialModule } from 'src/app/app-material.module';
import { ActionCommandComponent } from './action-command.component';

@NgModule({
  declarations: [ ActionCommandComponent ],
  imports: [
    CommonModule,
    RouterModule,
    ActionCommandRoutingModule,
    MaterialModule
  ]
})
export class ActionCommandModule { }
