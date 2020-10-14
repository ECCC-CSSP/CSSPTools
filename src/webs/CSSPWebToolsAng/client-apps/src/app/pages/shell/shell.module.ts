import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { ShellComponent } from './shell.component';
import { ShellRoutingModule } from './shell-routing.module';
import { SharedModule } from '../../shared.module';
import { LoggedInContactComponent } from '../../components/logged-in-contact/logged-in-contact.component';
import { BreadCrumbComponent } from '../../components/bread-crumb/bread-crumb.component';
import { MapComponent } from '../../components/map/map.component';
import { GoogleMapsModule } from '@angular/google-maps';
import { SideNavMenuComponent } from '../../components/sidenav-menu/sidenav-menu.component';

@NgModule({
  declarations: [
    ShellComponent, 
    LoggedInContactComponent, 
    BreadCrumbComponent, 
    MapComponent, 
    SideNavMenuComponent],
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
