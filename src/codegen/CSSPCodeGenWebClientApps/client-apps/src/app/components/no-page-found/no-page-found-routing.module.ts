import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NoPageFoundComponent } from './no-page-found.component';

const routes: Routes = [
  { path: '', component: NoPageFoundComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NoPageFoundRoutingModule { }
