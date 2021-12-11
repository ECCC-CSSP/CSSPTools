import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetWebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { StatMWQMSiteSample } from 'src/app/models/generated/models/StatMWQMSiteSample.model';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';

@Component({
  selector: 'app-mwqm-site-item-view-charts',
  templateUrl: './mwqm-site-item-view-charts.component.html',
  styleUrls: ['./mwqm-site-item-view-charts.component.css']
})
export class MWQMSiteItemViewChartsComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  webChartAndTableType = GetWebChartAndTableTypeEnum();

   StatMWQMSiteSampleList: StatMWQMSiteSample[] = [];
   CanvasNameFCSalTemp: string = '';
   CanvasNameFCStat: string = '';

   ChartFCSalTempVisible: boolean = true;
   ChartFCStatsVisible: boolean = false;

   displayedColumns: string[] = ['Index', 'SampleDate', 'FC', 'Sal', 'Temp', 'pH', 'Depth', 'GeoMean', 'Median', 'P90', 'PercOver43', 'PercOver260'];

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public dateFormatService: DateFormatService) { }

  ngOnInit(): void {
    let StatMWQMSite = this.appLoadedService.StatMWQMSiteList.filter(c => c.TVItemModel.TVItem.TVItemID == this.TVItemModel.TVItem.TVItemID)[0];
    this.StatMWQMSiteSampleList = StatMWQMSite.StatMWQMSiteSampleList.filter(c => c.FC != null);

    this.CanvasNameFCSalTemp = `CanvasFCSalTemp${this.TVItemModel.TVItem.TVItemID}` 
    this.CanvasNameFCStat = `CanvasFCStat${this.TVItemModel.TVItem.TVItemID}` 
  }

  ngOnDestroy(): void {
  }
}
