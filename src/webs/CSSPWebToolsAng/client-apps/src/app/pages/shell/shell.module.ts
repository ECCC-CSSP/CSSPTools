import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { ShellComponent } from './shell.component';
import { ShellRoutingModule } from './shell-routing.module';
import { SharedModule } from '../../shared.module';
import { LoggedInContactComponent } from 'src/app/components/logged-in-contact/logged-in-contact.component';
import { BreadCrumbComponent } from 'src/app/components/bread-crumb/bread-crumb.component';
import { MapComponent } from 'src/app/components/map/map.component';
import { GoogleMapsModule } from '@angular/google-maps';

@NgModule({
  declarations: [ShellComponent, LoggedInContactComponent, BreadCrumbComponent, MapComponent],
  imports: [
    RouterModule,
    ShellRoutingModule,
    SharedModule
  ],
  exports: [
    GoogleMapsModule
  ]
})
export class ShellModule { }
