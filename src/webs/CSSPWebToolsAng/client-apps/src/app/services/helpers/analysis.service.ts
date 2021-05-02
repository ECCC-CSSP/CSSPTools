import { Injectable } from '@angular/core';
import { AnalysisCalculationTypeEnum, AnalysisCalculationTypeEnum_GetIDText, AnalysisCalculationTypeEnum_GetOrderedText } from 'src/app/enums/generated/AnalysisCalculationTypeEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MWQMSiteLatestClassificationEnum } from 'src/app/enums/generated/MWQMSiteLatestClassificationEnum';
import { TideTextEnum } from 'src/app/enums/generated/TideTextEnum';
import { AppState } from 'src/app/models/AppState.model';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { StatMWQMRun } from 'src/app/models/generated/web/StatMWQMRun.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { WebMWQMSamplesService } from 'src/app/services/loaders/web-mwqm-samples.service';

@Injectable({
  providedIn: 'root'
})
export class AnalysisService {

  constructor(private appStateService: AppStateService,
    private webMWQMSamplesService: WebMWQMSamplesService)
    {}


  GetRainHighlight(statMWQMRun: StatMWQMRun): string {
    if (statMWQMRun.RainDay1 >= this.appStateService.AppState$.getValue().AnalysisWet24h) {
      return 'highlightYellow';
    }
    if ((statMWQMRun.RainDay1 + statMWQMRun.RainDay2) >= this.appStateService.AppState$.getValue().AnalysisWet48h) {
      return 'highlightYellow';
    }
    if ((statMWQMRun.RainDay1 + statMWQMRun.RainDay2 + statMWQMRun.RainDay3) >= this.appStateService.AppState$.getValue().AnalysisWet72h) {
      return 'highlightYellow';
    }
    if ((statMWQMRun.RainDay1 + statMWQMRun.RainDay2 + statMWQMRun.RainDay3 + statMWQMRun.RainDay4) >= this.appStateService.AppState$.getValue().AnalysisWet96h) {
      return 'highlightYellow';
    }

    return '';
  }

  GetSalinityHighlight(statMWQMSite: StatMWQMSite, runIndex: number): string {
    let highlight: string = Math.abs(statMWQMSite?.StatMWQMSiteSampleList[runIndex]?.Sal - statMWQMSite.SalinityAverage) > this.appStateService.AppState$.getValue().AnalysisHighlightSalFromAverage ? 'borderBottomRed' : ''

    return highlight;
  }

  GetClassificationAcronym(mwqmSiteLatestClassification: MWQMSiteLatestClassificationEnum): string {
    switch (mwqmSiteLatestClassification) {
      case MWQMSiteLatestClassificationEnum.Approved:
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? 'A' : 'A';
      case MWQMSiteLatestClassificationEnum.ConditionallyApproved:
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? 'AC' : 'CA';
      case MWQMSiteLatestClassificationEnum.ConditionallyRestricted:
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? 'RC' : 'CR';
      case MWQMSiteLatestClassificationEnum.Prohibited:
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? 'P' : 'P';
      case MWQMSiteLatestClassificationEnum.Restricted:
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? 'R' : 'R';
      case MWQMSiteLatestClassificationEnum.Unclassified:
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? 'U' : 'NC';
      default:
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? '' : '';
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
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? 'LT' : 'LT';
      case TideTextEnum.LowTideFalling:
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? 'LF' : 'LF';
      case TideTextEnum.LowTideRising:
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? 'LR' : 'LR';
      case TideTextEnum.MidTide:
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? 'MT' : 'MT';
      case TideTextEnum.MidTideFalling:
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? 'MF' : 'MF';
      case TideTextEnum.MidTideRising:
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? 'MR' : 'MR';
      case TideTextEnum.HighTide:
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? 'HT' : 'HT';
      case TideTextEnum.HighTideFalling:
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? 'HF' : 'HF';
      case TideTextEnum.HighTideRising:
        return this.appStateService.AppState$.getValue().Language == LanguageEnum.fr ? 'HR' : 'HR';
      default:
        return '';
    }
  }

  ToggleRemoveFromStat(statEndMWQMRun: StatMWQMRun) {
    statEndMWQMRun.RemoveFromStat = !statEndMWQMRun.RemoveFromStat;
    this.webMWQMSamplesService.FillStatMWQMSiteList();
  }

  ToggleAnalysisFullYear(): void {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisFullYear: !this.appStateService.AppState$.getValue().AnalysisFullYear, Working: false });
  }

  ToggleAnalysisShowOnlyUsed(): void {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisShowOnlyUsed: !this.appStateService.AppState$.getValue().AnalysisShowOnlyUsed, Working: false });
  }

  ToggleAnalysisFCDataVisible(): void {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisFCDataVisible: !this.appStateService.AppState$.getValue().AnalysisFCDataVisible, Working: false });
  }

  ToggleAnalysisTempDataVisible(): void {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisTempDataVisible: !this.appStateService.AppState$.getValue().AnalysisTempDataVisible, Working: false });
  }

  ToggleAnalysisSalDataVisible(): void {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisSalDataVisible: !this.appStateService.AppState$.getValue().AnalysisSalDataVisible, Working: false });
  }

  ToggleAnalysisP90DataVisible(): void {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisP90DataVisible: !this.appStateService.AppState$.getValue().AnalysisP90DataVisible, Working: false });
  }

  ToggleAnalysisGeoMeanDataVisible(): void {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisGeoMeanDataVisible: !this.appStateService.AppState$.getValue().AnalysisGeoMeanDataVisible, Working: false });
  }

  ToggleAnalysisMedianDataVisible(): void {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisMedianDataVisible: !this.appStateService.AppState$.getValue().AnalysisMedianDataVisible, Working: false });
  }

  ToggleAnalysisPerOver43DataVisible(): void {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisPerOver43DataVisible: !this.appStateService.AppState$.getValue().AnalysisPerOver43DataVisible, Working: false });
  }

  ToggleAnalysisPerOver260DataVisible(): void {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisPerOver260DataVisible: !this.appStateService.AppState$.getValue().AnalysisPerOver260DataVisible, Working: false });
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

    for (let i = 0; i < 150; i++)
    {
      wetRain_mm_List.push(i);
    } 

    return wetRain_mm_List;
  }

  GetAnalysisCalculationTypeEnum_GetIDText(analysisCalculationTypeEnum: AnalysisCalculationTypeEnum) {
    return AnalysisCalculationTypeEnum_GetIDText(analysisCalculationTypeEnum, this.appStateService);
  }

  GetAnalysisCalculationTypeEnum_GetOrderedText(): EnumIDAndText[] {
    return AnalysisCalculationTypeEnum_GetOrderedText(this.appStateService);
  }

  SetStartRun(statStartMWQMRun: StatMWQMRun) {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisStartRun: statStartMWQMRun });
    this.webMWQMSamplesService.FillStatMWQMSiteList();
  }

  SetEndRun(statEndMWQMRun: StatMWQMRun) {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisEndRun: statEndMWQMRun });
    this.webMWQMSamplesService.FillStatMWQMSiteList();
  }

  SetRuns(runs: number) {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisRuns: runs });
    this.webMWQMSamplesService.FillStatMWQMSiteList();
  }

  SetCalculationType(statCalculationType: AnalysisCalculationTypeEnum) {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisCalculationType: statCalculationType });
    this.webMWQMSamplesService.FillStatMWQMSiteList();
  }

  SetHighlightSalFromAverage(sal: number) {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisHighlightSalFromAverage: sal });
    this.webMWQMSamplesService.FillStatMWQMSiteList();
  }

  // SetShortRange(shortRange: number) {
  //   this.appStateService.UpdateAppState(<AppState>{ AnalysisShortRange: shortRange });
  // }

  // SetMidRange(midRange: number) {
  //   this.appStateService.UpdateAppState(<AppState>{ AnalysisMidRange: midRange });
  // }

  SetDry24h(dry24h: number) {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisDry24h: dry24h });
    this.webMWQMSamplesService.FillStatMWQMSiteList();
  }

  SetDry48h(dry48h: number) {
    this.webMWQMSamplesService.FillStatMWQMSiteList();
    this.appStateService.UpdateAppState(<AppState>{ AnalysisDry48h: dry48h });
  }

  SetDry72h(dry72h: number) {
    this.webMWQMSamplesService.FillStatMWQMSiteList();
    this.appStateService.UpdateAppState(<AppState>{ AnalysisDry72h: dry72h });
  }

  SetDry96h(dry96h: number) {
    this.webMWQMSamplesService.FillStatMWQMSiteList();
    this.appStateService.UpdateAppState(<AppState>{ AnalysisDry96h: dry96h });
  }

  SetWet24h(wet24h: number) {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisWet24h: wet24h });
    this.webMWQMSamplesService.FillStatMWQMSiteList();
  }

  SetWet48h(wet48h: number) {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisWet48h: wet48h });
    this.webMWQMSamplesService.FillStatMWQMSiteList();
  }

  SetWet72h(wet72h: number) {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisWet72h: wet72h });
    this.webMWQMSamplesService.FillStatMWQMSiteList();
  }

  SetWet96h(wet96h: number) {
    this.appStateService.UpdateAppState(<AppState>{ AnalysisWet96h: wet96h });
    this.webMWQMSamplesService.FillStatMWQMSiteList();
  }

}
