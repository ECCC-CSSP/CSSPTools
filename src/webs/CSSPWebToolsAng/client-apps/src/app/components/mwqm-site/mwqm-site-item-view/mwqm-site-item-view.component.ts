import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { StatMWQMSiteSample } from 'src/app/models/generated/web/StatMWQMSiteSample.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';

@Component({
  selector: 'app-mwqm-site-item-view',
  templateUrl: './mwqm-site-item-view.component.html',
  styleUrls: ['./mwqm-site-item-view.component.css']
})
export class MWQMSiteItemViewComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

   StatMWQMSiteSampleList: StatMWQMSiteSample[] = [];
   CanvasNameFCSalTemp: string = '';
   CanvasNameFCStat: string = '';

   displayedColumns: string[] = ['Index', 'SampleDate', 'FC', 'Sal', 'Temp', 'pH', 'Depth', 'GeoMean', 'Median', 'P90', 'PercOver43', 'PercOver260'];

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public loaderService: LoaderService,
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
