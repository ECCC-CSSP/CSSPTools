import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HomeRoutingModule } from './home-routing.module';
import { MaterialModule } from '../../app-material.module';
import { HomeComponent } from './home.component';

@NgModule({
  declarations: [ HomeComponent ],
  imports: [
    CommonModule,
    RouterModule,
    HomeRoutingModule,
    MaterialModule
  ]
})
export class HomeModule { }
