import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GenerateWithDocRoutingModule } from './generate-with-doc-routing.module';
import { MaterialModule } from 'src/app/app-material.module';
import { GenerateWithDocComponent } from './generate-with-doc.component';

@NgModule({
  declarations: [ GenerateWithDocComponent ],
  imports: [
    CommonModule,
    RouterModule,
    GenerateWithDocRoutingModule,
    MaterialModule
  ]
})
export class GenerateWithDocModule { }
