/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DrogueRunPositionComponent } from './droguerunposition.component';
import { AuthGuard } from '../../../guards';

const routes: Routes = [
  { path: '', component: DrogueRunPositionComponent, canActivate: [AuthGuard]  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DrogueRunPositionRoutingModule { }
