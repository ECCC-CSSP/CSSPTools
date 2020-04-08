import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GenerateModelsComponent } from './generate-models.component';

const routes: Routes = [
  { path: '', component: GenerateModelsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GenerateModelsRoutingModule { }
