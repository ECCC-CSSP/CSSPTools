import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home-routing.module';
import { MatIcon } from '@angular/material/icon';

@NgModule({
  declarations: [HomeComponent,
    MatIcon],
  imports: [
    CommonModule,
    HomeRoutingModule
  ]
})
export class HomeModule { }
