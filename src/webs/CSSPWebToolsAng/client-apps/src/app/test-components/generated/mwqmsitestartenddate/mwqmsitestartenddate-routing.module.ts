/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MWQMSiteStartEndDateComponent } from './mwqmsitestartenddate.component';
import { AuthGuard } from '../../../guards';

const routes: Routes = [
  { path: '', component: MWQMSiteStartEndDateComponent, canActivate: [AuthGuard]  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MWQMSiteStartEndDateRoutingModule { }
