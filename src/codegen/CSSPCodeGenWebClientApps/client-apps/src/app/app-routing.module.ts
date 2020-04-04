import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShellComponent } from './components/shell';

const routes: Routes = [
  {
    path: 'en-CA', component: ShellComponent, children: [
      { path: 'code', loadChildren: () => import('./components/code/code.module').then(mod => mod.CodeModule) },
      { path: 'code2', loadChildren: () => import('./components/code2/code.module').then(mod => mod.Code2Module) },
      { path: 'code3', loadChildren: () => import('./components/code3/code.module').then(mod => mod.Code3Module) },
    ]
  },
  {
    path: 'fr-CA', component: ShellComponent, children: [
      { path: 'code', loadChildren: () => import('./components/code/code.module').then(mod => mod.CodeModule) },
      { path: 'code2', loadChildren: () => import('./components/code2/code.module').then(mod => mod.Code2Module) },
      { path: 'code3', loadChildren: () => import('./components/code3/code.module').then(mod => mod.Code3Module) },
    ]
  },
  { path: '', redirectTo: 'en-CA', pathMatch: 'full' },
  { path: '**', component: NoPageFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
