/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TVTypeNamesAndPathComponent } from './tvtypenamesandpath.component';
import { AuthGuard } from '../../guards';

const routes: Routes = [
  { path: '', component: TVTypeNamesAndPathComponent, canActivate: [AuthGuard]  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TVTypeNamesAndPathRoutingModule { }
