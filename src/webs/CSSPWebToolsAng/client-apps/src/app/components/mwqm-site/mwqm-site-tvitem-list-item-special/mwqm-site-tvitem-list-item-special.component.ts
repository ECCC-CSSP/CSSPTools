import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetMWQMSiteLatestClassificationEnum, MWQMSiteLatestClassificationEnum, MWQMSiteLatestClassificationEnum_GetIDText } from 'src/app/enums/generated/MWQMSiteLatestClassificationEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-mwqm-site-tvitem-list-item-special',
  templateUrl: './mwqm-site-tvitem-list-item-special.component.html',
  styleUrls: ['./mwqm-site-tvitem-list-item-special.component.css']
})
export class MWQMSiteTVItemListItemSpecialComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

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
    public dateFormatService: DateFormatService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  GetMWQMSiteLatestClassificationEnum_GetIDText(mwqmSiteLatestClassification: MWQMSiteLatestClassificationEnum): string {
    return MWQMSiteLatestClassificationEnum_GetIDText(mwqmSiteLatestClassification, this.appLanguageService);
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

