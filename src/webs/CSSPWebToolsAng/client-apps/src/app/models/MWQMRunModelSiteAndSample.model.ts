import { MWQMSample } from "./generated/db/MWQMSample.model";
import { MWQMRunModel } from "./generated/web/MWQMRunModel.model";
import { MWQMSiteModel } from "./generated/web/MWQMSiteModel.model";

export class MWQMRunModelSiteAndSample {
    MWQMRunModel?: MWQMRunModel;
    MWQMSiteModelAndSampleList?: MWQMSiteModelAndSample[];
}

export class MWQMSiteModelAndSample {
    MWQMSiteModel?: MWQMSiteModel;
    MWQMSample?: MWQMSample;
}
