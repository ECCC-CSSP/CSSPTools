import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { RegisterRoutingModule } from './register-routing.module';
import { MaterialModule } from 'src/app/app-material.module';
import { RegisterComponent } from './register.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [RegisterComponent],
  imports: [
    CommonModule,
    RouterModule,
    RegisterRoutingModule,
    ReactiveFormsModule,
    MaterialModule
  ]
})
export class RegisterModule { }
