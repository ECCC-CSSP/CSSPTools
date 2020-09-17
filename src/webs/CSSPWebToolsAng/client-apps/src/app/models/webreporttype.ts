import { ReportSection } from './generated/ReportSection.model';
import { ReportType } from './generated/ReportType.model';

export class WebReportTypeModel {
    ReportTypeModelList: ReportTypeModel[] = [];
}

export class ReportTypeModel {
    ReportType: ReportType = new ReportType();
    ReportSectionList: ReportSection[] = [];
}