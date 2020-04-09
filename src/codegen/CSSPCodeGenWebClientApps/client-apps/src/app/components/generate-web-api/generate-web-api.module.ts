import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GenerateWebAPIRoutingModule } from './generate-web-api-routing.module';
import { MaterialModule } from 'src/app/app-material.module';
import { GenerateWebAPIComponent } from './generate-web-api.component';

@NgModule({
  declarations: [ GenerateWebAPIComponent ],
  imports: [
    CommonModule,
    RouterModule,
    GenerateWebAPIRoutingModule,
    MaterialModule
  ]
})
export class GenerateWebAPIModule { }
