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
    let PolSourceObsInfo = GetPolSourceObsInfoEnum();
    let EnumIDAndTextList: EnumIDAndText[] = PolSourceObsInfoEnum_GetOrderedText(this.appLanguageService);
    let strArr: string[] = ObservationInfo.split(',');
    for (let i = 0, count = strArr.length; i < count; i++) {
      if (strArr[i] != '') {
        retStr += EnumIDAndTextList.filter(c => c.EnumID == parseInt(strArr[i]))[0].EnumText;
      }
    }
    return retStr;
  }

}
