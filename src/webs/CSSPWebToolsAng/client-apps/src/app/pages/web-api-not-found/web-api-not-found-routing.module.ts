import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WebApiNotFoundComponent } from './web-api-not-found.component';

const routes: Routes = [
  { path: '', component: WebApiNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WebApiNotFoundRoutingModule { }
