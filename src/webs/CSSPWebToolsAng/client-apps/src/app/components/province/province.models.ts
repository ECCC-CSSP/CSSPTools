import { WebProvince } from '../../models/generated/WebProvince.model';
import { WebBase } from '../../models/generated/WebBase.model';
import { HttpStatus } from '../../models/HttpStatus.model';

export interface ProvinceVar extends HttpStatus   {
    ProvinceTitle?: string;
    WebProvince?: WebProvince;
    WebBaseAreaList?: WebBase[];
}
