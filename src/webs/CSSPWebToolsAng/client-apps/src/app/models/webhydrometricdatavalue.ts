import { HydrometricDataValue } from './generated/HydrometricDataValue.model';
import { WebBase } from './webbase';

export class WebHydrometricDataValue {
    TVItemParentList: WebBase[] = [];
    HydrometricDataValueList: HydrometricDataValue[] = [];
}
