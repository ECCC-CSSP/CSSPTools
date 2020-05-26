import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShellComponent } from './shell.component';
import { RouterModule } from '@angular/router';
import { MaterialModule } from 'src/app/app-material.module';
import { ShellRoutingModule } from './shell-routing.module';

@NgModule({
  declarations: [ShellComponent],
  imports: [
    CommonModule,
    RouterModule,
    ShellRoutingModule,
    MaterialModule
  ],
  exports: [ShellComponent]
})
export class ShellModule { }
