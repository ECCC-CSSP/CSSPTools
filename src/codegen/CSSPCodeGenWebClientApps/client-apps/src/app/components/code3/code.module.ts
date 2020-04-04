import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Code3Component } from './code.component';
import { MatButtonModule } from '@angular/material/button';
import { CodeRoutingModule } from './code-routing.module';

@NgModule({
  declarations: [ Code3Component ],
  imports: [
    CommonModule,
    RouterModule,
    MatButtonModule,
    CodeRoutingModule
  ]
})
export class Code3Module { }