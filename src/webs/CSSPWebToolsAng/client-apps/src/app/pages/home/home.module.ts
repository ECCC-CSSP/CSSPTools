import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HomeRoutingModule } from './home-routing.module';
import { MaterialModule } from '../../app-material.module';
import { HomeComponent } from './home.component';
import { AlloComponent } from '../../components/allo/allo.component';
import { SearchComponent } from 'src/app/components/search/search.component';

@NgModule({
  declarations: [ HomeComponent, AlloComponent, SearchComponent ],
  imports: [
    CommonModule,
    RouterModule,
    HomeRoutingModule,
    MaterialModule
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class HomeModule { }
