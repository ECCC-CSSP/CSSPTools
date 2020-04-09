import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GenerateWithDocComponent } from './generate-with-doc.component';

const routes: Routes = [
  { path: '', component: GenerateWithDocComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GenerateWithDocRoutingModule { }
