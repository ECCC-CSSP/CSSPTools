/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TVFileLanguageComponent } from './tvfilelanguage.component';
import { AuthGuard } from '../../../guards';

const routes: Routes = [
  { path: '', component: TVFileLanguageComponent, canActivate: [AuthGuard]  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TVFileLanguageRoutingModule { }
