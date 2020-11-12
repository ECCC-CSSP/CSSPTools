import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GoogleMapsModule } from '@angular/google-maps';
import { MaterialModule } from 'src/app/app-material.module';
import { FileListItemDetailComponent } from 'src/app/components/files/file-list-item-detail/file-list-item-detail.component';
import { FileListItemComponent } from 'src/app/components/files/file-list-item/file-list-item.component';
import { FileListComponent } from 'src/app/components/files/file-list/file-list.component';
import { FileUploadComponent } from 'src/app/components/files/file-upload/file-upload.component';
import { BreadCrumbComponent } from 'src/app/components/helpers/bread-crumb/bread-crumb.component';
import { ErrorComponent } from 'src/app/components/helpers/error/error.component';
import { FooterComponent } from 'src/app/components/helpers/footer/footer.component';
import { SearchOptionComponent } from 'src/app/components/helpers/search-option/search-option.component';
import { SearchComponent } from 'src/app/components/helpers/search/search.component';
import { StatCountComponent } from 'src/app/components/helpers/stat-count/stat-count.component';
import { MapComponent } from 'src/app/components/maps/map/map.component';
import { SideNavMenuComponent } from 'src/app/components/sidenavs/sidenav-menu/sidenav-menu.component';
import { TVItemListDetailAreaComponent } from 'src/app/components/tvitems/tvitem-list-detail-area/tvitem-list-detail-area.component';
import { TVItemListDetailCountryComponent } from 'src/app/components/tvitems/tvitem-list-detail-country/tvitem-list-detail-country.component';
import { TVItemListDetailMunicipalityComponent } from 'src/app/components/tvitems/tvitem-list-detail-municipality/tvitem-list-detail-municipality.component';
import { TVItemListDetailProvinceComponent } from 'src/app/components/tvitems/tvitem-list-detail-province/tvitem-list-detail-province.component';
import { TVItemListDetailSectorComponent } from 'src/app/components/tvitems/tvitem-list-detail-sector/tvitem-list-detail-sector.component';
import { TVItemListDetailSubsectorComponent } from 'src/app/components/tvitems/tvitem-list-detail-subsector/tvitem-list-detail-subsector.component';
import { TVItemListDetailComponent } from 'src/app/components/tvitems/tvitem-list-detail/tvitem-list-detail.component';
import { TVItemListItemComponent } from 'src/app/components/tvitems/tvitem-list-item/tvitem-list-item.component';
import { TVItemListComponent } from 'src/app/components/tvitems/tvitem-list/tvitem-list.component';
import { AreaComponent } from 'src/app/components/tvtypes/area/area.component';
import { CountryComponent } from 'src/app/components/tvtypes/country/country.component';
import { HomeComponent } from 'src/app/components/tvtypes/home/home.component';
import { ProvinceComponent } from 'src/app/components/tvtypes/province/province.component';
import { RootComponent } from 'src/app/components/tvtypes/root/root.component';
import { SectorComponent } from 'src/app/components/tvtypes/Sector/sector.component';
import { ShellComponent } from 'src/app/components/tvtypes/shell/shell.component';
import { SubsectorComponent } from 'src/app/components/tvtypes/subsector/subsector.component';



@NgModule({
  declarations: [
    AreaComponent,
    BreadCrumbComponent,
    CountryComponent,
    ErrorComponent,
    FileListComponent,
    FileListItemComponent,
    FileListItemDetailComponent,
    FileUploadComponent,
    FooterComponent,
    HomeComponent,
    MapComponent,
    ProvinceComponent,
    RootComponent,
    SearchOptionComponent,
    SearchComponent,
    ShellComponent,
    SideNavMenuComponent,
    SectorComponent,
    StatCountComponent,
    SubsectorComponent,
    TVItemListComponent,
    TVItemListDetailComponent,
    TVItemListDetailCountryComponent,
    TVItemListDetailProvinceComponent,
    TVItemListDetailAreaComponent,
    TVItemListDetailSectorComponent,
    TVItemListDetailSubsectorComponent,
    TVItemListDetailMunicipalityComponent,
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
    CountryComponent,
    ErrorComponent,
    FileListComponent,
    FileListItemComponent,
    FileListItemDetailComponent,
    FileUploadComponent,
    FooterComponent,
    HomeComponent,
    MapComponent,
    ProvinceComponent,
    RootComponent,
    SearchOptionComponent,
    SearchComponent,
    ShellComponent,
    SideNavMenuComponent,
    SectorComponent,
    StatCountComponent,
    SubsectorComponent,
    TVItemListComponent,
    TVItemListDetailComponent,
    TVItemListDetailCountryComponent,
    TVItemListDetailProvinceComponent,
    TVItemListDetailAreaComponent, 
    TVItemListDetailSectorComponent,
    TVItemListDetailSubsectorComponent,
    TVItemListDetailMunicipalityComponent,
    TVItemListItemComponent,
  ]
})
export class SharedModule { }
