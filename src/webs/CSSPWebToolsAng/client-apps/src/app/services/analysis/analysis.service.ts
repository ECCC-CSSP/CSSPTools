import { Injectable } from '@angular/core';
import { AnalysisCalculationTypeEnum, AnalysisCalculationTypeEnum_GetIDText, AnalysisCalculationTypeEnum_GetOrderedText } from 'src/app/enums/generated/AnalysisCalculationTypeEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MWQMSiteLatestClassificationEnum } from 'src/app/enums/generated/MWQMSiteLatestClassificationEnum';
import { TideTextEnum } from 'src/app/enums/generated/TideTextEnum';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { StatMWQMRun } from 'src/app/models/generated/web/StatMWQMRun.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLanguageService } from '../app/app-language.service';
import { StatService } from '../helpers/stat.service';

@Injectable({
  providedIn: 'root'
})
export class AnalysisService {

  constructor(private appStateService: AppStateService,
    private appLanguageService: AppLanguageService,
    private statService: StatService,
    ) { }


  GetRainHighlight(statMWQMRun: StatMWQMRun): string {
    if (statMWQMRun.RainDay1 >= this.appStateService.UserPreference.AnalysisWet24h) {
      return 'highlightYellow';
    }
    if ((statMWQMRun.RainDay1 + statMWQMRun.RainDay2) >= this.appStateService.UserPreference.AnalysisWet48h) {
      return 'highlightYellow';
    }
    if ((statMWQMRun.RainDay1 + statMWQMRun.RainDay2 + statMWQMRun.RainDay3) >= this.appStateService.UserPreference.AnalysisWet72h) {
      return 'highlightYellow';
    }
    if ((statMWQMRun.RainDay1 + statMWQMRun.RainDay2 + statMWQMRun.RainDay3 + statMWQMRun.RainDay4) >= this.appStateService.UserPreference.AnalysisWet96h) {
      return 'highlightYellow';
    }

    return '';
  }

  GetSalinityHighlight(statMWQMSite: StatMWQMSite, runIndex: number): string {
    let highlight: string = Math.abs(statMWQMSite?.StatMWQMSiteSampleList[runIndex]?.Sal - statMWQMSite.SalinityAverage) > this.appStateService.UserPreference.AnalysisHighlightSalFromAverage ? 'borderBottomRed' : ''

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
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();
  }

  ToggleAnalysisFullYear(): void {
    this.appStateService.UserPreference.AnalysisFullYear = !this.appStateService.UserPreference.AnalysisFullYear;
    this.appStateService.Working = false;
  }

  ToggleAnalysisShowOnlyUsed(): void {
    this.appStateService.AnalysisShowOnlyUsed = !this.appStateService.AnalysisShowOnlyUsed;
    this.appStateService.Working = false;
  }

  ToggleAnalysisFCDataVisible(): void {
    this.appStateService.UserPreference.AnalysisFCDataVisible = !this.appStateService.UserPreference.AnalysisFCDataVisible;
    this.appStateService.Working = false;
  }

  ToggleAnalysisTempDataVisible(): void {
    this.appStateService.UserPreference.AnalysisTempDataVisible = !this.appStateService.UserPreference.AnalysisTempDataVisible;
    this.appStateService.Working = false;
  }

  ToggleAnalysisSalDataVisible(): void {
    this.appStateService.UserPreference.AnalysisSalDataVisible = !this.appStateService.UserPreference.AnalysisSalDataVisible;
    this.appStateService.Working = false;
  }

  ToggleAnalysisP90DataVisible(): void {
    this.appStateService.UserPreference.AnalysisP90DataVisible = !this.appStateService.UserPreference.AnalysisP90DataVisible;
    this.appStateService.Working = false;
  }

  ToggleAnalysisGeoMeanDataVisible(): void {
    this.appStateService.UserPreference.AnalysisGeoMeanDataVisible = !this.appStateService.UserPreference.AnalysisGeoMeanDataVisible;
    this.appStateService.Working = false;
  }

  ToggleAnalysisMedianDataVisible(): void {
    this.appStateService.UserPreference.AnalysisMedianDataVisible = !this.appStateService.UserPreference.AnalysisMedianDataVisible;
    this.appStateService.Working = false;
  }

  ToggleAnalysisPerOver43DataVisible(): void {
    this.appStateService.UserPreference.AnalysisPerOver43DataVisible = !this.appStateService.UserPreference.AnalysisPerOver43DataVisible;
    this.appStateService.Working = false;
  }

  ToggleAnalysisPerOver260DataVisible(): void {
    this.appStateService.UserPreference.AnalysisPerOver260DataVisible = !this.appStateService.UserPreference.AnalysisPerOver260DataVisible;
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
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();
  }

  SetEndRun(statEndMWQMRun: StatMWQMRun) {
    this.appStateService.AnalysisEndRun = statEndMWQMRun;
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();
  }

  SetRuns(runs: number) {
    this.appStateService.UserPreference.AnalysisRuns = runs;
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();
  }

  SetCalculationType(statCalculationType: AnalysisCalculationTypeEnum) {
    this.appStateService.UserPreference.AnalysisCalculationType = statCalculationType;
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();
  }

  SetHighlightSalFromAverage(sal: number) {
    this.appStateService.UserPreference.AnalysisHighlightSalFromAverage = sal;
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();
  }

  // SetShortRange(shortRange: number) {
  //   this.appStateService.UserPreference.AnalysisShortRange: shortRange });
  // }

  // SetMidRange(midRange: number) {
  //   this.appStateService.UserPreference.AnalysisMidRange: midRange });
  // }

  SetDry24h(dry24h: number) {
    this.appStateService.UserPreference.AnalysisDry24h = dry24h;
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();
  }

  SetDry48h(dry48h: number) {
    this.appStateService.UserPreference.AnalysisDry48h = dry48h;
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();
  }

  SetDry72h(dry72h: number) {
    this.appStateService.UserPreference.AnalysisDry72h = dry72h;
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();
  }

  SetDry96h(dry96h: number) {
    this.appStateService.UserPreference.AnalysisDry96h = dry96h;
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();
  }

  SetWet24h(wet24h: number) {
    this.appStateService.UserPreference.AnalysisWet24h = wet24h;
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();
  }

  SetWet48h(wet48h: number) {
    this.appStateService.UserPreference.AnalysisWet48h = wet48h;
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();
  }

  SetWet72h(wet72h: number) {
    this.appStateService.UserPreference.AnalysisWet72h = wet72h;
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();
  }

  SetWet96h(wet96h: number) {
    this.appStateService.UserPreference.AnalysisWet96h = wet96h;
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();
  }

}
