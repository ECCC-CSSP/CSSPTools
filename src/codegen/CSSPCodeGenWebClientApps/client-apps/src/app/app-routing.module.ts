import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShellComponent } from './components/shell';
import { NoPageFoundComponent } from './components/no-page-found/no-page-found.component';

const routes: Routes = [
  {
    path: 'en-CA', component: ShellComponent, children: [
      { path: 'login', loadChildren: () => import('./components/auth/login/login.module').then(mod => mod.LoginModule) },
      { path: 'register', loadChildren: () => import('./components/auth/register/register.module').then(mod => mod.RegisterModule) },
      { path: 'enums', loadChildren: () => import('./components/enums/enums.module').then(mod => mod.EnumsModule) },
      { path: 'models', loadChildren: () => import('./components/models/models.module').then(mod => mod.ModelsModule) },
      { path: 'services', loadChildren: () => import('./components/services/services.module').then(mod => mod.ServicesModule) },
    ]
  },
  {
    path: 'fr-CA', component: ShellComponent, children: [
      { path: 'login', loadChildren: () => import('./components/auth/login/login.module').then(mod => mod.LoginModule) },
      { path: 'register', loadChildren: () => import('./components/auth/register/register.module').then(mod => mod.RegisterModule) },
      { path: 'enums', loadChildren: () => import('./components/enums/enums.module').then(mod => mod.EnumsModule) },
      { path: 'models', loadChildren: () => import('./components/models/models.module').then(mod => mod.ModelsModule) },
      { path: 'services', loadChildren: () => import('./components/services/services.module').then(mod => mod.ServicesModule) },
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
