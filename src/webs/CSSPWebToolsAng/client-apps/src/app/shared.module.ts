import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './app-material.module';
import { SearchComponent } from './components/search/search.component';
import { SearchOptionComponent } from './components/search-option/search-option.component';
import { TVItemListComponent } from './components/tvitem-list/tvitem-list.component';
import { TVItemListItemComponent } from './components/tvitem-list-item/tvitem-list-item.component';
import { GoogleMapsModule } from '@angular/google-maps';

@NgModule({
  declarations: [
    SearchComponent,
    SearchOptionComponent,
    TVItemListComponent,
    TVItemListItemComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    GoogleMapsModule
  ],
  exports: [
    CommonModule,
    MaterialModule,
    GoogleMapsModule,
    FormsModule,
    ReactiveFormsModule,

    SearchComponent,
    SearchOptionComponent,
    TVItemListComponent,
    TVItemListItemComponent
  ]
})
export class SharedModule { }
