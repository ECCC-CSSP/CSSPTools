/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MikeScenarioResultRoutingModule } from './mikescenarioresult-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { MikeScenarioResultComponent } from './mikescenarioresult.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MikeScenarioResultEditComponent } from './mikescenarioresult-edit.component';

@NgModule({
  declarations: [MikeScenarioResultComponent, MikeScenarioResultEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    MikeScenarioResultRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class MikeScenarioResultModule { }
