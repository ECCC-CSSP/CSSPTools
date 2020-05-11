import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DotNetComponent } from './dotnet.component';

const routes: Routes = [
  { path: '', component: DotNetComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DotNetRoutingModule { }
