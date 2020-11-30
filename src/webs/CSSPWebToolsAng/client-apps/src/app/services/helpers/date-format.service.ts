import { Injectable } from '@angular/core';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MWQMRun } from 'src/app/models/generated/db/MWQMRun.model';
import { MWQMSample } from 'src/app/models/generated/db/MWQMSample.model';
import { StatMWQMSiteSample } from 'src/app/models/generated/web/StatMWQMSiteSample.model';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
  providedIn: 'root'
})
export class DateFormatService {

  constructor(private appStateService: AppStateService,
    private appLanguageService: AppLanguageService) {
  }

  GetStatMWQMSiteSampleSampleLastSampleDate(statMWQMSiteSample: StatMWQMSiteSample) {
    if (statMWQMSiteSample === undefined) {
      return "";
    }

    if (statMWQMSiteSample.LastSampleDate === undefined)
    {
      return "";
    }

    return this.GetDateFromDateText(statMWQMSiteSample.LastSampleDate.toString(), true);
  }

  GetMWQMRunDateTime_LocalDigit(mwqmRun: MWQMRun) {
    let DateText: string = mwqmRun.DateTime_Local.toString();

    return `${DateText.substring(0, 4)}-${DateText.substring(5, 7)}-${DateText.substring(8, 10)}`;
  }

  GetMWQMSampleDateTime_LocalDigit(mwqmSample: MWQMSample) {
    let DateText: string = mwqmSample.SampleDateTime_Local.toString();

    return `${DateText.substring(0, 4)}-${DateText.substring(5, 7)}-${DateText.substring(8, 10)}`;
  }

  GetMWQMSampleSampleDateTime_Local(mwqmSample: MWQMSample) {
    return this.GetDateFromDateText(mwqmSample.SampleDateTime_Local.toString(), false);
  }

  GetLastUpdateDateTVItemModel(tvItemModel: TVItemModel) {
    return this.GetDateFromDateText(tvItemModel.TVItem.LastUpdateDate_UTC.toString(), false);
  }

  GetLastUpdateDateTVFileModel(tvFileModel: TVFileModel) {
    return this.GetDateFromDateText(tvFileModel.TVFile.LastUpdateDate_UTC.toString(), false);
  }

  GetFileCreateDate(tvFileModel: TVFileModel) {
    return this.GetDateFromDateText(tvFileModel.TVFile.FileCreatedDate_UTC.toString(), false);
  }

  private GetDateFromDateText(DateText: string, DateOnly: boolean) {
    let Year: number = parseInt(DateText.substring(0, 4));
    let Month: number = parseInt(DateText.substring(5, 7));
    let Day: number = parseInt(DateText.substring(8, 10));
    if (!DateOnly) {
      let Hour: number = parseInt(DateText.substring(11, 13));
      let Minute: number = parseInt(DateText.substring(14, 16));
      let Second: number = parseInt(DateText.substring(17, 19));
      let HourText: string = Hour < 10 ? `0${Hour}` : `${Hour}`;
      let MinuteText: string = Minute < 10 ? `0${Minute}` : `${Minute}`;
      let SecondText: string = Second < 10 ? `0${Second}` : `${Second}`;
      if (this.appStateService.AppState$.getValue().Language == LanguageEnum.fr) {
        return `${Day} ${this.GetMonthName(Month, false)} ${Year} ${HourText}:${MinuteText}:${SecondText} (utc)`;
      }

      return `${this.GetMonthName(Month, false)} ${Day}, ${Year} ${HourText}:${MinuteText}:${SecondText} (utc)`;
    }
    else {
      if (this.appStateService.AppState$.getValue().Language == LanguageEnum.fr) {
        return `${Day} ${this.GetMonthName(Month, false)} ${Year}`;
      }

      return `${this.GetMonthName(Month, false)} ${Day}, ${Year}`;

    }
  }

  GetMonthName(month: number, acronym: boolean = false): string {
    switch (month) {
      case 1:
        {
          if (acronym) {
            return this.appLanguageService.AppLanguage.DateJanuaryAcronym[this.appStateService.AppState$.getValue().Language];
          }
          return this.appLanguageService.AppLanguage.DateJanuary[this.appStateService.AppState$.getValue().Language];
        }
      case 2:
        {
          if (acronym) {
            return this.appLanguageService.AppLanguage.DateFebruaryAcronym[this.appStateService.AppState$.getValue().Language];
          }
          return this.appLanguageService.AppLanguage.DateFebruary[this.appStateService.AppState$.getValue().Language];
        }
      case 3:
        {
          if (acronym) {
            return this.appLanguageService.AppLanguage.DateMarchAcronym[this.appStateService.AppState$.getValue().Language];
          }
          return this.appLanguageService.AppLanguage.DateMarch[this.appStateService.AppState$.getValue().Language];
        }
      case 4:
        {
          if (acronym) {
            return this.appLanguageService.AppLanguage.DateAprilAcronym[this.appStateService.AppState$.getValue().Language];
          }
          return this.appLanguageService.AppLanguage.DateApril[this.appStateService.AppState$.getValue().Language];
        }
      case 5:
        {
          if (acronym) {
            return this.appLanguageService.AppLanguage.DateMayAcronym[this.appStateService.AppState$.getValue().Language];
          }
          return this.appLanguageService.AppLanguage.DateMay[this.appStateService.AppState$.getValue().Language];
        }
      case 6:
        {
          if (acronym) {
            return this.appLanguageService.AppLanguage.DateJuneAcronym[this.appStateService.AppState$.getValue().Language];
          }
          return this.appLanguageService.AppLanguage.DateJune[this.appStateService.AppState$.getValue().Language];
        }
      case 7:
        {
          if (acronym) {
            return this.appLanguageService.AppLanguage.DateJulyAcronym[this.appStateService.AppState$.getValue().Language];
          }
          return this.appLanguageService.AppLanguage.DateJuly[this.appStateService.AppState$.getValue().Language];
        }
      case 8:
        {
          if (acronym) {
            return this.appLanguageService.AppLanguage.DateAugustAcronym[this.appStateService.AppState$.getValue().Language];
          }
          return this.appLanguageService.AppLanguage.DateAugust[this.appStateService.AppState$.getValue().Language];
        }
      case 9:
        {
          if (acronym) {
            return this.appLanguageService.AppLanguage.DateSeptemberAcronym[this.appStateService.AppState$.getValue().Language];
          }
          return this.appLanguageService.AppLanguage.DateSeptember[this.appStateService.AppState$.getValue().Language];
        }
      case 10:
        {
          if (acronym) {
            return this.appLanguageService.AppLanguage.DateOctoberAcronym[this.appStateService.AppState$.getValue().Language];
          }
          return this.appLanguageService.AppLanguage.DateOctober[this.appStateService.AppState$.getValue().Language];
        }
      case 11:
        {
          if (acronym) {
            return this.appLanguageService.AppLanguage.DateNovemberAcronym[this.appStateService.AppState$.getValue().Language];
          }
          return this.appLanguageService.AppLanguage.DateNovember[this.appStateService.AppState$.getValue().Language];
        }
      case 12:
        {
          if (acronym) {
            return this.appLanguageService.AppLanguage.DateDecemberAcronym[this.appStateService.AppState$.getValue().Language];
          }
          return this.appLanguageService.AppLanguage.DateDecember[this.appStateService.AppState$.getValue().Language];
        }
    }
  }
}
