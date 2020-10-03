import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { fileURLToPath } from 'url';
import { ShellComponent } from './shell.component';

const routes: Routes = [
  { path: '', component: ShellComponent, children: [
    { path: 'root/:TVItemID', loadChildren: () => import('../../pages/root/root.module').then(mod => mod.RootModule) },
    { path: 'country/:TVItemID', loadChildren: () => import('../../pages/country/country.module').then(mod => mod.CountryModule) },
    { path: 'province/:TVItemID', loadChildren: () => import('../../pages/province/province.module').then(mod => mod.ProvinceModule) },
    { path: 'webapinotfound', loadChildren: () => import('../../pages/web-api-not-found/web-api-not-found.module').then(mod => mod.WebApiNotFoundModule) },
    { path: '', redirectTo: 'root/1', pathMatch: 'full' } 
  ]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShellRoutingModule { }
