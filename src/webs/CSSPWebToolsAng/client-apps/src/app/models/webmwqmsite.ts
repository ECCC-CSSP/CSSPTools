import { MWQMSite } from './generated/MWQMSite.model';
import { MWQMSiteStartEndDate } from './generated/MWQMSiteStartEndDate.model';
import { WebBase } from './webbase';

export class WebMWQMSite {
    TVItemParentList: WebBase[] = [];
    MWQMSiteModelList: MWQMSiteModel[] = [];
}

export class MWQMSiteModel extends WebBase {
    MWQMSite: MWQMSite = new MWQMSite();
    MWQMSiteStartEndDateList: MWQMSiteStartEndDate[] = [];
}

