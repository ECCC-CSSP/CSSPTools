import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetMWQMSiteLatestClassificationEnum, MWQMSiteLatestClassificationEnum, MWQMSiteLatestClassificationEnum_GetIDText } from 'src/app/enums/generated/MWQMSiteLatestClassificationEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { MWQMSample } from 'src/app/models/generated/db/MWQMSample.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { WebMWQMSampleService } from 'src/app/services/loaders/web-mwqm-samples.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-tvitem-list-item-mwqm-site-button',
  templateUrl: './tvitem-list-item-mwqm-site-button.component.html',
  styleUrls: ['./tvitem-list-item-mwqm-site-button.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListItemMWQMSiteButtonComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;
  @Input() Index: number;
  @Input() StatMWQMSite: StatMWQMSite;

  languageEnum = GetLanguageEnum();
  tvTypeEnum = GetTVTypeEnum();
  mwqmSiteLatestClassification = GetMWQMSiteLatestClassificationEnum();

  Year: number = 0;

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public subPageService: SubPageService,
    public mapService: MapService,
    public dateFormatService: DateFormatService,
    public webMWQMSamplesService: WebMWQMSampleService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  GetMWQMSiteLatestClassificationEnum_GetIDText(mwqmSiteLatestClassification: MWQMSiteLatestClassificationEnum): string {
    return MWQMSiteLatestClassificationEnum_GetIDText(mwqmSiteLatestClassification, this.appStateService);
  }

  IsFirstOfNewYear(DateText: string) {
    let SampleYear = parseInt(DateText);
    if (SampleYear != this.Year) {
      this.Year = SampleYear;
      return true;
    }
    else {
      return false;
    }
  }
}

