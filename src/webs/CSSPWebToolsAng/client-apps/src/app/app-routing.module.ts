import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShellComponent } from './pages/shell';

const routes: Routes = [
  {
    path: 'en-CA', component: ShellComponent, children: [
      { path: 'home', loadChildren: () => import('./pages/home/home.module').then(mod => mod.HomeModule) },
      { path: 'root', loadChildren: () => import('./pages/root/root.module').then(mod => mod.RootModule) },
      { path: 'country/:TVItemID', loadChildren: () => import('./pages/country/country.module').then(mod => mod.CountryModule) },
      { path: 'province/:TVItemID', loadChildren: () => import('./pages/province/province.module').then(mod => mod.ProvinceModule) },
      //{ path: 'search', loadChildren: () => import('./pages/search/search.module').then(mod => mod.SearchModule) },
      { path: 'webapinotfound', loadChildren: () => import('./pages/web-api-not-found/web-api-not-found.module').then(mod => mod.WebApiNotFoundModule) },
    ]
  },
  {
    path: 'fr-CA', component: ShellComponent, children: [
      { path: 'home', loadChildren: () => import('./pages/home/home.module').then(mod => mod.HomeModule) },
      { path: 'root', loadChildren: () => import('./pages/root/root.module').then(mod => mod.RootModule) },
      { path: 'country/:TVItemID', loadChildren: () => import('./pages/country/country.module').then(mod => mod.CountryModule) },
      { path: 'province/:TVItemID', loadChildren: () => import('./pages/province/province.module').then(mod => mod.ProvinceModule) },
      //{ path: 'search', loadChildren: () => import('./pages/search/search.module').then(mod => mod.SearchModule) },
      { path: 'webapinotfound', loadChildren: () => import('./pages/web-api-not-found/web-api-not-found.module').then(mod => mod.WebApiNotFoundModule) },
    ]
  },
  { path: '', redirectTo: 'en-CA', pathMatch: 'full' },
  { path: '**', loadChildren: () => import('./pages/no-page-found/no-page-found.module').then(mod => mod.NoPageFoundModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
