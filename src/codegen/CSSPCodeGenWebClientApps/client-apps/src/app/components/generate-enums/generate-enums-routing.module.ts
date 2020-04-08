import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GenerateEnumsComponent } from './generate-enums.component';

const routes: Routes = [
  { path: '', component: GenerateEnumsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GenerateEnumsRoutingModule { }
