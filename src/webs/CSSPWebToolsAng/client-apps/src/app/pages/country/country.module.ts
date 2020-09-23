import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CountryRoutingModule } from './country-routing.module';
import { CountryComponent } from './country.component';
import { SharedModule } from 'src/app/shared.module';

@NgModule({
  declarations: [ CountryComponent ],
  imports: [
    RouterModule,
    CountryRoutingModule,
    SharedModule
  ]
})
export class CountryModule { }
