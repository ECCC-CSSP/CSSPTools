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
import { MWQMSiteItemDetailComponent } from './components/mwqm-site/mwqm-site-item-detail/mwqm-site-item-detail.component';
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
import { MikeScenarioItemModifyComponent } from './components/mike-scenario/mike-scenario-item-modify/mike-scenario-item-modify.component';
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
import { FileUploadComponent } from './components/files/file-upload/file-upload.component';
import { TelComponent } from './components/tel/tel.component';
import { EmailComponent } from './components/email/email.component';
import { InfrastructureItemMenuComponent } from './components/infrastructure/infrastructure-item-menu/infrastructure-item-menu.component';
import { InfrastructureItemMenuOpenComponent } from './components/infrastructure/infrastructure-item-menu-open/infrastructure-item-menu-open.component';
import { InfrastructureItemCreateComponent } from './components/infrastructure/infrastructure-item-create/infrastructure-item-create.component';
import { InfrastructureItemViewComponent } from './components/infrastructure/infrastructure-item-view/infrastructure-item-view.component';
import { InfrastructureItemModifyComponent } from './components/infrastructure/infrastructure-item-modify/infrastructure-item-modify.component';
import { InfrastructureItemListComponent } from './components/infrastructure/infrastructure-item-list/infrastructure-item-list.component';
import { TableInfrastructureSingleComponent } from './components/table/table-infrastructure-single/table-infrastructure-single.component';
import { InfrastructureItemInformationComponent } from './components/infrastructure/infrastructure-item-information/infrastructure-item-information.component';
import { InfrastructureItemVisualPlumesComponent } from './components/infrastructure/infrastructure-item-visual-plumes/infrastructure-item-visual-plumes.component';
import { InfrastructureItemFilesComponent } from './components/infrastructure/infrastructure-item-files/infrastructure-item-files.component';
import { TableInfrastructureSingleOutfallComponent } from './components/table/table-infrastructure-single-outfall/table-infrastructure-single-outfall.component';
import { BoxModelItemListComponent } from './components/box-model/box-model-item-list/box-model-item-list.component';
import { BoxModelItemResultComponent } from './components/box-model/box-model-item-result/box-model-item-result.component';
import { VisualPlumesItemListComponent } from './components/visual-plumes/visual-plumes-item-list/visual-plumes-item-list.component';
import { VisualPlumesItemInputAmbientComponent } from './components/visual-plumes/visual-plumes-item-input-ambient/visual-plumes-item-input-ambient.component';
import { VisualPlumesItemInputDiffuserComponent } from './components/visual-plumes/visual-plumes-item-input-diffuser/visual-plumes-item-input-diffuser.component';
import { VisualPlumesItemComponent } from './components/visual-plumes/visual-plumes-item/visual-plumes-item.component';
import { BoxModelItemComponent } from './components/box-model/box-model-item/box-model-item.component';
import { BoxModelItemInputComponent } from './components/box-model/box-model-item-input/box-model-item-input.component';
import { FileListLocalizeAllComponent } from './components/files/file-list-localize-all/file-list-localize-all.component';
import { FileListItemLocalizeComponent } from './components/files/file-list-item-localize/file-list-item-localize.component';
import { FileListItemDownloadComponent } from './components/files/file-list-item-download/file-list-item-download.component';
import { MWQMSiteItemMenuOpenComponent } from './components/mwqm-site/mwqm-site-item-menu-open/mwqm-site-item-menu-open.component';
import { MWQMSiteItemViewChartsComponent } from './components/mwqm-site/mwqm-site-item-view-charts/mwqm-site-item-view-charts.component';
import { MWQMSiteItemViewFilesComponent } from './components/mwqm-site/mwqm-site-item-view-files/mwqm-site-item-view-files.component';
import { MWQMSiteItemViewTablesComponent } from './components/mwqm-site/mwqm-site-item-view-tables/mwqm-site-item-view-tables.component';
import { MonitoringStatsComponent } from './components/monitoring-stats/monitoring-stats/monitoring-stats.component';
import { MonitoringStatsChartsComponent } from './components/monitoring-stats/monitoring-stats-charts/monitoring-stats-charts.component';
import { MonitoringStatsTablesComponent } from './components/monitoring-stats/monitoring-stats-tables/monitoring-stats-tables.component';
import { PolSourceSiteItemMenuOpenComponent } from './components/pol-source-site/pol-source-site-item-menu-open/pol-source-site-item-menu-open.component';
import { PolSourceSiteItemViewFilesComponent } from './components/pol-source-site/pol-source-site-item-view-files/pol-source-site-item-view-files.component';
import { PolSourceSiteItemViewInfoComponent } from './components/pol-source-site/pol-source-site-item-view-info/pol-source-site-item-view-info.component';
import { MWQMRunItemMenuOpenComponent } from './components/mwqm-run/mwqm-run-item-menu-open/mwqm-run-item-menu-open.component';
import { ContactItemCreateComponent } from './components/contact/contact-item-create/contact-item-create.component';
import { ContactItemModifyComponent } from './components/contact/contact-item-modify/contact-item-modify.component';
import { ContactItemViewComponent } from './components/contact/contact-item-view/contact-item-view.component';
import { MikeScenarioItemCreateComponent } from './components/mike-scenario/mike-scenario-item-create/mike-scenario-item-create.component';
import { MikeScenarioItemMenuOpenComponent } from './components/mike-scenario/mike-scenario-item-menu-open/mike-scenario-item-menu-open.component';
import { MikeScenarioItemViewFilesComponent } from './components/mike-scenario/mike-scenario-item-view-files/mike-scenario-item-view-files.component';
import { MikeScenarioItemViewInformationComponent } from './components/mike-scenario/mike-scenario-item-view-information/mike-scenario-item-view-information.component';
import { MikeScenarioItemViewInformationGeneralParametersComponent } from './components/mike-scenario/mike-scenario-item-view-information-general-parameters/mike-scenario-item-view-information-general-parameters.component';
import { MikeScenarioItemViewInformationSourcesComponent } from './components/mike-scenario/mike-scenario-item-view-information-sources/mike-scenario-item-view-information-sources.component';

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
    BoxModelItemComponent,
    BoxModelItemInputComponent,
    BoxModelItemListComponent,
    BoxModelItemResultComponent,
    BreadCrumbComponent,
    ChartBaseComponent,
    ChartMonitoringStatsByMonthComponent,
    ChartMonitoringStatsBySeasonComponent,
    ChartMonitoringStatsByYearComponent,
    ChartMWQMRunDataComponent,
    ChartMWQMSiteFCSalTempComponent,
    ChartMWQMSiteFCStatsComponent,
    ContactItemComponent,
    ContactItemCreateComponent,
    ContactItemModifyComponent,
    ContactItemViewComponent,
    CountryItemComponent,
    CountryTVItemListDetailComponent,
    CountryTVItemListItemComponent,
    EmailComponent,
    EmailDistributionListItemComponent,
    ErrorComponent,
    ExportArcGISComponent,
    FileListComponent,
    FileListItemComponent,
    FileListItemCreateComponent,
    FileListItemDetailComponent,
    FileListItemDownloadComponent,
    FileListItemLastUpdateComponent,
    FileListItemLocalizeComponent,
    FileListItemModifyComponent,
    FileListItemMenuComponent,
    FileListItemMenuOpenComponent,
    FileListItemViewComponent,
    FileListLocalizeAllComponent,
    FileUploadComponent,
    FooterComponent,
    HomeItemComponent,
    HomeTestComponent,
    InfrastructureItemComponent,
    InfrastructureItemCreateComponent,
    InfrastructureItemFilesComponent,
    InfrastructureItemInformationComponent,
    InfrastructureItemListComponent,
    InfrastructureItemMenuComponent,
    InfrastructureItemMenuOpenComponent,
    InfrastructureItemModifyComponent,
    InfrastructureItemViewComponent,
    InfrastructureItemVisualPlumesComponent,
    LogBookItemComponent,
    MapItemComponent,
    MapMenuComponent,
    MikeScenarioItemComponent,
    MikeScenarioItemCreateComponent,
    MikeScenarioItemMenuOpenComponent,
    MikeScenarioItemModifyComponent,
    MikeScenarioItemViewComponent,
    MikeScenarioItemViewFilesComponent,
    MikeScenarioItemViewInformationComponent,
    MikeScenarioItemViewInformationGeneralParametersComponent,
    MikeScenarioItemViewInformationSourcesComponent,
    MikeScenarioTVItemListDetailComponent,
    MikeScenarioTVItemListItemComponent,
    MonitoringStatsChartsComponent,
    MonitoringStatsComponent,
    MonitoringStatsTablesComponent,
    MunicipalityItemComponent,
    MunicipalityTVItemListDetailComponent,
    MunicipalityTVItemListItemComponent,
    MWQMRunItemComponent,
    MWQMRunItemCreateComponent,
    MWQMRunItemMenuOpenComponent,
    MWQMRunItemModifyComponent,
    MWQMRunItemViewComponent,
    MWQMRunTVItemListDetailComponent,
    MWQMRunTVItemListItemComponent,
    MWQMSiteItemComponent,
    MWQMSiteItemCreateComponent,
    MWQMSiteItemDetailComponent,
    MWQMSiteItemMenuOpenComponent,
    MWQMSiteItemModifyComponent,
    MWQMSiteItemViewComponent,
    MWQMSiteItemViewChartsComponent,
    MWQMSiteItemViewFilesComponent,
    MWQMSiteItemViewTablesComponent,
    MWQMSiteTVItemListItemComponent,
    MWQMSiteTVItemListItemSpecialComponent,
    NotImplementedYetComponent,
    OpenDataItemComponent,
    OpenDataNationalItemComponent,
    PolSourceSiteItemComponent,
    PolSourceSiteItemCreateComponent,
    PolSourceSiteItemIssueComponent,
    PolSourceSiteItemMenuOpenComponent,
    PolSourceSiteItemModifyComponent,
    PolSourceSiteItemObsComponent,
    PolSourceSiteItemViewComponent,
    PolSourceSiteItemViewFilesComponent,
    PolSourceSiteItemViewInfoComponent,
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
    TableInfrastructureSingleComponent,
    TableInfrastructureSingleOutfallComponent,
    TableMonitoringStatsByMonthComponent,
    TableMonitoringStatsBySeasonComponent,
    TableMonitoringStatsByYearComponent,
    TableMWQMRunDataComponent,
    TableMWQMSiteFCStatsComponent,
    TelComponent,
    TVItemCreateComponent,
    TVItemItemComponent,
    TVItemLastUpdateComponent,
    TVItemMenuComponent,
    TVItemModifyComponent,
    TVItemViewComponent,
    TVItemMenuOpenComponent,
    VisualPlumesItemComponent,
    VisualPlumesItemInputAmbientComponent,
    VisualPlumesItemInputDiffuserComponent,
    VisualPlumesItemListComponent,
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
    BoxModelItemComponent,
    BoxModelItemInputComponent,
    BoxModelItemListComponent,
    BoxModelItemResultComponent,
    BreadCrumbComponent,
    ChartBaseComponent,
    ChartMonitoringStatsByMonthComponent,
    ChartMonitoringStatsBySeasonComponent,
    ChartMonitoringStatsByYearComponent,
    ChartMWQMRunDataComponent,
    ChartMWQMSiteFCSalTempComponent,
    ChartMWQMSiteFCStatsComponent,
    ContactItemComponent,
    ContactItemCreateComponent,
    ContactItemModifyComponent,
    ContactItemViewComponent,
    CountryItemComponent,
    CountryTVItemListDetailComponent,
    CountryTVItemListItemComponent,
    EmailComponent,
    EmailDistributionListItemComponent,
    ErrorComponent,
    ExportArcGISComponent,
    FileListComponent,
    FileListItemComponent,
    FileListItemCreateComponent,
    FileListItemDetailComponent,
    FileListItemDownloadComponent,
    FileListItemLastUpdateComponent,
    FileListItemLocalizeComponent,
    FileListItemModifyComponent,
    FileListItemMenuComponent,
    FileListItemMenuOpenComponent,
    FileListItemViewComponent,
    FileListLocalizeAllComponent,
    FileUploadComponent,
    FooterComponent,
    HomeItemComponent,
    HomeTestComponent,
    InfrastructureItemComponent,
    InfrastructureItemCreateComponent,
    InfrastructureItemFilesComponent,
    InfrastructureItemInformationComponent,
    InfrastructureItemListComponent,
    InfrastructureItemMenuComponent,
    InfrastructureItemMenuOpenComponent,
    InfrastructureItemModifyComponent,
    InfrastructureItemViewComponent,
    InfrastructureItemVisualPlumesComponent,
    LogBookItemComponent,
    MapItemComponent,
    MapMenuComponent,
    MikeScenarioItemComponent,
    MikeScenarioItemCreateComponent,
    MikeScenarioItemMenuOpenComponent,
    MikeScenarioItemModifyComponent,
    MikeScenarioItemViewComponent,
    MikeScenarioItemViewFilesComponent,
    MikeScenarioItemViewInformationComponent,
    MikeScenarioItemViewInformationGeneralParametersComponent,
    MikeScenarioItemViewInformationSourcesComponent,
    MikeScenarioTVItemListDetailComponent,
    MikeScenarioTVItemListItemComponent,
    MonitoringStatsChartsComponent,
    MonitoringStatsComponent,
    MonitoringStatsTablesComponent,
    MunicipalityItemComponent,
    MunicipalityTVItemListDetailComponent,
    MunicipalityTVItemListItemComponent,
    MWQMRunItemComponent,
    MWQMRunItemCreateComponent,
    MWQMRunItemMenuOpenComponent,
    MWQMRunItemModifyComponent,
    MWQMRunItemViewComponent,
    MWQMRunTVItemListDetailComponent,
    MWQMRunTVItemListItemComponent,
    MWQMSiteItemComponent,
    MWQMSiteItemCreateComponent,
    MWQMSiteItemDetailComponent,
    MWQMSiteItemMenuOpenComponent,
    MWQMSiteItemModifyComponent,
    MWQMSiteItemViewComponent,
    MWQMSiteItemViewChartsComponent,
    MWQMSiteItemViewFilesComponent,
    MWQMSiteItemViewTablesComponent,
    MWQMSiteTVItemListItemComponent,
    MWQMSiteTVItemListItemSpecialComponent,
    NotImplementedYetComponent,
    OpenDataItemComponent,
    OpenDataNationalItemComponent,
    PolSourceSiteItemComponent,
    PolSourceSiteItemCreateComponent,
    PolSourceSiteItemIssueComponent,
    PolSourceSiteItemMenuOpenComponent,
    PolSourceSiteItemModifyComponent,
    PolSourceSiteItemObsComponent,
    PolSourceSiteItemViewComponent,
    PolSourceSiteItemViewFilesComponent,
    PolSourceSiteItemViewInfoComponent,
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
    TableInfrastructureSingleComponent,
    TableInfrastructureSingleOutfallComponent,
    TableMonitoringStatsByMonthComponent,
    TableMonitoringStatsBySeasonComponent,
    TableMonitoringStatsByYearComponent,
    TableMWQMRunDataComponent,
    TableMWQMSiteFCStatsComponent,
    TelComponent,
    TVItemCreateComponent,
    TVItemItemComponent,
    TVItemLastUpdateComponent,
    TVItemMenuComponent,
    TVItemModifyComponent,
    TVItemViewComponent,
    TVItemMenuOpenComponent,
    VisualPlumesItemComponent,
    VisualPlumesItemInputAmbientComponent,
    VisualPlumesItemInputDiffuserComponent,
    VisualPlumesItemListComponent,
  ]
})
export class SharedModule { }
