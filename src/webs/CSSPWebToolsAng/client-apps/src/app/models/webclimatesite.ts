import { ClimateDataValue } from './generated/ClimateDataValue.model';
import { ClimateSite } from './generated/ClimateSite.model';
import { WebBase } from './webbase';

export class WebClimateSite {
    TVItemParentList: WebBase[] = [];
    ClimateSiteList: ClimateSite[] = [];
    TVItemClimateSiteList: WebBase[] = [];
}
