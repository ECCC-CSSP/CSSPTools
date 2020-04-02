import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Code3Component } from './code.component';

const routes: Routes = [
  { path: '', component: Code3Component }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CodeRoutingModule { }
