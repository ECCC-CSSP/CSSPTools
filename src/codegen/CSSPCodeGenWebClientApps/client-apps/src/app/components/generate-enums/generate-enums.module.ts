import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GenerateEnumsRoutingModule } from './generate-enums-routing.module';
import { MaterialModule } from 'src/app/app-material.module';
import { GenerateEnumsComponent } from './generate-enums.component';

@NgModule({
  declarations: [ GenerateEnumsComponent ],
  imports: [
    CommonModule,
    RouterModule,
    GenerateEnumsRoutingModule,
    MaterialModule
  ]
})
export class GenerateEnumsModule { }
