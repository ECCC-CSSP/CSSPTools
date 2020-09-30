import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './app-material.module';
import { SearchComponent } from './components/search/search.component';
import { SearchOptionComponent } from './components/search-option/search-option.component';
import { TVItemListComponent } from './components/tvitem-list/tvitem-list.component';
import { TVItemListItemComponent } from './components/tvitem-list-item/tvitem-list-item.component';
import { GoogleMapsModule } from '@angular/google-maps';
import { ChildCountComponent } from './components/child-count/child-count.component';
import { TVItemListDetailComponent } from './components/tvitem-list-detail/tvitem-list-detail.component';
import { TVItemListDetailRootComponent } from './components/tvitem-list-detail-root/tvitem-list-detail-root.component';
import { TVItemListDetailCountryComponent } from './components/tvitem-list-detail-country/tvitem-list-detail-country.component';
import { TVItemListDetailProvinceComponent } from './components/tvitem-list-detail-province/tvitem-list-detail-province.component';
import { FileListComponent } from './components/file-list/file-list.component';
import { FileListItemComponent } from './components/file-list-item/file-list-item.component';
import { FileListItemDetailComponent } from './components/file-list-item-detail/file-list-item-detail.component';

@NgModule({
  declarations: [
    SearchComponent,
    SearchOptionComponent,
    TVItemListComponent,
    TVItemListItemComponent,
    ChildCountComponent,
    TVItemListDetailComponent,
    TVItemListDetailRootComponent,
    TVItemListDetailCountryComponent,
    TVItemListDetailProvinceComponent,
    FileListComponent,
    FileListItemComponent,
    FileListItemDetailComponent,
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
    TVItemListItemComponent,
    ChildCountComponent,
    TVItemListDetailComponent,
    TVItemListDetailRootComponent,
    TVItemListDetailCountryComponent,
    TVItemListDetailProvinceComponent,
    FileListComponent,
    FileListItemComponent,
    FileListItemDetailComponent,
  ]
})
export class SharedModule { }
