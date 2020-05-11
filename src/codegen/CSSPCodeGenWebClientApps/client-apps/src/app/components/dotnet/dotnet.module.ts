import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DotNetRoutingModule } from './dotnet-routing.module';
import { MaterialModule } from 'src/app/app-material.module';
import { DotNetComponent } from './dotnet.component';

@NgModule({
  declarations: [ DotNetComponent ],
  imports: [
    CommonModule,
    RouterModule,
    DotNetRoutingModule,
    MaterialModule
  ]
})
export class DotNetModule { }
