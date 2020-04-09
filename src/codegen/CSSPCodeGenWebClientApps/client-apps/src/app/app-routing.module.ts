import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShellComponent } from './components/shell';
import { NoPageFoundComponent } from './components/no-page-found/no-page-found.component';

const routes: Routes = [
  {
    path: 'en-CA', component: ShellComponent, children: [
      { path: 'login', loadChildren: () => import('./components/auth/login/login.module').then(mod => mod.LoginModule) },
      { path: 'register', loadChildren: () => import('./components/auth/register/register.module').then(mod => mod.RegisterModule) },
      { path: 'generate-enums', loadChildren: () => import('./components/generate-enums/generate-enums.module').then(mod => mod.GenerateEnumsModule) },
      { path: 'generate-models', loadChildren: () => import('./components/generate-models/generate-models.module').then(mod => mod.GenerateModelsModule) },
      { path: 'generate-services', loadChildren: () => import('./components/generate-services/generate-services.module').then(mod => mod.GenerateServicesModule) },
      { path: 'generate-webapi', loadChildren: () => import('./components/generate-web-api/generate-web-api.module').then(mod => mod.GenerateWebAPIModule) },
      { path: 'generate-angular', loadChildren: () => import('./components/generate-angular/generate-angular.module').then(mod => mod.GenerateAngularModule) },
    ]
  },
  {
    path: 'fr-CA', component: ShellComponent, children: [
      { path: 'login', loadChildren: () => import('./components/auth/login/login.module').then(mod => mod.LoginModule) },
      { path: 'register', loadChildren: () => import('./components/auth/register/register.module').then(mod => mod.RegisterModule) },
      { path: 'generate-enums', loadChildren: () => import('./components/generate-enums/generate-enums.module').then(mod => mod.GenerateEnumsModule) },
      { path: 'generate-models', loadChildren: () => import('./components/generate-models/generate-models.module').then(mod => mod.GenerateModelsModule) },
      { path: 'generate-services', loadChildren: () => import('./components/generate-services/generate-services.module').then(mod => mod.GenerateServicesModule) },
      { path: 'generate-webapi', loadChildren: () => import('./components/generate-web-api/generate-web-api.module').then(mod => mod.GenerateWebAPIModule) },
      { path: 'generate-angular', loadChildren: () => import('./components/generate-angular/generate-angular.module').then(mod => mod.GenerateAngularModule) },
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
