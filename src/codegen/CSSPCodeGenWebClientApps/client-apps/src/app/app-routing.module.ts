import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShellComponent } from './components/shell';

const routes: Routes = [
  {
    path: 'en-CA', component: ShellComponent, children: [
      { path: 'codeenums', loadChildren: () => import('./components/codeenums/codeenums.module').then(mod => mod.CodeEnumsModule) },
    ]
  },
  {
    path: 'fr-CA', component: ShellComponent, children: [
      { path: 'codeenums', loadChildren: () => import('./components/codeenums/codeenums.module').then(mod => mod.CodeEnumsModule) },
    ]
  },
  { path: '', redirectTo: 'en-CA', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
