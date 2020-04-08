import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GenerateServicesRoutingModule } from './generate-services-routing.module';
import { MaterialModule } from 'src/app/app-material.module';
import { GenerateServicesComponent } from './generate-services.component';

@NgModule({
  declarations: [GenerateServicesComponent],
  imports: [
    CommonModule,
    RouterModule,
    GenerateServicesRoutingModule,
    MaterialModule
  ]
})
export class GenerateServicesModule { }
