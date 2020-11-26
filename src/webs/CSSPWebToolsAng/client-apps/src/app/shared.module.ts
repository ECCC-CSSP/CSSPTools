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
import { TVItemListComponent } from 'src/app/components/tvitems/tvitem-list/tvitem-list.component';
import { AreaComponent } from 'src/app/components/tvtypes/area/area.component';
import { CountryComponent } from 'src/app/components/tvtypes/country/country.component';
import { HomeComponent } from 'src/app/components/tvtypes/home/home.component';
import { ProvinceComponent } from 'src/app/components/tvtypes/province/province.component';
import { RootComponent } from 'src/app/components/tvtypes/root/root.component';
import { SectorComponent } from 'src/app/components/tvtypes/Sector/sector.component';
import { ShellComponent } from 'src/app/components/tvtypes/shell/shell.component';
import { SubsectorComponent } from 'src/app/components/tvtypes/subsector/subsector.component';
import { LastUpdateTVFileModelComponent } from './components/helpers/last-update-tvfilemodel/last-update-tvfilemodel.component';
import { LastUpdateTVItemModelComponent } from './components/helpers/last-update-tvitemmodel/last-update-tvitemmodel.component';
import { TVItemListDetailMikeScenarioComponent } from './components/tvitems/tvitem-list-detail-mike-scenario/tvitem-list-detail-mike-scenario.component';
import { TVItemListDetailMWQMRunComponent } from './components/tvitems/tvitem-list-detail-mwqm-run/tvitem-list-detail-mwqm-run.component';
import { TVItemListDetailMWQMSiteComponent } from './components/tvitems/tvitem-list-detail-mwqm-site/tvitem-list-detail-mwqm-site.component';
import { TVItemListDetailPolSourceSiteComponent } from './components/tvitems/tvitem-list-detail-pol-source-site/tvitem-list-detail-pol-source-site.component';
import { TVItemListItemAreaComponent } from './components/tvitems/tvitem-list-item-area/tvitem-list-item-area.component';
import { TVItemListItemCountryComponent } from './components/tvitems/tvitem-list-item-country/tvitem-list-item-country.component';
import { TVItemListItemMikeScenarioComponent } from './components/tvitems/tvitem-list-item-mike-scenario/tvitem-list-item-mike-scenario.component';
import { TVItemListItemMunicipalityComponent } from './components/tvitems/tvitem-list-item-municipality/tvitem-list-item-municipality.component';
import { TVItemListItemMWQMRunComponent } from './components/tvitems/tvitem-list-item-mwqm-run/tvitem-list-item-mwqm-run.component';
import { TVItemListItemMWQMSiteButtonComponent } from './components/tvitems/tvitem-list-item-mwqm-site-button/tvitem-list-item-mwqm-site-button.component';
import { TVItemListItemMWQMSiteComponent } from './components/tvitems/tvitem-list-item-mwqm-site/tvitem-list-item-mwqm-site.component';
import { TVItemListItemPolSourceSiteComponent } from './components/tvitems/tvitem-list-item-pol-source-site/tvitem-list-item-pol-source-site.component';
import { TVItemListItemProvinceComponent } from './components/tvitems/tvitem-list-item-province/tvitem-list-item-province.component';
import { TVItemListItemSectorComponent } from './components/tvitems/tvitem-list-item-sector/tvitem-list-item-sector.component';
import { TVItemListItemSubsectorComponent } from './components/tvitems/tvitem-list-item-subsector/tvitem-list-item-subsector.component';
import { AnalysisComponent } from './components/tvtypes/analysis/analysis.component';
import { ContactComponent } from './components/tvtypes/contact/contact.component';
import { EmailDistributionListComponent } from './components/tvtypes/email-distribution-list/email-distribution-list.component';
import { ExportArcGISComponent } from './components/tvtypes/export-arc-gis/export-arc-gis.component';
import { InfrastructureComponent } from './components/tvtypes/infrastructure/infrastructure.component';
import { InfrastructuresComponent } from './components/tvtypes/infrastructures/infrastructures.component';
import { LogBookComponent } from './components/tvtypes/log-book/log-book.component';
import { MikeScenarioComponent } from './components/tvtypes/mike-scenario/mike-scenario.component';
import { MunicipalityComponent } from './components/tvtypes/municipality/municipality.component';
import { OpenDataNationalComponent } from './components/tvtypes/open-data-national/open-data-national.component';
import { OpenDataComponent } from './components/tvtypes/open-data/open-data.component';
import { ProvincialToolsComponent } from './components/tvtypes/provincial-tools/provincial-tools.component';
import { RainExceedanceComponent } from './components/tvtypes/rain-exceedance/rain-exceedance.component';
import { SamplingPlanComponent } from './components/tvtypes/sampling-plan/sampling-plan.component';
import { SubsectorToolsComponent } from './components/tvtypes/subsector-tools/subsector-tools.component';

@NgModule({
  declarations: [
    AnalysisComponent,
    AreaComponent,
    BreadCrumbComponent,
    ContactComponent,
    CountryComponent,
    EmailDistributionListComponent,
    ErrorComponent,
    ExportArcGISComponent,
    FileListComponent,
    FileListItemComponent,
    FileListItemDetailComponent,
    FileUploadComponent,
    FooterComponent,
    HomeComponent,
    InfrastructureComponent,
    InfrastructuresComponent,
    LastUpdateTVFileModelComponent,
    LastUpdateTVItemModelComponent,
    LogBookComponent,
    MapComponent,
    MikeScenarioComponent,
    MunicipalityComponent,
    OpenDataComponent,
    OpenDataNationalComponent,
    ProvincialToolsComponent,
    ProvinceComponent,
    RainExceedanceComponent,
    RootComponent,
    SamplingPlanComponent,
    SearchComponent,
    SearchOptionComponent,
    SectorComponent,
    ShellComponent,
    SideNavMenuComponent,
    StatCountComponent,
    SubsectorComponent,
    SubsectorToolsComponent,
    TVItemListComponent,
    TVItemListDetailAreaComponent,
    TVItemListDetailMikeScenarioComponent,
    TVItemListDetailMunicipalityComponent,
    TVItemListDetailMWQMRunComponent,
    TVItemListDetailMWQMSiteComponent,
    TVItemListDetailCountryComponent,
    TVItemListDetailPolSourceSiteComponent,
    TVItemListDetailProvinceComponent,
    TVItemListDetailSectorComponent,
    TVItemListDetailSubsectorComponent,
    TVItemListItemAreaComponent,
    TVItemListItemCountryComponent,
    TVItemListItemMikeScenarioComponent,   
    TVItemListItemMunicipalityComponent,
    TVItemListItemMWQMRunComponent,
    TVItemListItemMWQMSiteButtonComponent,
    TVItemListItemMWQMSiteComponent,
    TVItemListItemPolSourceSiteComponent,
    TVItemListItemProvinceComponent,
    TVItemListItemSectorComponent,
    TVItemListItemSubsectorComponent,
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

    AnalysisComponent,
    AreaComponent,
    BreadCrumbComponent,
    ContactComponent,
    CountryComponent,
    EmailDistributionListComponent,
    ErrorComponent,
    ExportArcGISComponent,
    FileListComponent,
    FileListItemComponent,
    FileListItemDetailComponent,
    FileUploadComponent,
    FooterComponent,
    LastUpdateTVFileModelComponent,
    LastUpdateTVItemModelComponent,
    LogBookComponent,
    HomeComponent,
    InfrastructureComponent,
    InfrastructuresComponent,
    MapComponent,
    MikeScenarioComponent,
    MunicipalityComponent,
    OpenDataComponent,
    OpenDataNationalComponent,
    ProvincialToolsComponent,
    ProvinceComponent,
    RainExceedanceComponent,
    RootComponent,
    SamplingPlanComponent,
    SearchComponent,
    SearchOptionComponent,
    SectorComponent,
    ShellComponent,
    SideNavMenuComponent,
    StatCountComponent,
    SubsectorComponent,
    SubsectorToolsComponent,
    TVItemListComponent,
    TVItemListDetailAreaComponent, 
    TVItemListDetailCountryComponent,
    TVItemListDetailMikeScenarioComponent,
    TVItemListDetailMunicipalityComponent,
    TVItemListDetailMWQMRunComponent,
    TVItemListDetailMWQMSiteComponent,
    TVItemListDetailPolSourceSiteComponent,
    TVItemListDetailProvinceComponent,
    TVItemListDetailSectorComponent,
    TVItemListDetailSubsectorComponent,
    TVItemListItemAreaComponent,
    TVItemListItemCountryComponent,
    TVItemListItemMikeScenarioComponent,   
    TVItemListItemMunicipalityComponent,
    TVItemListItemMWQMRunComponent,
    TVItemListItemMWQMSiteButtonComponent,
    TVItemListItemMWQMSiteComponent,
    TVItemListItemPolSourceSiteComponent,
    TVItemListItemProvinceComponent,
    TVItemListItemSectorComponent,
    TVItemListItemSubsectorComponent,
  ]
})
export class SharedModule { }
