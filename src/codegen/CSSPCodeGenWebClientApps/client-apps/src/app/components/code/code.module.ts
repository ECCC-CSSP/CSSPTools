import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CodeComponent } from './code.component';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [ CodeComponent ],
  imports: [
    CommonModule,
    RouterModule,
    MatButtonModule
  ]
})
export class CodeModule { }
