import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShellComponent } from './components/shell';

const routes: Routes = [
  {
    path: 'en-CA', component: ShellComponent, children: [
      { path: 'code', loadChildren: () => import('./components/code/code.module').then(mod => mod.CodeModule) },
    ]
  },
  {
    path: 'fr-CA', component: ShellComponent, children: [
      { path: 'code', loadChildren: () => import('./components/code/code.module').then(mod => mod.CodeModule) },
    ]
  },
  { path: '', redirectTo: 'en-CA', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
