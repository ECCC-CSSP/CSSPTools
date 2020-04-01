import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShellComponent } from './shell.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [ ShellComponent ],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class ShellModule { }
