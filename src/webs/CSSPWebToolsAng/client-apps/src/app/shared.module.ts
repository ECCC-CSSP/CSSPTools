import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GoogleMapsModule } from '@angular/google-maps';
import { MaterialModule } from './app-material.module';
import { FileListItemDetailComponent } from './components/files/file-list-item-detail/file-list-item-detail.component';
import { FileListItemComponent } from './components/files/file-list-item/file-list-item.component';
import { FileListComponent } from './components/files/file-list/file-list.component';
import { BreadCrumbComponent } from './components/helpers/bread-crumb/bread-crumb.component';
import { ChildCountComponent } from './components/helpers/child-count/child-count.component';
import { ErrorComponent } from './components/helpers/error/error.component';
import { FooterComponent } from './components/helpers/footer/footer.component';
import { SearchOptionComponent } from './components/helpers/search-option/search-option.component';
import { SearchComponent } from './components/helpers/search/search.component';
import { MapComponent } from './components/maps/map/map.component';
import { SideNavMenuComponent } from './components/sidenavs/sidenav-menu/sidenav-menu.component';
import { TVItemListDetailCountryComponent } from './components/tvitems/tvitem-list-detail-country/tvitem-list-detail-country.component';
import { TVItemListDetailProvinceComponent } from './components/tvitems/tvitem-list-detail-province/tvitem-list-detail-province.component';
import { TVItemListDetailRootComponent } from './components/tvitems/tvitem-list-detail-root/tvitem-list-detail-root.component';
import { TVItemListDetailComponent } from './components/tvitems/tvitem-list-detail/tvitem-list-detail.component';
import { TVItemListItemComponent } from './components/tvitems/tvitem-list-item/tvitem-list-item.component';
import { TVItemListComponent } from './components/tvitems/tvitem-list/tvitem-list.component';
import { AreaComponent } from './components/tvtypes/area/area.component';
import { CountryComponent } from './components/tvtypes/country/country.component';
import { HomeComponent } from './components/tvtypes/home/home.component';
import { ProvinceComponent } from './components/tvtypes/province/province.component';
import { RootComponent } from './components/tvtypes/root/root.component';
import { SectorComponent } from './components/tvtypes/Sector/sector.component';
import { ShellComponent } from './components/tvtypes/shell/shell.component';
import { SubsectorComponent } from './components/tvtypes/subsector/subsector.component';



@NgModule({
  declarations: [
    AreaComponent,
    BreadCrumbComponent,
    ChildCountComponent,
    CountryComponent,
    ErrorComponent,
    FileListComponent,
    FileListItemComponent,
    FileListItemDetailComponent,
    FooterComponent,
    HomeComponent,
    MapComponent,
    ProvinceComponent,
    RootComponent,
    SearchComponent,
    SearchOptionComponent,
    ShellComponent,
    SideNavMenuComponent,
    SectorComponent,
    SubsectorComponent,
    TVItemListComponent,
    TVItemListDetailComponent,
    TVItemListDetailCountryComponent,
    TVItemListDetailProvinceComponent,
    TVItemListDetailRootComponent,
    TVItemListItemComponent,
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

    AreaComponent,
    BreadCrumbComponent,
    ChildCountComponent,
    CountryComponent,
    ErrorComponent,
    FileListComponent,
    FileListItemComponent,
    FileListItemDetailComponent,
    FooterComponent,
    HomeComponent,
    MapComponent,
    ProvinceComponent,
    RootComponent,
    SearchComponent,
    SearchOptionComponent,
    ShellComponent,
    SideNavMenuComponent,
    SectorComponent,
    SubsectorComponent,
    TVItemListComponent,
    TVItemListDetailComponent,
    TVItemListDetailCountryComponent,
    TVItemListDetailProvinceComponent,
    TVItemListDetailRootComponent,
    TVItemListItemComponent,
  ]
})
export class SharedModule { }
