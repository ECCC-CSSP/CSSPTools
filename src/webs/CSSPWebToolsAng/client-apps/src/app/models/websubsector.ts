import { LabSheet } from './generated/LabSheet.model';
import { LabSheetDetail } from './generated/LabSheetDetail.model';
import { LabSheetTubeMPNDetail } from './generated/LabSheetTubeMPNDetail.model';
import { MWQMAnalysisReportParameter } from './generated/MWQMAnalysisReportParameter.model';
import { MWQMSubsector } from './generated/MWQMSubsector.model';
import { MWQMSubsectorLanguage } from './generated/MWQMSubsectorLanguage.model';
import { UseOfSite } from './generated/UseOfSite.model';
import { WebBase } from './webbase';

export class WebSubsector extends WebBase {
    TVItemParentList: WebBase[] = [];
    TVItemMWQMSiteList: WebBase[] = [];
    TVItemMWQMRunList: WebBase[] = [];
    TVItemPolSourceSiteList: WebBase[] = [];
    MWQMAnalysisReportParameterList: MWQMAnalysisReportParameter[] = [];
    LabSheetModelList: LabSheetModel[] = [];
    MWQMSubsector: MWQMSubsector = new MWQMSubsector();
    MWQMSubsectorLanguageList: MWQMSubsectorLanguage[] = [];
    UseOfSiteList: UseOfSite[] = [];    
}

export class LabSheetModel {
    LabSheet: LabSheet = new LabSheet();
    LabSheetDetailModelList: LabSheetDetailModel[] = [];
}

export class LabSheetDetailModel
{
    LabSheetDetail: LabSheetDetail = new LabSheetDetail();
    LabSheetTubeMPNDetailList: LabSheetTubeMPNDetail[] = [];
}