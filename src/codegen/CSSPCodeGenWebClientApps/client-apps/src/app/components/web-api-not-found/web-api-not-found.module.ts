import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WebApiNotFoundComponent } from './web-api-not-found.component';
import { MaterialModule } from 'src/app/app-material.module';
import { RouterModule } from '@angular/router';
import { WebApiNotFoundRoutingModule } from './web-api-not-found-routing.module';

@NgModule({
  declarations: [WebApiNotFoundComponent],
  imports: [
    CommonModule,
    RouterModule,
    WebApiNotFoundRoutingModule,
    MaterialModule
  ]
})
export class WebApiNotFoundModule { }
