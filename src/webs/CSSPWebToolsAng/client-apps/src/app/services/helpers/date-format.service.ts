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
      if (this.appLanguageService.Language == LanguageEnum.fr) {
        return `${Day} ${this.GetMonthName(Month, false)} ${Year} ${HourText}:${MinuteText}:${SecondText} (utc)`;
      }

      return `${this.GetMonthName(Month, false)} ${Day}, ${Year} ${HourText}:${MinuteText}:${SecondText} (utc)`;
    }
    else {
      if (this.appLanguageService.Language == LanguageEnum.fr) {
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
            return this.appLanguageService.DateJanuaryAcronym[this.appLanguageService.LangID];
          }
          return this.appLanguageService.DateJanuary[this.appLanguageService.LangID];
        }
      case 2:
        {
          if (acronym) {
            return this.appLanguageService.DateFebruaryAcronym[this.appLanguageService.LangID];
          }
          return this.appLanguageService.DateFebruary[this.appLanguageService.LangID];
        }
      case 3:
        {
          if (acronym) {
            return this.appLanguageService.DateMarchAcronym[this.appLanguageService.LangID];
          }
          return this.appLanguageService.DateMarch[this.appLanguageService.LangID];
        }
      case 4:
        {
          if (acronym) {
            return this.appLanguageService.DateAprilAcronym[this.appLanguageService.LangID];
          }
          return this.appLanguageService.DateApril[this.appLanguageService.LangID];
        }
      case 5:
        {
          if (acronym) {
            return this.appLanguageService.DateMayAcronym[this.appLanguageService.LangID];
          }
          return this.appLanguageService.DateMay[this.appLanguageService.LangID];
        }
      case 6:
        {
          if (acronym) {
            return this.appLanguageService.DateJuneAcronym[this.appLanguageService.LangID];
          }
          return this.appLanguageService.DateJune[this.appLanguageService.LangID];
        }
      case 7:
        {
          if (acronym) {
            return this.appLanguageService.DateJulyAcronym[this.appLanguageService.LangID];
          }
          return this.appLanguageService.DateJuly[this.appLanguageService.LangID];
        }
      case 8:
        {
          if (acronym) {
            return this.appLanguageService.DateAugustAcronym[this.appLanguageService.LangID];
          }
          return this.appLanguageService.DateAugust[this.appLanguageService.LangID];
        }
      case 9:
        {
          if (acronym) {
            return this.appLanguageService.DateSeptemberAcronym[this.appLanguageService.LangID];
          }
          return this.appLanguageService.DateSeptember[this.appLanguageService.LangID];
        }
      case 10:
        {
          if (acronym) {
            return this.appLanguageService.DateOctoberAcronym[this.appLanguageService.LangID];
          }
          return this.appLanguageService.DateOctober[this.appLanguageService.LangID];
        }
      case 11:
        {
          if (acronym) {
            return this.appLanguageService.DateNovemberAcronym[this.appLanguageService.LangID];
          }
          return this.appLanguageService.DateNovember[this.appLanguageService.LangID];
        }
      case 12:
        {
          if (acronym) {
            return this.appLanguageService.DateDecemberAcronym[this.appLanguageService.LangID];
          }
          return this.appLanguageService.DateDecember[this.appLanguageService.LangID];
        }
    }
  }
}
