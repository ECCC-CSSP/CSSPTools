import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ActionCommandComponent } from './action-command.component';

const routes: Routes = [
  { path: '', component: ActionCommandComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ActionCommandRoutingModule { }
