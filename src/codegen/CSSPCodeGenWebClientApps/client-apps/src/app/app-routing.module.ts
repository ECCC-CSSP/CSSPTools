import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  {
    path: 'en-CA', component: HomeComponent, children: [
      { path: 'home', loadChildren: () => import('./components/home/home.module').then(mod => mod.HomeModule) },
    ]
  },
  {
    path: 'fr-CA', component: HomeComponent, children: [
      { path: 'home', loadChildren: () => import('./components/home/home.module').then(mod => mod.HomeModule) },
    ]
  },
  { path: '', redirectTo: 'en-CA', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
