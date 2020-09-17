import { SamplingPlan } from './generated/SamplingPlan.model';
import { WebBase } from './webbase';

export class WebCountry extends WebBase {
    TVItemParentList: WebBase[] = [];
    TVItemAreaList: WebBase[] = [];
    SamplingPlanList: SamplingPlan[] = [];
}
