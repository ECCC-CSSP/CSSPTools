/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { EmailDistributionListRoutingModule } from './emaildistributionlist-routing.module';
import { MaterialModule } from '../../../app-material.module';
import { EmailDistributionListComponent } from './emaildistributionlist.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmailDistributionListEditComponent } from './emaildistributionlist-edit.component';

@NgModule({
  declarations: [EmailDistributionListComponent, EmailDistributionListEditComponent],
  imports: [
    CommonModule,
    RouterModule,
    EmailDistributionListRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class EmailDistributionListModule { }
