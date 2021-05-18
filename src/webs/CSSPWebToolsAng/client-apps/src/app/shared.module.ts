import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GoogleMapsModule } from '@angular/google-maps';
import { MaterialModule } from 'src/app/app-material.module';
import { FileListItemDetailComponent } from 'src/app/components/files/file-list-item-detail/file-list-item-detail.component';
import { FileListItemComponent } from 'src/app/components/files/file-list-item/file-list-item.component';
import { FileListComponent } from 'src/app/components/files/file-list/file-list.component';
//import { FileUploadComponent } from 'src/app/components/files/file-upload/file-upload.component';
import { BreadCrumbComponent } from 'src/app/components/helpers/bread-crumb/bread-crumb.component';
import { ErrorComponent } from 'src/app/components/helpers/error/error.component';
import { FooterComponent } from 'src/app/components/helpers/footer/footer.component';
import { SearchOptionComponent } from 'src/app/components/helpers/search-option/search-option.component';
import { SearchComponent } from 'src/app/components/helpers/search/search.component';
import { StatCountComponent } from 'src/app/components/helpers/stat-count/stat-count.component';
import { MapItemComponent } from 'src/app/components/map/map-item/map-item.component';
import { SideNavMenuComponent } from 'src/app/components/sidenavs/sidenav-menu/sidenav-menu.component';
import { AreaTVItemListDetailComponent } from 'src/app/components/area/area-tvitem-list-detail/area-tvitem-list-detail.component';
import { AnalysisDataVisibleComponent } from './components/analysis/analysis-data-visible/analysis-data-visible.component';
import { AnalysisOptionsComponent } from './components/analysis/analysis-options/analysis-options.component';
import { LastUpdateTVFileModelComponent } from './components/helpers/last-update-tvfilemodel/last-update-tvfilemodel.component';
import { LastUpdateTVItemModelComponent } from './components/helpers/last-update-tvitemmodel/last-update-tvitemmodel.component';
import { AreaTVItemListItemComponent } from './components/area/area-tvitem-list-item/area-tvitem-list-item.component';
import { AnalysisItemComponent } from './components/analysis/analysis-item/analysis-item.component';
import { AreaItemComponent } from './components/area/area-item/area-item.component';
import { CountryItemComponent } from './components/country/country-item/country-item.component';
import { CountryTVItemListDetailComponent } from './components/country/country-tvitem-list-detail/country-tvitem-list-detail.component';
import { CountryTVItemListItemComponent } from './components/country/country-tvitem-list-item/country-tvitem-list-item.component';
import { ContactItemComponent } from './components/contact/contact-item/contact-item.component';
import { EmailDistributionListItemComponent } from './components/email-distribution-list/email-distribution-list-item/email-distribution-list-item.component';
import { ExportArcGISItemComponent } from './components/export-arc-gis/export-arc-gis-item/export-arc-gis-item.component';
import { InfrastructureItemComponent } from './components/infrastructure/infrastructure-item/infrastructure-item.component';
import { LogBookItemComponent } from './components/log-book/log-book-item/log-book-item.component';
import { MikeScenarioItemComponent } from './components/mike-scenario/mike-scenario-item/mike-scenario-item.component';
import { MunicipalityItemComponent } from './components/municipality/municipality-item/municipality-item.component';
import { OpenDataNationalItemComponent } from './components/open-data-national/open-data-national-item/open-data-national-item.component';
import { ProvincialToolsItemComponent } from './components/provincial-tools/provincial-tools-item/provincial-tools-item.component';
import { RainExceedanceItemComponent } from './components/rain-exceedance/rain-exceedance-item/rain-exceedance-item.component';
import { SamplingPlanItemComponent } from './components/sampling-plan/sampling-plan-item/sampling-plan-item.component';
import { SubsectorToolsItemComponent } from './components/subsector-tools/subsector-tools-item/subsector-tools-item.component';
import { HomeItemComponent } from './components/home/home-item/home-item.component';
import { ProvinceItemComponent } from './components/province/province-item/province-item.component';
import { RootItemComponent } from './components/root/root-item/root-item.component';
import { SectorItemComponent } from './components/sector/sector-item/sector-item.component';
import { ShellItemComponent } from './components/shell/shell-item/shell-item.component';
import { SubsectorItemComponent } from './components/subsector/subsector-item/subsector-item.component';
import { MapMenuComponent } from './components/map/map-menu/map-menu.component';
import { MikeScenarioTVItemListDetailComponent } from './components/mike-scenario/mike-scenario-tvitem-list-detail/mike-scenario-tvitem-list-detail.component';
import { MikeScenarioTVItemListItemComponent } from './components/mike-scenario/mike-scenario-tvitem-list-item/mike-scenario-tvitem-list-item.component';
import { MunicipalityTVItemListDetailComponent } from './components/municipality/municipality-tvitem-list-detail/municipality-tvitem-list-detail.component';
import { MunicipalityTVItemListItemComponent } from './components/municipality/municipality-tvitem-list-item/municipality-tvitem-list-item.component';
import { MWQMRunItemComponent } from './components/mwqm-run/mwqm-run-item/mwqm-run-item.component';
import { MWQMRunTVItemListDetailComponent } from './components/mwqm-run/mwqm-run-tvitem-list-detail/mwqm-run-tvitem-list-detail.component';
import { MWQMRunTVItemListItemComponent } from './components/mwqm-run/mwqm-run-tvitem-list-item/mwqm-run-tvitem-list-item.component';
import { MWQMSiteItemComponent } from './components/mwqm-site/mwqm-site-item/mwqm-site-item.component';
import { MWQMSiteTVItemListDetailComponent } from './components/mwqm-site/mwqm-site-tvitem-list-detail/mwqm-site-tvitem-list-detail.component';
import { MWQMSiteTVItemListItemComponent } from './components/mwqm-site/mwqm-site-tvitem-list-item/mwqm-site-tvitem-list-item.component';
import { OpenDataItemComponent } from './components/open-data/open-data-item/open-data-item.component';
import { PolSourceSiteItemComponent } from './components/pol-source-site/pol-source-site-item/pol-source-site-item.component';
import { PolSourceSiteTVItemListDetailComponent } from './components/pol-source-site/pol-source-site-tvitem-list-detail/pol-source-site-tvitem-list-detail.component';
import { PolSourceSiteTVItemListItemComponent } from './components/pol-source-site/pol-source-site-tvitem-list-item/pol-source-site-tvitem-list-item.component';
import { ProvinceTVItemListDetailComponent } from './components/province/province-tvitem-list-detail/province-tvitem-list-detail.component';
import { ProvinceTVItemListItemComponent } from './components/province/province-tvitem-list-item/province-tvitem-list-item.component';
import { SectorTVItemListDetailComponent } from './components/sector/sector-tvitem-list-detail/sector-tvitem-list-detail.component';
import { SectorTVItemListItemComponent } from './components/sector/sector-tvitem-list-item/sector-tvitem-list-item.component';
import { SubsectorTVItemListDetailComponent } from './components/subsector/subsector-tvitem-list-detail/subsector-tvitem-list-detail.component';
import { SubsectorTVItemListItemComponent } from './components/subsector/subsector-tvitem-list-item/subsector-tvitem-list-item.component';
import { MWQMSiteTVItemListItemSpecialComponent } from './components/mwqm-site/mwqm-site-tvitem-list-item-special/mwqm-site-tvitem-list-item-special.component';
import { AnalysisItemMenuComponent } from './components/analysis/analysis-item-menu/analysis-item-menu.component';
import { MWQMSiteItemEditComponent } from './components/mwqm-site/mwqm-site-item-edit/mwqm-site-item-edit.component';
import { PolSourceSiteItemEditComponent } from './components/pol-source-site/pol-source-site-item-edit/pol-source-site-item-edit.component';
import { MWQMRunItemEditComponent } from './components/mwqm-run/mwqm-run-item-edit/mwqm-run-item-edit.component';
import { AreaItemEditComponent } from './components/area/area-item-edit/area-item-edit.component';
import { TVItemMenuComponent } from './components/helpers/tvitem-menu/tvitem-menu.component';
import { CountryItemModifyComponent } from './components/country/country-item-modify/country-item-modify.component';
import { ProvinceItemEditComponent } from './components/province/province-item-edit/province-item-edit.component';
import { MunicipalityItemEditComponent } from './components/municipality/municipality-item-edit/municipality-item-edit.component';
import { TVFileMenuComponent } from './components/helpers/tvfile-menu/tvfile-menu.component';
import { FileListItemEditComponent } from './components/files/file-list-item-edit/file-list-item-edit.component';
import { SubsectorItemEditComponent } from './components/subsector/subsector-item-edit/subsector-item-edit.component';
import { SectorItemEditComponent } from './components/sector/sector-item-edit/sector-item-edit.component';
import { MikeScenarioItemEditComponent } from './components/mike-scenario/mike-scenario-item-edit/mike-scenario-item-edit.component';
import { FileListItemViewComponent } from './components/files/file-list-item-view/file-list-item-view.component';
import { AreaItemViewComponent } from './components/area/area-item-view/area-item-view.component';
import { CountryItemViewComponent } from './components/country/country-item-view/country-item-view.component';
import { MikeScenarioItemViewComponent } from './components/mike-scenario/mike-scenario-item-view/mike-scenario-item-view.component';
import { MunicipalityItemViewComponent } from './components/municipality/municipality-item-view/municipality-item-view.component';
import { MWQMRunItemViewComponent } from './components/mwqm-run/mwqm-run-item-view/mwqm-run-item-view.component';
import { MWQMSiteItemViewComponent } from './components/mwqm-site/mwqm-site-item-view/mwqm-site-item-view.component';
import { PolSourceSiteItemViewComponent } from './components/pol-source-site/pol-source-site-item-view/pol-source-site-item-view.component';
import { ProvinceItemViewComponent } from './components/province/province-item-view/province-item-view.component';
import { SectorItemViewComponent } from './components/sector/sector-item-view/sector-item-view.component';
import { SubsectorItemViewComponent } from './components/subsector/subsector-item-view/subsector-item-view.component';
import { CountryItemCreateComponent } from './components/country/country-item-create/country-item-create.component';
import { HomeTestComponent } from './components/home/home-test/home-test.component';
import { ChartFCSalTempComponent } from './components/chart/chart-fc-sal-temp/chart-fc-sal-temp.component';
import { ChartFCStatComponent } from './components/chart/chart-fc-stat/chart-fc-stat.component';
import { TableFCStatComponent } from './components/table/table-fc-stat/table-fc-stat.component';

@NgModule({
  declarations: [
    AnalysisDataVisibleComponent,
    AnalysisItemComponent,
    AnalysisItemMenuComponent,
    AnalysisOptionsComponent,
    AreaItemComponent,
    AreaItemEditComponent,
    AreaItemViewComponent,
    AreaTVItemListDetailComponent,
    AreaTVItemListItemComponent,
    BreadCrumbComponent,
    ChartFCSalTempComponent,
    ChartFCStatComponent,
    ContactItemComponent,
    CountryItemComponent,
    CountryItemCreateComponent,
    CountryItemModifyComponent,
    CountryItemViewComponent,
    CountryTVItemListDetailComponent,
    CountryTVItemListItemComponent,
    EmailDistributionListItemComponent,
    ErrorComponent,
    ExportArcGISItemComponent,
    FileListComponent,
    FileListItemComponent,
    FileListItemDetailComponent,
    FileListItemEditComponent,
    FileListItemViewComponent,
    //  FileUploadComponent,
    FooterComponent,
    HomeItemComponent,
    HomeTestComponent,
    InfrastructureItemComponent,
    LastUpdateTVFileModelComponent,
    LastUpdateTVItemModelComponent,
    LogBookItemComponent,
    MapItemComponent,
    MapMenuComponent,
    MikeScenarioItemComponent,
    MikeScenarioItemEditComponent,
    MikeScenarioItemViewComponent,
    MikeScenarioTVItemListDetailComponent,
    MikeScenarioTVItemListItemComponent,
    MunicipalityItemComponent,
    MunicipalityItemEditComponent,
    MunicipalityItemViewComponent,
    MunicipalityTVItemListDetailComponent,
    MunicipalityTVItemListItemComponent,
    MWQMRunItemComponent,
    MWQMRunItemEditComponent,
    MWQMRunItemViewComponent,
    MWQMRunTVItemListDetailComponent,
    MWQMRunTVItemListItemComponent,
    MWQMSiteItemComponent,
    MWQMSiteItemEditComponent,
    MWQMSiteItemViewComponent,
    MWQMSiteTVItemListDetailComponent,
    MWQMSiteTVItemListItemComponent,
    MWQMSiteTVItemListItemSpecialComponent,
    OpenDataItemComponent,
    OpenDataNationalItemComponent,
    PolSourceSiteItemComponent,
    PolSourceSiteItemEditComponent,
    PolSourceSiteItemViewComponent,
    PolSourceSiteTVItemListDetailComponent,
    PolSourceSiteTVItemListItemComponent,
    ProvinceItemComponent,
    ProvinceItemEditComponent,
    ProvinceItemViewComponent,
    ProvinceTVItemListDetailComponent,
    ProvinceTVItemListItemComponent,
    ProvincialToolsItemComponent,
    RainExceedanceItemComponent,
    RootItemComponent,
    SamplingPlanItemComponent,
    SearchComponent,
    SearchOptionComponent,
    SectorItemComponent,
    SectorItemEditComponent,
    SectorItemViewComponent,
    SectorTVItemListDetailComponent,
    SectorTVItemListItemComponent,
    ShellItemComponent,
    SideNavMenuComponent,
    StatCountComponent,
    SubsectorItemComponent,
    SubsectorItemEditComponent,
    SubsectorItemViewComponent,
    SubsectorTVItemListDetailComponent,
    SubsectorTVItemListItemComponent,
    SubsectorToolsItemComponent,
    TableFCStatComponent,
    TVFileMenuComponent,
    TVItemMenuComponent
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

    AnalysisDataVisibleComponent,
    AnalysisItemComponent,
    AnalysisItemMenuComponent,
    AnalysisOptionsComponent,
    AreaItemComponent,
    AreaItemEditComponent,
    AreaItemViewComponent,
    AreaTVItemListDetailComponent,
    AreaTVItemListItemComponent,
    BreadCrumbComponent,
    ChartFCSalTempComponent,
    ChartFCStatComponent,
    ContactItemComponent,
    CountryItemComponent,
    CountryItemCreateComponent,
    CountryItemModifyComponent,
    CountryItemViewComponent,
    CountryTVItemListDetailComponent,
    CountryTVItemListItemComponent,
    EmailDistributionListItemComponent,
    ErrorComponent,
    ExportArcGISItemComponent,
    FileListComponent,
    FileListItemComponent,
    FileListItemDetailComponent,
    FileListItemEditComponent,
    FileListItemViewComponent,
    //FileUploadComponent,
    FooterComponent,
    HomeItemComponent,
    HomeTestComponent,
    InfrastructureItemComponent,
    LastUpdateTVFileModelComponent,
    LastUpdateTVItemModelComponent,
    LogBookItemComponent,
    MapItemComponent,
    MapMenuComponent,
    MikeScenarioItemComponent,
    MikeScenarioItemEditComponent,
    MikeScenarioItemViewComponent,
    MikeScenarioTVItemListDetailComponent,
    MikeScenarioTVItemListItemComponent,
    MunicipalityItemComponent,
    MunicipalityItemEditComponent,
    MunicipalityItemViewComponent,
    MunicipalityTVItemListDetailComponent,
    MunicipalityTVItemListItemComponent,
    MWQMRunItemComponent,
    MWQMRunItemEditComponent,
    MWQMRunItemViewComponent,
    MWQMRunTVItemListDetailComponent,
    MWQMRunTVItemListItemComponent,
    MWQMSiteItemComponent,
    MWQMSiteItemEditComponent,
    MWQMSiteItemViewComponent,
    MWQMSiteTVItemListDetailComponent,
    MWQMSiteTVItemListItemComponent,
    MWQMSiteTVItemListItemSpecialComponent,
    OpenDataItemComponent,
    OpenDataNationalItemComponent,
    PolSourceSiteItemComponent,
    PolSourceSiteItemEditComponent,
    PolSourceSiteItemViewComponent,
    PolSourceSiteTVItemListDetailComponent,
    PolSourceSiteTVItemListItemComponent,
    ProvinceItemComponent,
    ProvinceItemEditComponent,
    ProvinceItemViewComponent,
    ProvinceTVItemListDetailComponent,
    ProvinceTVItemListItemComponent,
    ProvincialToolsItemComponent,
    RainExceedanceItemComponent,
    RootItemComponent,
    SamplingPlanItemComponent,
    SearchComponent,
    SearchOptionComponent,
    SectorItemComponent,
    SectorItemEditComponent,
    SectorItemViewComponent,
    SectorTVItemListDetailComponent,
    SectorTVItemListItemComponent,
    ShellItemComponent,
    SideNavMenuComponent,
    StatCountComponent,
    SubsectorItemComponent,
    SubsectorItemEditComponent,
    SubsectorItemViewComponent,
    SubsectorTVItemListDetailComponent,
    SubsectorTVItemListItemComponent,
    SubsectorToolsItemComponent,
    TableFCStatComponent,
    TVFileMenuComponent,
    TVItemMenuComponent
  ]
})
export class SharedModule { }
