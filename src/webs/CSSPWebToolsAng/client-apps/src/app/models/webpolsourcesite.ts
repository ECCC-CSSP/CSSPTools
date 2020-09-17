import { Address } from './generated/Address.model';
import { PolSourceObservation } from './generated/PolSourceObservation.model';
import { PolSourceObservationIssue } from './generated/PolSourceObservationIssue.model';
import { PolSourceSite } from './generated/PolSourceSite.model';
import { PolSourceSiteEffect } from './generated/PolSourceSiteEffect.model';
import { WebBase } from './webbase';

export class WebPolSourceSite {
    TVItemParentList: WebBase[] = [];
    PolSourceSiteModelList: PolSourceSiteModel[] = [];
}

export class PolSourceSiteModel extends WebBase {
    PolSourceSite: PolSourceSite = new PolSourceSite();
    PolSourceSiteCivicAddress: Address = new Address();
    PolSourceObservationModelList: PolSourceObservationModel[] = [];
    PolSourceSiteEffectList: PolSourceSiteEffect[] = [];
}

export class PolSourceObservationModel {
    PolSourceObservation: PolSourceObservation = new PolSourceObservation();
    PolSourceObservationIssueList: PolSourceObservationIssue[] = [];    
}

