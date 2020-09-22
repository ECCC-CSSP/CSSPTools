import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { ShellComponent } from './shell.component';
import { ShellRoutingModule } from './shell-routing.module';
import { SharedModule } from '../../shared.module';

@NgModule({
  declarations: [ShellComponent],
  imports: [
    RouterModule,
    ShellRoutingModule,
    SharedModule
  ]
})
export class ShellModule { }
