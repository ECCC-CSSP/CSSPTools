import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShellComponent } from './shell';

const routes: Routes = [
  {
    path: 'en-CA', component: ShellComponent, children: [
      { path: 'allo', loadChildren: () => import('./allo/allo.module').then(mod => mod.AlloModule) },
      { path: 'bonjour', loadChildren: () => import('./bonjour/bonjour.module').then(mod => mod.BonjourModule) },
      { path: 'login', loadChildren: () => import('./auth/login/login.module').then(mod => mod.LoginModule) },
      { path: 'register', loadChildren: () => import('./auth/register/register.module').then(mod => mod.RegisterModule) }
  ]
  },
  {
    path: 'fr-CA', component: ShellComponent, children: [
      { path: 'allo', loadChildren: () => import('./allo/allo.module').then(mod => mod.AlloModule) },
      { path: 'bonjour', loadChildren: () => import('./bonjour/bonjour.module').then(mod => mod.BonjourModule) },
      { path: 'login', loadChildren: () => import('./auth/login/login.module').then(mod => mod.LoginModule) },
      { path: 'register', loadChildren: () => import('./auth/register/register.module').then(mod => mod.RegisterModule) }
   ]
  },
  { path: '', redirectTo: 'en-CA', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
