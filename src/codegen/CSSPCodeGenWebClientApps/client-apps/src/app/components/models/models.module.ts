import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ModelsRoutingModule } from './models-routing.module';
import { MaterialModule } from 'src/app/app-material.module';
import { ModelsComponent } from './models.component';

@NgModule({
  declarations: [ ModelsComponent ],
  imports: [
    CommonModule,
    RouterModule,
    ModelsRoutingModule,
    MaterialModule
  ]
})
export class ModelsModule { }
