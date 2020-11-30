import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MWQMSiteLatestClassificationEnum } from 'src/app/enums/generated/MWQMSiteLatestClassificationEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { StatMWQMRun } from 'src/app/models/generated/web/StatMWQMRun.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';

@Component({
  selector: 'app-analysis',
  templateUrl: './analysis.component.html',
  styleUrls: ['./analysis.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AnalysisComponent implements OnInit, OnDestroy {
  @Input() TVItemList: WebBase[] = [];
  @Input() AppState: AppState;
  @Input() StatMWQMSiteList: StatMWQMSite[] = [];
  @Input() StatMWQMRunList: StatMWQMRun[] = [];

  languageEnum = GetLanguageEnum();
  tvTypeEnum = GetTVTypeEnum();
  language: number;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public dateFormatService: DateFormatService) { }

  ngOnInit(): void {
    this.language = <number>this.appStateService.AppState$.getValue().Language;
  }

  ngOnDestroy(): void {
  }

  GetColSpan(): string {
    return this.StatMWQMRunList.length.toString();
  }

  GetClassificationAcronym(mwqmSiteLatestClassification: MWQMSiteLatestClassificationEnum): string {
    switch (mwqmSiteLatestClassification) {
      case MWQMSiteLatestClassificationEnum.Approved:
        return this.language == this.languageEnum.fr ? 'A' : 'A';
      case MWQMSiteLatestClassificationEnum.ConditionallyApproved:
        return this.language == this.languageEnum.fr ? 'AC' : 'CA';
      case MWQMSiteLatestClassificationEnum.ConditionallyRestricted:
        return this.language == this.languageEnum.fr ? 'RC' : 'CR';
      case MWQMSiteLatestClassificationEnum.Prohibited:
        return this.language == this.languageEnum.fr ? 'P' : 'P';
      case MWQMSiteLatestClassificationEnum.Restricted:
        return this.language == this.languageEnum.fr ? 'R' : 'R';
      case MWQMSiteLatestClassificationEnum.Unclassified:
        return this.language == this.languageEnum.fr ? 'U' : 'NC';
      default:
        return this.language == this.languageEnum.fr ? '' : '';
    }
  }

  GetClassificationColor(mwqmSiteLatestClassification: MWQMSiteLatestClassificationEnum): string {
    switch (mwqmSiteLatestClassification) {
      case MWQMSiteLatestClassificationEnum.Approved:
        return 'bggreen';
      case MWQMSiteLatestClassificationEnum.ConditionallyApproved:
        return 'bggreen';
      case MWQMSiteLatestClassificationEnum.ConditionallyRestricted:
        return 'bgred';
      case MWQMSiteLatestClassificationEnum.Prohibited:
        return 'bgblack';
      case MWQMSiteLatestClassificationEnum.Restricted:
        return 'bgred';
      case MWQMSiteLatestClassificationEnum.Unclassified:
        return 'bgwhite';
      default:
        return 'bgwhite';
    }


  }

}
