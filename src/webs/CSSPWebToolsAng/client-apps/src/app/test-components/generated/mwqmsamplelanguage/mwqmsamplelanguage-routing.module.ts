/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MWQMSampleLanguageComponent } from './mwqmsamplelanguage.component';
import { AuthGuard } from '../../../guards';

const routes: Routes = [
  { path: '', component: MWQMSampleLanguageComponent, canActivate: [AuthGuard]  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MWQMSampleLanguageRoutingModule { }
