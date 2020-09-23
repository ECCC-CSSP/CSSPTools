import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProvinceComponent } from './province.component';

const routes: Routes = [
  {
    path: '', component: ProvinceComponent, children: [
      //{ path: 'address', loadChildren: () => import('../../test-components/address/address.module').then(mod => mod.AddressModule) }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProvinceRoutingModule { }
