import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NoPageFoundComponent } from './no-page-found.component';
import { MaterialModule } from 'src/app/app-material.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [NoPageFoundComponent],
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule
  ]
})
export class NoPageFoundModule { }
