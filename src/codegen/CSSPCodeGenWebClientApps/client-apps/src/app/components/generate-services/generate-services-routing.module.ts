import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GenerateServicesComponent } from './generate-services.component';

const routes: Routes = [
  { path: '', component: GenerateServicesComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GenerateServicesRoutingModule { }
