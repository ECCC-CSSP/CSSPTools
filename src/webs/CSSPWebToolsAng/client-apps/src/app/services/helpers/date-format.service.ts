import { Injectable } from '@angular/core';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
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

  GetLastUpdateDateTVItemModel(tvItemModel: TVItemModel) {
    return this.GetDateFromDateText(tvItemModel.TVItem.LastUpdateDate_UTC.toString());
  }

  GetLastUpdateDateTVFileModel(tvFileModel: TVFileModel) {
    return this.GetDateFromDateText(tvFileModel.TVFile.LastUpdateDate_UTC.toString());
  }

  GetFileCreateDate(tvFileModel: TVFileModel) {
    return this.GetDateFromDateText(tvFileModel.TVFile.FileCreatedDate_UTC.toString());
  }

  private GetDateFromDateText(DateText: string) {
    let Year: number = parseInt(DateText.substring(0, 4));
    let Month: number = parseInt(DateText.substring(5, 7));
    let Day: number = parseInt(DateText.substring(8, 10));
    let Hour: number = parseInt(DateText.substring(11, 13));
    let Minute: number = parseInt(DateText.substring(14, 16));
    let Second: number = parseInt(DateText.substring(17, 19));
    if (this.appStateService.AppState$.getValue().Language == LanguageEnum.fr) {
      return `${Day} ${this.GetMonthName(Month, false)} ${Year} ${Hour}:${Minute}:${Second} (utc)`;
    }

    return `${this.GetMonthName(Month, false)} ${Day}, ${Year} ${Hour}:${Minute}:${Second} (utc)`;
  }

  private GetMonthName(month: number, acronym: boolean = false): string {
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
