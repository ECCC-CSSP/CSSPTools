/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CSSPDBLocalContextComponent } from './csspdblocalcontext.component';
import { AuthGuard } from '../../../guards';

const routes: Routes = [
  { path: '', component: CSSPDBLocalContextComponent, canActivate: [AuthGuard]  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CSSPDBLocalContextRoutingModule { }