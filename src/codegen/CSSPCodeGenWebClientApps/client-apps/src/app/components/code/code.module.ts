import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CodeComponent } from './code.component';
import { MatButtonModule } from '@angular/material/button';
import { CodeRoutingModule } from './code-routing.module';

@NgModule({
  declarations: [ CodeComponent ],
  imports: [
    CommonModule,
    RouterModule,
    MatButtonModule,
    CodeRoutingModule
  ]
})
export class CodeModule { }
