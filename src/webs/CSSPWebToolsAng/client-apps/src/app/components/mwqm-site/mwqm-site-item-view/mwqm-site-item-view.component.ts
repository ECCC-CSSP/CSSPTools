import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetWebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { MWQMSiteModel } from 'src/app/models/generated/models/MWQMSiteModel.model';
import { StatMWQMSiteSample } from 'src/app/models/generated/models/StatMWQMSiteSample.model';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';

@Component({
  selector: 'app-mwqm-site-item-view',
  templateUrl: './mwqm-site-item-view.component.html',
  styleUrls: ['./mwqm-site-item-view.component.css']
})
export class MWQMSiteItemViewComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  ChartsVisible: boolean = true;
  FilesVisible: boolean = false;
  TablesVisible: boolean = false;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public dateFormatService: DateFormatService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

  GetFileCount(): number {
    let MWQMSiteModelList: MWQMSiteModel[] = this.appLoadedService.WebMWQMSites.MWQMSiteModelList.filter(c => c.TVItemModel.TVItem.TVItemID == this.TVItemModel.TVItem.TVItemID);
    if (MWQMSiteModelList != undefined && MWQMSiteModelList.length > 0) {
      return MWQMSiteModelList[0].TVFileModelList.length;
    }

  }
}
