import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GenerateAngularComponent } from './generate-angular.component';

const routes: Routes = [
  { path: '', component: GenerateAngularComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GenerateAngularRoutingModule { }
