import { MWQMRunModel } from "./generated/web/MWQMRunModel.model";
import { MWQMSampleModel } from "./generated/web/MWQMSampleModel.model";
import { MWQMSiteModel } from "./generated/web/MWQMSiteModel.model";

export class MWQMRunModelSiteAndSampleModel {
    MWQMRunModel?: MWQMRunModel;
    MWQMSiteModelAndSampleModelList?: MWQMSiteModelAndSampleModel[];
}

export class MWQMSiteModelAndSampleModel {
    MWQMSiteModel?: MWQMSiteModel;
    MWQMSampleModel?: MWQMSampleModel;
}
