import { Injectable } from '@angular/core';
import { AnalysisCalculationTypeEnum, AnalysisCalculationTypeEnum_GetIDText, AnalysisCalculationTypeEnum_GetOrderedText } from 'src/app/enums/generated/AnalysisCalculationTypeEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MWQMSiteLatestClassificationEnum } from 'src/app/enums/generated/MWQMSiteLatestClassificationEnum';
import { TideTextEnum } from 'src/app/enums/generated/TideTextEnum';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { StatMWQMRun } from 'src/app/models/generated/web/StatMWQMRun.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { AppStateService } from 'src/app/services/app-state.service';
//import { WebMWQMSamples2021_2060Service } from 'src/app/services/loaders/web-mwqm-samples_2021_2060.service';
import { AppLanguageService } from '../app-language.service';
import { LoaderService } from '../loaders/loader.service';

@Injectable({
  providedIn: 'root'
})
export class AnalysisService {

  constructor(private appStateService: AppStateService,
    private appLanguageService: AppLanguageService,
    private loaderService: LoaderService
    //private webMWQMSamples2021_2060Service: WebMWQMSamples2021_2060Service
    ) { }


  GetRainHighlight(statMWQMRun: StatMWQMRun): string {
    if (statMWQMRun.RainDay1 >= this.appStateService.AnalysisWet24h) {
      return 'highlightYellow';
    }
    if ((statMWQMRun.RainDay1 + statMWQMRun.RainDay2) >= this.appStateService.AnalysisWet48h) {
      return 'highlightYellow';
    }
    if ((statMWQMRun.RainDay1 + statMWQMRun.RainDay2 + statMWQMRun.RainDay3) >= this.appStateService.AnalysisWet72h) {
      return 'highlightYellow';
    }
    if ((statMWQMRun.RainDay1 + statMWQMRun.RainDay2 + statMWQMRun.RainDay3 + statMWQMRun.RainDay4) >= this.appStateService.AnalysisWet96h) {
      return 'highlightYellow';
    }

    return '';
  }

  GetSalinityHighlight(statMWQMSite: StatMWQMSite, runIndex: number): string {
    let highlight: string = Math.abs(statMWQMSite?.StatMWQMSiteSampleList[runIndex]?.Sal - statMWQMSite.SalinityAverage) > this.appStateService.AnalysisHighlightSalFromAverage ? 'borderBottomRed' : ''

    return highlight;
  }

  GetClassificationAcronym(mwqmSiteLatestClassification: MWQMSiteLatestClassificationEnum): string {
    switch (mwqmSiteLatestClassification) {
      case MWQMSiteLatestClassificationEnum.Approved:
        return this.appLanguageService.Language == LanguageEnum.fr ? 'A' : 'A';
      case MWQMSiteLatestClassificationEnum.ConditionallyApproved:
        return this.appLanguageService.Language == LanguageEnum.fr ? 'AC' : 'CA';
      case MWQMSiteLatestClassificationEnum.ConditionallyRestricted:
        return this.appLanguageService.Language == LanguageEnum.fr ? 'RC' : 'CR';
      case MWQMSiteLatestClassificationEnum.Prohibited:
        return this.appLanguageService.Language == LanguageEnum.fr ? 'P' : 'P';
      case MWQMSiteLatestClassificationEnum.Restricted:
        return this.appLanguageService.Language == LanguageEnum.fr ? 'R' : 'R';
      case MWQMSiteLatestClassificationEnum.Unclassified:
        return this.appLanguageService.Language == LanguageEnum.fr ? 'U' : 'NC';
      default:
        return this.appLanguageService.Language == LanguageEnum.fr ? '' : '';
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

  GetTideInitialText(tideTextEnum: TideTextEnum): string {
    switch (tideTextEnum) {
      case TideTextEnum.LowTide:
        return this.appLanguageService.Language == LanguageEnum.fr ? 'LT' : 'LT';
      case TideTextEnum.LowTideFalling:
        return this.appLanguageService.Language == LanguageEnum.fr ? 'LF' : 'LF';
      case TideTextEnum.LowTideRising:
        return this.appLanguageService.Language == LanguageEnum.fr ? 'LR' : 'LR';
      case TideTextEnum.MidTide:
        return this.appLanguageService.Language == LanguageEnum.fr ? 'MT' : 'MT';
      case TideTextEnum.MidTideFalling:
        return this.appLanguageService.Language == LanguageEnum.fr ? 'MF' : 'MF';
      case TideTextEnum.MidTideRising:
        return this.appLanguageService.Language == LanguageEnum.fr ? 'MR' : 'MR';
      case TideTextEnum.HighTide:
        return this.appLanguageService.Language == LanguageEnum.fr ? 'HT' : 'HT';
      case TideTextEnum.HighTideFalling:
        return this.appLanguageService.Language == LanguageEnum.fr ? 'HF' : 'HF';
      case TideTextEnum.HighTideRising:
        return this.appLanguageService.Language == LanguageEnum.fr ? 'HR' : 'HR';
      default:
        return '';
    }
  }

  ToggleRemoveFromStat(statEndMWQMRun: StatMWQMRun) {
    statEndMWQMRun.RemoveFromStat = !statEndMWQMRun.RemoveFromStat;
    this.loaderService.FillStatMWQMSiteList();
  }

  ToggleAnalysisFullYear(): void {
    this.appStateService.AnalysisFullYear = !this.appStateService.AnalysisFullYear;
    this.appStateService.Working = false;
  }

  ToggleAnalysisShowOnlyUsed(): void {
    this.appStateService.AnalysisShowOnlyUsed = !this.appStateService.AnalysisShowOnlyUsed;
    this.appStateService.Working = false;
  }

  ToggleAnalysisFCDataVisible(): void {
    this.appStateService.AnalysisFCDataVisible = !this.appStateService.AnalysisFCDataVisible;
    this.appStateService.Working = false;
  }

  ToggleAnalysisTempDataVisible(): void {
    this.appStateService.AnalysisTempDataVisible = !this.appStateService.AnalysisTempDataVisible;
    this.appStateService.Working = false;
  }

  ToggleAnalysisSalDataVisible(): void {
    this.appStateService.AnalysisSalDataVisible = !this.appStateService.AnalysisSalDataVisible;
    this.appStateService.Working = false;
  }

  ToggleAnalysisP90DataVisible(): void {
    this.appStateService.AnalysisP90DataVisible = !this.appStateService.AnalysisP90DataVisible;
    this.appStateService.Working = false;
  }

  ToggleAnalysisGeoMeanDataVisible(): void {
    this.appStateService.AnalysisGeoMeanDataVisible = !this.appStateService.AnalysisGeoMeanDataVisible;
    this.appStateService.Working = false;
  }

  ToggleAnalysisMedianDataVisible(): void {
    this.appStateService.AnalysisMedianDataVisible = !this.appStateService.AnalysisMedianDataVisible;
    this.appStateService.Working = false;
  }

  ToggleAnalysisPerOver43DataVisible(): void {
    this.appStateService.AnalysisPerOver43DataVisible = !this.appStateService.AnalysisPerOver43DataVisible;
    this.appStateService.Working = false;
  }

  ToggleAnalysisPerOver260DataVisible(): void {
    this.appStateService.AnalysisPerOver260DataVisible = !this.appStateService.AnalysisPerOver260DataVisible;
    this.appStateService.Working = false;
  }


  GetDryRain(): number[] {
    let dryRain_mm_List: number[] = [];

    for (let i = 0; i < 40; i++) {
      dryRain_mm_List.push(i);
    }

    return dryRain_mm_List;
  }

  GetWetRain(): number[] {
    let wetRain_mm_List: number[] = [];

    for (let i = 0; i < 150; i++) {
      wetRain_mm_List.push(i);
    }

    return wetRain_mm_List;
  }

  GetAnalysisCalculationTypeEnum_GetIDText(analysisCalculationTypeEnum: AnalysisCalculationTypeEnum) {
    return AnalysisCalculationTypeEnum_GetIDText(analysisCalculationTypeEnum, this.appLanguageService);
  }

  GetAnalysisCalculationTypeEnum_GetOrderedText(): EnumIDAndText[] {
    return AnalysisCalculationTypeEnum_GetOrderedText(this.appLanguageService);
  }

  SetStartRun(statStartMWQMRun: StatMWQMRun) {
    this.appStateService.AnalysisStartRun = statStartMWQMRun;
    this.loaderService.FillStatMWQMSiteList();
  }

  SetEndRun(statEndMWQMRun: StatMWQMRun) {
    this.appStateService.AnalysisEndRun = statEndMWQMRun;
    this.loaderService.FillStatMWQMSiteList();
  }

  SetRuns(runs: number) {
    this.appStateService.AnalysisRuns = runs;
    this.loaderService.FillStatMWQMSiteList();
  }

  SetCalculationType(statCalculationType: AnalysisCalculationTypeEnum) {
    this.appStateService.AnalysisCalculationType = statCalculationType;
    this.loaderService.FillStatMWQMSiteList();
  }

  SetHighlightSalFromAverage(sal: number) {
    this.appStateService.AnalysisHighlightSalFromAverage = sal;
    this.loaderService.FillStatMWQMSiteList();
  }

  // SetShortRange(shortRange: number) {
  //   this.appStateService.AnalysisShortRange: shortRange });
  // }

  // SetMidRange(midRange: number) {
  //   this.appStateService.AnalysisMidRange: midRange });
  // }

  SetDry24h(dry24h: number) {
    this.appStateService.AnalysisDry24h = dry24h;
    this.loaderService.FillStatMWQMSiteList();
  }

  SetDry48h(dry48h: number) {
    this.loaderService.FillStatMWQMSiteList();
    this.appStateService.AnalysisDry48h = dry48h;
  }

  SetDry72h(dry72h: number) {
    this.loaderService.FillStatMWQMSiteList();
    this.appStateService.AnalysisDry72h = dry72h;
  }

  SetDry96h(dry96h: number) {
    this.loaderService.FillStatMWQMSiteList();
    this.appStateService.AnalysisDry96h = dry96h;
  }

  SetWet24h(wet24h: number) {
    this.appStateService.AnalysisWet24h = wet24h;
    this.loaderService.FillStatMWQMSiteList();
  }

  SetWet48h(wet48h: number) {
    this.appStateService.AnalysisWet48h = wet48h;
    this.loaderService.FillStatMWQMSiteList();
  }

  SetWet72h(wet72h: number) {
    this.appStateService.AnalysisWet72h = wet72h;
    this.loaderService.FillStatMWQMSiteList();
  }

  SetWet96h(wet96h: number) {
    this.appStateService.AnalysisWet96h = wet96h;
    this.loaderService.FillStatMWQMSiteList();
  }

}
