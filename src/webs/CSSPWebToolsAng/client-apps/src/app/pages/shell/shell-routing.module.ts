import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { fileURLToPath } from 'url';
import { ShellComponent } from './shell.component';

const routes: Routes = [
  { path: '', component: ShellComponent, children: [
    { path: 'root/:TVItemID/:Properties', loadChildren: () => import('../../pages/root/root.module').then(mod => mod.RootModule) },
    { path: 'country/:TVItemID/:Properties', loadChildren: () => import('../../pages/country/country.module').then(mod => mod.CountryModule) },
    { path: 'province/:TVItemID/:Properties', loadChildren: () => import('../../pages/province/province.module').then(mod => mod.ProvinceModule) },
    { path: 'webapinotfound', loadChildren: () => import('../../pages/web-api-not-found/web-api-not-found.module').then(mod => mod.WebApiNotFoundModule) },
    { path: '', redirectTo: 'root/1/active,map,satellite,labels,size50', pathMatch: 'full' } 
  ]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShellRoutingModule { }
