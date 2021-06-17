import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GoogleMapsModule } from '@angular/google-maps';
import { MaterialModule } from 'src/app/app-material.module';
import { FileListItemDetailComponent } from 'src/app/components/files/file-list-item-detail/file-list-item-detail.component';
import { FileListItemComponent } from 'src/app/components/files/file-list-item/file-list-item.component';
import { FileListComponent } from 'src/app/components/files/file-list/file-list.component';
import { BreadCrumbComponent } from 'src/app/components/bread-crumb/bread-crumb.component';
import { ErrorComponent } from 'src/app/components/error/error.component';
import { FooterComponent } from 'src/app/components/footer/footer.component';
import { SearchOptionComponent } from 'src/app/components/search/search-option/search-option.component';
import { SearchComponent } from 'src/app/components/search/search/search.component';
import { StatCountComponent } from 'src/app/components/stat-count/stat-count.component';
import { MapItemComponent } from 'src/app/components/map/map-item/map-item.component';
import { SideNavMenuComponent } from 'src/app/components/sidenavs/sidenav-menu/sidenav-menu.component';
import { AreaTVItemListDetailComponent } from 'src/app/components/area/area-tvitem-list-detail/area-tvitem-list-detail.component';
import { AnalysisDataVisibleComponent } from './components/analysis/analysis-data-visible/analysis-data-visible.component';
import { AnalysisOptionsComponent } from './components/analysis/analysis-options/analysis-options.component';
import { AreaTVItemListItemComponent } from './components/area/area-tvitem-list-item/area-tvitem-list-item.component';
import { AnalysisItemComponent } from './components/analysis/analysis-item/analysis-item.component';
import { AreaItemComponent } from './components/area/area-item/area-item.component';
import { CountryItemComponent } from './components/country/country-item/country-item.component';
import { CountryTVItemListDetailComponent } from './components/country/country-tvitem-list-detail/country-tvitem-list-detail.component';
import { CountryTVItemListItemComponent } from './components/country/country-tvitem-list-item/country-tvitem-list-item.component';
import { ContactItemComponent } from './components/contact/contact-item/contact-item.component';
import { EmailDistributionListItemComponent } from './components/email-distribution-list/email-distribution-list-item/email-distribution-list-item.component';
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
import { TVItemMenuComponent } from './components/tvitem/tvitem-menu/tvitem-menu.component';
import { MikeScenarioItemEditComponent } from './components/mike-scenario/mike-scenario-item-edit/mike-scenario-item-edit.component';
import { MikeScenarioItemViewComponent } from './components/mike-scenario/mike-scenario-item-view/mike-scenario-item-view.component';
import { MWQMRunItemViewComponent } from './components/mwqm-run/mwqm-run-item-view/mwqm-run-item-view.component';
import { MWQMSiteItemViewComponent } from './components/mwqm-site/mwqm-site-item-view/mwqm-site-item-view.component';
import { PolSourceSiteItemViewComponent } from './components/pol-source-site/pol-source-site-item-view/pol-source-site-item-view.component';
import { HomeTestComponent } from './components/home/home-test/home-test.component';
import { TVItemItemComponent } from './components/tvitem/tvitem-item/tvitem-item.component';
import { FileListItemMenuComponent } from './components/files/file-list-item-menu/file-list-item-menu.component';
import { FileListItemModifyComponent } from './components/files/file-list-item-modify/file-list-item-modify.component';
import { FileListItemCreateComponent } from './components/files/file-list-item-create/file-list-item-create.component';
import { FileListItemViewComponent } from './components/files/file-list-item-view/file-list-item-view.component';
import { TVItemCreateComponent } from './components/tvitem/tvitem-create/tvitem-create.component';
import { TVItemModifyComponent } from './components/tvitem/tvitem-modify/tvitem-modify.component';
import { TVItemViewComponent } from './components/tvitem/tvitem-view/tvitem-view.component';
import { TVItemMenuOpenComponent } from './components/tvitem/tvitem-menu-open/tvitem-menu-open.component';
import { FileListItemMenuOpenComponent } from './components/files/file-list-item-menu-open/file-list-item-menu-open.component';
import { FileListItemLastUpdateComponent } from './components/files/file-list-item-last-update/file-list-item-last-update.component';
import { TVItemLastUpdateComponent } from './components/tvitem/tvitem-last-update/tvItem-last-update.component';
import { MWQMRunItemModifyComponent } from './components/mwqm-run/mwqm-run-item-modify/mwqm-run-item-modify.component';
import { MWQMRunItemCreateComponent } from './components/mwqm-run/mwqm-run-item-create/mwqm-run-item-create.component';
import { MWQMSiteItemModifyComponent } from './components/mwqm-site/mwqm-site-item-modify/mwqm-site-item-modify.component';
import { MWQMSiteItemCreateComponent } from './components/mwqm-site/mwqm-site-item-create/mwqm-site-item-create.component';
import { PolSourceSiteItemModifyComponent } from './components/pol-source-site/pol-source-site-item-modify/pol-source-site-item-modify.component';
import { PolSourceSiteItemCreateComponent } from './components/pol-source-site/pol-source-site-item-create/pol-source-site-item-create.component';
import { PolSourceSiteItemIssueComponent } from './components/pol-source-site/pol-source-site-item-issue/pol-source-site-item-issue.component';
import { PolSourceSiteItemObsComponent } from './components/pol-source-site/pol-source-site-item-obs/pol-source-site-item-obs.component';
import { AddressComponent } from './components/address/address.component';
import { ExportArcGISComponent } from './components/export-arc-gis/export-arc-gis/export-arc-gis.component';
import { NotImplementedYetComponent } from './components/not-implemented-yet/not-implemented-yet/not-implemented-yet.component';
import { ChartBaseComponent } from './components/chart/chart-base/chart-base.component';
import { ChartMonitoringStatsByYearComponent } from './components/chart/chart-monitoring-stats-by-year/chart-monitoring-stats-by-year.component';
import { ChartMWQMSiteFCSalTempComponent } from './components/chart/chart-mwqm-site-fc-sal-temp/chart-mwqm-site-fc-sal-temp.component';
import { ChartMWQMSiteFCStatsComponent } from './components/chart/chart-mwqm-site-fc-stats/chart-mwqm-site-fc-stats.component';
import { ChartMonitoringStatsByMonthComponent } from './components/chart/chart-monitoring-stats-by-month/chart-monitoring-stats-by-month.component';
import { ChartMonitoringStatsBySeasonComponent } from './components/chart/chart-monitoring-stats-by-season/chart-monitoring-stats-by-season.component';
import { ChartMWQMRunDataComponent } from './components/chart/chart-mwqm-run-data/chart-mwqm-run-data.component';
import { TableBaseComponent } from './components/table/table-base/table-base.component';
import { TableMWQMSiteFCStatsComponent } from './components/table/table-mwqm-site-fc-stats/table-mwqm-site-fc-stats.component';
import { TableMonitoringStatsByMonthComponent } from './components/table/table-monitoring-stats-by-month/table-monitoring-stats-by-month.component';
import { TableMonitoringStatsBySeasonComponent } from './components/table/table-monitoring-stats-by-season/table-monitoring-stats-by-season.component';
import { TableMonitoringStatsByYearComponent } from './components/table/table-monitoring-stats-by-year/table-monitoring-stats-by-year.component';
import { TableMWQMRunDataComponent } from './components/table/table-mwqm-run-data/table-mwqm-run-data.component';
import { FileListByPurposeComponent } from './components/files/file-list-by-purpose/file-list-by-purpose.component';
import { FileUploadComponent } from './components/files/file-upload/file-upload.component';

@NgModule({
  declarations: [
    AddressComponent,
    AnalysisDataVisibleComponent,
    AnalysisItemComponent,
    AnalysisItemMenuComponent,
    AnalysisOptionsComponent,
    AreaItemComponent,
    AreaTVItemListDetailComponent,
    AreaTVItemListItemComponent,
    BreadCrumbComponent,
    ChartBaseComponent,
    ChartMonitoringStatsByMonthComponent,
    ChartMonitoringStatsBySeasonComponent,
    ChartMonitoringStatsByYearComponent,
    ChartMWQMRunDataComponent,
    ChartMWQMSiteFCSalTempComponent,
    ChartMWQMSiteFCStatsComponent,
    ContactItemComponent,
    CountryItemComponent,
    CountryTVItemListDetailComponent,
    CountryTVItemListItemComponent,
    EmailDistributionListItemComponent,
    ErrorComponent,
    ExportArcGISComponent,
    FileListComponent,
    FileListByPurposeComponent,
    FileListItemComponent,
    FileListItemCreateComponent,
    FileListItemDetailComponent,
    FileListItemLastUpdateComponent,
    FileListItemModifyComponent,
    FileListItemMenuComponent,
    FileListItemMenuOpenComponent,
    FileListItemViewComponent,
    FileUploadComponent,
    FooterComponent,
    HomeItemComponent,
    HomeTestComponent,
    InfrastructureItemComponent,
    LogBookItemComponent,
    MapItemComponent,
    MapMenuComponent,
    MikeScenarioItemComponent,
    MikeScenarioItemEditComponent,
    MikeScenarioItemViewComponent,
    MikeScenarioTVItemListDetailComponent,
    MikeScenarioTVItemListItemComponent,
    MunicipalityItemComponent,
    MunicipalityTVItemListDetailComponent,
    MunicipalityTVItemListItemComponent,
    MWQMRunItemComponent,
    MWQMRunItemCreateComponent,
    MWQMRunItemModifyComponent,
    MWQMRunItemViewComponent,
    MWQMRunTVItemListDetailComponent,
    MWQMRunTVItemListItemComponent,
    MWQMSiteItemComponent,
    MWQMSiteItemCreateComponent,
    MWQMSiteItemModifyComponent,
    MWQMSiteItemViewComponent,
    MWQMSiteTVItemListDetailComponent,
    MWQMSiteTVItemListItemComponent,
    MWQMSiteTVItemListItemSpecialComponent,
    NotImplementedYetComponent,
    OpenDataItemComponent,
    OpenDataNationalItemComponent,
    PolSourceSiteItemComponent,
    PolSourceSiteItemCreateComponent,
    PolSourceSiteItemIssueComponent,
    PolSourceSiteItemModifyComponent,
    PolSourceSiteItemObsComponent,
    PolSourceSiteItemViewComponent,
    PolSourceSiteTVItemListDetailComponent,
    PolSourceSiteTVItemListItemComponent,
    ProvinceItemComponent,
    ProvinceTVItemListDetailComponent,
    ProvinceTVItemListItemComponent,
    ProvincialToolsItemComponent,
    RainExceedanceItemComponent,
    RootItemComponent,
    SamplingPlanItemComponent,
    SearchComponent,
    SearchOptionComponent,
    SectorItemComponent,
    SectorTVItemListDetailComponent,
    SectorTVItemListItemComponent,
    ShellItemComponent,
    SideNavMenuComponent,
    StatCountComponent,
    SubsectorItemComponent,
    SubsectorTVItemListDetailComponent,
    SubsectorTVItemListItemComponent,
    SubsectorToolsItemComponent,
    TableBaseComponent,
    TableMonitoringStatsByMonthComponent,
    TableMonitoringStatsBySeasonComponent,
    TableMonitoringStatsByYearComponent,
    TableMWQMRunDataComponent,
    TableMWQMSiteFCStatsComponent,
    TVItemCreateComponent,
    TVItemItemComponent,
    TVItemLastUpdateComponent,
    TVItemMenuComponent,
    TVItemModifyComponent,
    TVItemViewComponent,
    TVItemMenuOpenComponent,
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

    AddressComponent,
    AnalysisDataVisibleComponent,
    AnalysisItemComponent,
    AnalysisItemMenuComponent,
    AnalysisOptionsComponent,
    AreaItemComponent,
    AreaTVItemListDetailComponent,
    AreaTVItemListItemComponent,
    BreadCrumbComponent,
    ChartBaseComponent,
    ChartMonitoringStatsByMonthComponent,
    ChartMonitoringStatsBySeasonComponent,
    ChartMonitoringStatsByYearComponent,
    ChartMWQMRunDataComponent,
    ChartMWQMSiteFCSalTempComponent,
    ChartMWQMSiteFCStatsComponent,
    ContactItemComponent,
    CountryItemComponent,
    CountryTVItemListDetailComponent,
    CountryTVItemListItemComponent,
    EmailDistributionListItemComponent,
    ErrorComponent,
    ExportArcGISComponent,
    FileListComponent,
    FileListByPurposeComponent,
    FileListItemCreateComponent,
    FileListItemDetailComponent,
    FileListItemLastUpdateComponent,
    FileListItemModifyComponent,
    FileListItemMenuComponent,
    FileListItemMenuOpenComponent,
    FileListItemViewComponent,
    FileUploadComponent,
    FooterComponent,
    HomeItemComponent,
    HomeTestComponent,
    InfrastructureItemComponent,
    LogBookItemComponent,
    MapItemComponent,
    MapMenuComponent,
    MikeScenarioItemComponent,
    MikeScenarioItemEditComponent,
    MikeScenarioItemViewComponent,
    MikeScenarioTVItemListDetailComponent,
    MikeScenarioTVItemListItemComponent,
    MunicipalityItemComponent,
    MunicipalityTVItemListDetailComponent,
    MunicipalityTVItemListItemComponent,
    MWQMRunItemComponent,
    MWQMRunItemCreateComponent,
    MWQMRunItemModifyComponent,
    MWQMRunItemViewComponent,
    MWQMRunTVItemListDetailComponent,
    MWQMRunTVItemListItemComponent,
    MWQMSiteItemComponent,
    MWQMSiteItemCreateComponent,
    MWQMSiteItemModifyComponent,
    MWQMSiteItemViewComponent,
    MWQMSiteTVItemListDetailComponent,
    MWQMSiteTVItemListItemComponent,
    MWQMSiteTVItemListItemSpecialComponent,
    NotImplementedYetComponent,
    OpenDataItemComponent,
    OpenDataNationalItemComponent,
    PolSourceSiteItemComponent,
    PolSourceSiteItemCreateComponent,
    PolSourceSiteItemIssueComponent,
    PolSourceSiteItemModifyComponent,
    PolSourceSiteItemObsComponent,
    PolSourceSiteItemViewComponent,
    PolSourceSiteTVItemListDetailComponent,
    PolSourceSiteTVItemListItemComponent,
    ProvinceItemComponent,
    ProvinceTVItemListDetailComponent,
    ProvinceTVItemListItemComponent,
    ProvincialToolsItemComponent,
    RainExceedanceItemComponent,
    RootItemComponent,
    SamplingPlanItemComponent,
    SearchComponent,
    SearchOptionComponent,
    SectorItemComponent,
    SectorTVItemListDetailComponent,
    SectorTVItemListItemComponent,
    ShellItemComponent,
    SideNavMenuComponent,
    StatCountComponent,
    SubsectorItemComponent,
    SubsectorTVItemListDetailComponent,
    SubsectorTVItemListItemComponent,
    SubsectorToolsItemComponent,
    TableBaseComponent,
    TableMonitoringStatsByMonthComponent,
    TableMonitoringStatsBySeasonComponent,
    TableMonitoringStatsByYearComponent,
    TableMWQMRunDataComponent,
    TableMWQMSiteFCStatsComponent,
    TVItemCreateComponent,
    TVItemItemComponent,
    TVItemLastUpdateComponent,
    TVItemMenuComponent,
    TVItemModifyComponent,
    TVItemViewComponent,
    TVItemMenuOpenComponent,
  ]
})
export class SharedModule { }
