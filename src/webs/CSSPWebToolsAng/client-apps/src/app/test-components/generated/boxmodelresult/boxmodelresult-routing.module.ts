/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BoxModelResultComponent } from './boxmodelresult.component';
import { AuthGuard } from '../../../guards';

const routes: Routes = [
  { path: '', component: BoxModelResultComponent, canActivate: [AuthGuard]  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BoxModelResultRoutingModule { }
