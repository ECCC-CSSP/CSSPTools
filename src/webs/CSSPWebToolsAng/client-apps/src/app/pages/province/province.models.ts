import { HttpRequestModel } from '../../models/HttpRequest.model';
import { WebProvince } from '../../models/generated/WebProvince.model';

export interface ProvinceTextModel {
    Title?: string;
}

export interface WebProvinceModel extends HttpRequestModel  {
    WebProvince?: WebProvince;
}

