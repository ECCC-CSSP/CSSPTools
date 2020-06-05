import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AddressRoutingModule } from './address-routing.module';
import { MaterialModule } from '../../app-material.module';
import { AddressComponent } from './address.component';

@NgModule({
  declarations: [ AddressComponent ],
  imports: [
    CommonModule,
    RouterModule,
    AddressRoutingModule,
    MaterialModule
  ]
})
export class AddressModule { }
