import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ServicesRoutingModule } from './services-routing.module';
import { MaterialModule } from 'src/app/app-material.module';
import { ServicesComponent } from './services.component';

@NgModule({
  declarations: [ServicesComponent],
  imports: [
    CommonModule,
    RouterModule,
    ServicesRoutingModule,
    MaterialModule
  ]
})
export class ServicesModule { }
