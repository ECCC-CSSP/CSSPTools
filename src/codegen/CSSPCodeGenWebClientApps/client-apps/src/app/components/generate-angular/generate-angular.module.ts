import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GenerateAngularRoutingModule } from './generate-angular-routing.module';
import { MaterialModule } from 'src/app/app-material.module';
import { GenerateAngularComponent } from './generate-angular.component';

@NgModule({
  declarations: [ GenerateAngularComponent ],
  imports: [
    CommonModule,
    RouterModule,
    GenerateAngularRoutingModule,
    MaterialModule
  ]
})
export class GenerateAngularModule { }
