import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GenerateModelsRoutingModule } from './generate-models-routing.module';
import { MaterialModule } from 'src/app/app-material.module';
import { GenerateModelsComponent } from './generate-models.component';

@NgModule({
  declarations: [ GenerateModelsComponent ],
  imports: [
    CommonModule,
    RouterModule,
    GenerateModelsRoutingModule,
    MaterialModule
  ]
})
export class GenerateModelsModule { }
