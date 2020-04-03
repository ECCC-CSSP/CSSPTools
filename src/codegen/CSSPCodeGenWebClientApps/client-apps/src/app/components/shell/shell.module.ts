import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShellComponent } from './shell.component';
import { RouterModule } from '@angular/router';
import { MatDrawerContainer, MatDrawerContent, MatDrawer } from '@angular/material/sidenav';
import { MatIcon } from '@angular/material/icon';
import { MatToolbar } from '@angular/material/toolbar';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';

@NgModule({
  declarations: [ShellComponent,
    MatDrawerContainer,
    MatDrawerContent,
    MatDrawer,
    MatIcon,
    MatToolbar,
    MatMenu,
    MatMenuTrigger],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class ShellModule { }
