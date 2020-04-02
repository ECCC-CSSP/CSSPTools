import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'code', loadChildren: () => import('../code/code.module').then(mod => mod.CodeModule) },
  { path: 'code2', loadChildren: () => import('../code2/code.module').then(mod => mod.CodeModule) },
  { path: 'code3', loadChildren: () => import('../code3/code.module').then(mod => mod.CodeModule) },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
