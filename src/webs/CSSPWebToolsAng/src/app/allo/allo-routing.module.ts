import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AlloComponent } from './allo.component';

const routes: Routes = [
  { path: '', component: AlloComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AlloRoutingModule { }
