import { HttpRequestModel } from '../../models/HttpRequest.model';
import { WebProvince } from '../../models/generated/WebProvince.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';

export interface ProvinceTextModel {
    Title?: string;
}

export interface WebProvinceModel extends HttpRequestModel  {
    WebProvince?: WebProvince;
}

export interface WebBaseAreaModel  {
    WebBaseAreaList?: WebBase[];
}
