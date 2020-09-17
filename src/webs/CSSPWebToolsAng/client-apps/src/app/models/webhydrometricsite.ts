import { HydrometricSite } from './generated/HydrometricSite.model';
import { RatingCurve } from './generated/RatingCurve.model';
import { RatingCurveValue } from './generated/RatingCurveValue.model';
import { WebBase } from './webbase';

export class WebHydrometricSite {
    TVItemParentList: WebBase[] = [];
    HydrometricSiteList: HydrometricSite[] = [];
    TVItemHydrometricSiteList: WebBase[] = [];
    RatingCurveList: RatingCurve[] = [];
    RatingCurveValueList: RatingCurveValue[] = [];
}
