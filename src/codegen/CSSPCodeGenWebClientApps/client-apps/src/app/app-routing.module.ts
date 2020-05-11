import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShellComponent } from './components/shell';
import { NoPageFoundComponent } from './components/no-page-found/no-page-found.component';

const routes: Routes = [
  {
    path: 'en-CA', component: ShellComponent, children: [
      { path: 'login', loadChildren: () => import('./components/auth/login/login.module').then(mod => mod.LoginModule) },
      { path: 'register', loadChildren: () => import('./components/auth/register/register.module').then(mod => mod.RegisterModule) },
      { path: 'dotnet', loadChildren: () => import('./components/dotnet/dotnet.module').then(mod => mod.DotNetModule) },
    ]
  },
  {
    path: 'fr-CA', component: ShellComponent, children: [
      { path: 'login', loadChildren: () => import('./components/auth/login/login.module').then(mod => mod.LoginModule) },
      { path: 'register', loadChildren: () => import('./components/auth/register/register.module').then(mod => mod.RegisterModule) },
      { path: 'dotnet', loadChildren: () => import('./components/dotnet/dotnet.module').then(mod => mod.DotNetModule) },
    ]
  },
  { path: '', redirectTo: 'en-CA', pathMatch: 'full' },
  { path: '**', component: NoPageFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
