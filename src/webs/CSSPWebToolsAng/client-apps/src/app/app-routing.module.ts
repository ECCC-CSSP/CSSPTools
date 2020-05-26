import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShellComponent } from './components/shell';

const routes: Routes = [
  {
    path: 'en-CA', component: ShellComponent, children: [
      { path: 'login', loadChildren: () => import('./components/auth/login/login.module').then(mod => mod.LoginModule) },
      { path: 'register', loadChildren: () => import('./components/auth/register/register.module').then(mod => mod.RegisterModule) },
      { path: 'actioncommand', loadChildren: () => import('./components/action-command/action-command.module').then(mod => mod.ActionCommandModule) },
      { path: 'webapinotfound', loadChildren: () => import('./components/web-api-not-found/web-api-not-found.module').then(mod => mod.WebApiNotFoundModule) },
      { path: '**', loadChildren: () => import('./components/no-page-found/no-page-found.module').then(mod => mod.NoPageFoundModule) },
    ]
  },
  {
    path: 'fr-CA', component: ShellComponent, children: [
      { path: 'login', loadChildren: () => import('./components/auth/login/login.module').then(mod => mod.LoginModule) },
      { path: 'register', loadChildren: () => import('./components/auth/register/register.module').then(mod => mod.RegisterModule) },
      { path: 'actioncommand', loadChildren: () => import('./components/action-command/action-command.module').then(mod => mod.ActionCommandModule) },
      { path: 'webapinotfound', loadChildren: () => import('./components/web-api-not-found/web-api-not-found.module').then(mod => mod.WebApiNotFoundModule) },
      { path: '**', loadChildren: () => import('./components/no-page-found/no-page-found.module').then(mod => mod.NoPageFoundModule) },
    ]
  },
  { path: '', redirectTo: 'en-CA', pathMatch: 'full' },
  { path: '**', loadChildren: () => import('./components/no-page-found/no-page-found.module').then(mod => mod.NoPageFoundModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
