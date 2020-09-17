import { SamplingPlan } from './generated/SamplingPlan.model';
import { SamplingPlanSubsector } from './generated/SamplingPlanSubsector.model';
import { SamplingPlanSubsectorSite } from './generated/SamplingPlanSubsectorSite.model';
import { WebBase } from './webbase';

export class WebSamplingPlan {
    TVItemParentList: WebBase[] = [];
    SamplingPlanModelList: SamplingPlanModel[] = [];
}

export class SamplingPlanModel {
    SamplingPlan: SamplingPlan = new SamplingPlan();
    SamplingPlanSubsectorModelList: SamplingPlanSubsectorModel[] = [];
}

export class SamplingPlanSubsectorModel {
    SamplingPlanSubsector: SamplingPlanSubsector = new SamplingPlanSubsector();
    SamplingPlanSubsectorSiteList: SamplingPlanSubsectorSite[] = [];
}