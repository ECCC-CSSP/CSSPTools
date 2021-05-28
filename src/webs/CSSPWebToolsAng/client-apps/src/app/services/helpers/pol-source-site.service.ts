import { Injectable } from '@angular/core';
import { AnalysisCalculationTypeEnum } from 'src/app/enums/generated/AnalysisCalculationTypeEnum';
import { GetPolSourceObsInfoEnum, PolSourceObsInfoEnum_GetOrderedText } from 'src/app/enums/generated/PolSourceObsInfoEnum';
import { GetPolSourceObsInfoTypeEnum } from 'src/app/enums/generated/PolSourceObsInfoTypeEnum';
import { SampleTypeEnum } from 'src/app/enums/generated/SampleTypeEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { PolSourceObservationIssue } from 'src/app/models/generated/db/PolSourceObservationIssue.model';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { ColorAndLetter } from 'src/app/models/generated/web/ColorAndLetter.model';
import { ContactModel } from 'src/app/models/generated/web/ContactModel.model';
import { MWQMRunModel } from 'src/app/models/generated/web/MWQMRunModel.model';
import { MWQMRunModelSiteAndSampleModel } from 'src/app/models/generated/web/MWQMRunModelSiteAndSampleModel.model';
import { MWQMSampleModel } from 'src/app/models/generated/web/MWQMSampleModel.model';
import { MWQMSiteModel } from 'src/app/models/generated/web/MWQMSiteModel.model';
import { MWQMSiteModelAndSampleModel } from 'src/app/models/generated/web/MWQMSiteModelAndSampleModel.model';
import { PolSourceGroupingModel } from 'src/app/models/generated/web/PolSourceGroupingModel.model';
import { PolSourceObservationModel } from 'src/app/models/generated/web/PolSourceObservationModel.model';
import { PolSourceSiteModel } from 'src/app/models/generated/web/PolSourceSiteModel.model';
import { StatMWQMRun } from 'src/app/models/generated/web/StatMWQMRun.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { StatMWQMSiteSample } from 'src/app/models/generated/web/StatMWQMSiteSample.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { AppLoadedService } from '../app-loaded.service';
import { SortMWQMRunListService } from './sort-mwqm-run-list-desc.service';
import { SortMWQMSiteModelListService } from './sort-mwqm-site-model-list.service';
import { SortMWQMSiteSampleModelListService } from './sort-mwqm-site-sample-list.service';

@Injectable({
  providedIn: 'root'
})
export class PolSourceSiteService {

  constructor(private appStateService: AppStateService,
    private appLanguageService: AppLanguageService,
    private appLoadedService: AppLoadedService,
    private sortMWQMSiteModelListService: SortMWQMSiteModelListService,
    private sortMWQMRunListService: SortMWQMRunListService,
    private sortMWQMSiteSampleModelListService: SortMWQMSiteSampleModelListService) {
  }

  GetRiskColor(tvItemModel: TVItemModel): string {
    let className: string = 'unknownRisk';

    let polSourceSiteModelList: PolSourceSiteModel[] = this.appLoadedService.WebPolSourceSites.PolSourceSiteModelList.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);

    if (polSourceSiteModelList != null && polSourceSiteModelList.length > 0) {
      let polSourceSiteModel: PolSourceSiteModel = polSourceSiteModelList[0];
      if (polSourceSiteModel.PolSourceObservationModelList != null && polSourceSiteModel.PolSourceObservationModelList.length > 0) {
        let polSourceObservationModel: PolSourceObservationModel = polSourceSiteModel.PolSourceObservationModelList[0];
        if (polSourceObservationModel.PolSourceObservationIssueList != null && polSourceObservationModel.PolSourceObservationIssueList.length > 0) {
          let polSourceObservationIssue: PolSourceObservationIssue = polSourceObservationModel.PolSourceObservationIssueList[0];
          {
            if (polSourceObservationIssue.ObservationInfo.includes(',91003')) {
              className = 'highRisk';
            }
            if (polSourceObservationIssue.ObservationInfo.includes(',91002')) {
              className = 'moderateRisk';
            }
            if (polSourceObservationIssue.ObservationInfo.includes(',91001')) {
              className = 'lowRisk';
            }
          }
        }
      }
    }

    return className;
  }

  GetPolSourceSiteModelList(tvItemModel: TVItemModel): PolSourceSiteModel[] {
    return this.appLoadedService.WebPolSourceSites.PolSourceSiteModelList.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);
  }

  GetContactModel(tvItemID: number): ContactModel {
    if (this.appLoadedService.WebAllContacts == undefined) {
      return <ContactModel>{};
    }
    let contactModelList: ContactModel[] = this.appLoadedService.WebAllContacts.ContactModelList.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemID);
    if (contactModelList == null || contactModelList == undefined || contactModelList.length == 0) {
      return <ContactModel>{};
    }
    return contactModelList[0];
  }

  GetSentence(ObservationInfo: string): string {
    let retStr = '';
    let strArr: string[] = ObservationInfo.split(',');
    if (strArr == undefined || strArr.length == 0) {
      return '';
    }
    for (let i = 0, count = strArr.length; i < count; i++) {
      if (strArr[i] != '') {
        let polSourceGroupingModelList: PolSourceGroupingModel[] = this.appLoadedService.WebAllPolSourceGroupings.PolSourceGroupingModelList.filter(c => c.PolSourceGrouping.CSSPID == parseInt(strArr[i]));
        if (polSourceGroupingModelList != null || polSourceGroupingModelList != undefined) {
          let reportPartText: string = polSourceGroupingModelList[0]?.PolSourceGroupingLanguageList[this.appLanguageService.LangID]?.Report;
          switch ((strArr[i]).substring(0, 3)) {
            case "101":
              {
                if (this.appLanguageService.LangID == 1) // français
                {
                  reportPartText = reportPartText.replace("Source", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Source</strong>");

                }
                else {
                  reportPartText = reportPartText.replace("Source", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Source</strong>");
                }
              }
              break;
            case "250":
              {
                if (this.appLanguageService.LangID == 1) // français
                {
                  reportPartText = reportPartText.replace("Pathway", "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Pathway</strong>");
                }
                else {
                  reportPartText = reportPartText.replace("Pathway", "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Pathway</strong>");
                }
              }
              break;
            case "900":
              {
                if (this.appLanguageService.LangID == 1) // français
                {
                  reportPartText = reportPartText.replace("Statut", "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Statut</strong>");
                }
                else {
                  reportPartText = reportPartText.replace("Status", "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Status</strong>");
                }
              }
              break;
            case "910":
              {
                if (this.appLanguageService.LangID == 1) // français
                {
                  reportPartText = reportPartText.replace("risque", "<strong>risque</strong>");
                }
                else {
                  reportPartText = reportPartText.replace("Risk", "<strong>Risk</strong>");
                }
              }
              break;
            case "110":
            case "120":
            case "122":
            case "151":
            case "152":
            case "153":
            case "155":
            case "156":
            case "157":
            case "163":
            case "166":
            case "167":
            case "170":
            case "171":
            case "172":
            case "173":
            case "176":
            case "178":
            case "181":
            case "182":
            case "183":
            case "185":
            case "186":
            case "187":
            case "190":
            case "191":
            case "192":
            case "193":
            case "194":
            case "196":
            case "198":
            case "199":
            case "220":
            case "930":
              {
                reportPartText = `<span class=""hidden"">${reportPartText}</span>`;
              }
              break;
            default:
              break;
          }
          retStr += reportPartText;
        }
        else {
          retStr += `[[${strArr[i]}]]`;
        }
      }
    }
    return retStr;
  }

}
