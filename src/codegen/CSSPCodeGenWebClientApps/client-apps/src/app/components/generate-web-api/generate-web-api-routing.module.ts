import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GenerateWebAPIComponent } from './generate-web-api.component';

const routes: Routes = [
  { path: '', component: GenerateWebAPIComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GenerateWebAPIRoutingModule { }
