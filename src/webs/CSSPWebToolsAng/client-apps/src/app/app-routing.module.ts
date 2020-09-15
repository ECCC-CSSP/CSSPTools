import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShellComponent } from './components/shell';

const routes: Routes = [
  {
    path: 'en-CA', component: ShellComponent, children: [
      { path: 'home', loadChildren: () => import('./components/home/home.module').then(mod => mod.HomeModule) },
      { path: 'root', loadChildren: () => import('./components/root/root.module').then(mod => mod.RootModule) },
      { path: 'webapinotfound', loadChildren: () => import('./components/web-api-not-found/web-api-not-found.module').then(mod => mod.WebApiNotFoundModule) },
    ]
  },
  {
    path: 'fr-CA', component: ShellComponent, children: [
      { path: 'home', loadChildren: () => import('./components/home/home.module').then(mod => mod.HomeModule) },
      { path: 'root', loadChildren: () => import('./components/root/root.module').then(mod => mod.RootModule) },
      { path: 'webapinotfound', loadChildren: () => import('./components/web-api-not-found/web-api-not-found.module').then(mod => mod.WebApiNotFoundModule) },
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
