import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { EnumsRoutingModule } from './enums-routing.module';
import { MaterialModule } from 'src/app/app-material.module';
import { EnumsComponent } from './enums.component';

@NgModule({
  declarations: [ EnumsComponent ],
  imports: [
    CommonModule,
    RouterModule,
    EnumsRoutingModule,
    MaterialModule
  ]
})
export class EnumsModule { }
