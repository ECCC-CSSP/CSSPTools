import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShellComponent } from './shell.component';
import { RouterModule } from '@angular/router';
import { MatDrawerContainer, MatDrawerContent, MatDrawer } from '@angular/material/sidenav';
import { MatIcon } from '@angular/material/icon';

@NgModule({
  declarations: [ShellComponent,
    MatDrawerContainer,
    MatDrawerContent,
    MatDrawer,
    MatIcon],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class ShellModule { }
