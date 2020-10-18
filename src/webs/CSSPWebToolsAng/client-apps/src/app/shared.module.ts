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
import { SideNavMenuComponent } from './components/sidenav-menu/sidenav-menu.component';
import { MapComponent } from './components/map/map.component';
import { BreadCrumbComponent } from './components/bread-crumb/bread-crumb.component';
import { LoggedInContactComponent } from './components/logged-in-contact/logged-in-contact.component';
import { HomeComponent } from './components/home/home.component';
import { RootComponent } from './components/root/root.component';
import { CountryComponent } from './components/country/country.component';
import { ProvinceComponent } from './components/province/province.component';
import { ShellComponent } from './components/shell/shell.component';
import { ErrorComponent } from './components/error/error.component';

@NgModule({
  declarations: [
    BreadCrumbComponent,
    ChildCountComponent,
    CountryComponent,
    FileListComponent,
    FileListItemComponent,
    FileListItemDetailComponent,
    HomeComponent,
    LoggedInContactComponent,
    MapComponent,
    ProvinceComponent,
    RootComponent,
    SearchComponent,
    SearchOptionComponent,
    ShellComponent,
    SideNavMenuComponent,
    TVItemListComponent,
    TVItemListDetailComponent,
    TVItemListDetailCountryComponent,
    TVItemListDetailProvinceComponent,
    TVItemListDetailRootComponent,
    TVItemListItemComponent,
    ErrorComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    GoogleMapsModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  exports: [
    CommonModule,
    FormsModule,
    GoogleMapsModule,
    MaterialModule,
    ReactiveFormsModule,

    BreadCrumbComponent,
    ChildCountComponent,
    CountryComponent,
    FileListComponent,
    FileListItemComponent,
    FileListItemDetailComponent,
    HomeComponent,
    LoggedInContactComponent,
    MapComponent,
    ProvinceComponent,
    RootComponent,
    SearchComponent,
    SearchOptionComponent,
    ShellComponent,
    SideNavMenuComponent,
    TVItemListComponent,
    TVItemListDetailComponent,
    TVItemListDetailCountryComponent,
    TVItemListDetailProvinceComponent,
    TVItemListDetailRootComponent,
    TVItemListItemComponent,
    ErrorComponent
  ]
})
export class SharedModule { }
