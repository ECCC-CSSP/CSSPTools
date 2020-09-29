import { HttpRequestModel } from '../../models/HttpRequest.model';
import { WebCountry } from '../../models/generated/WebCountry.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';

export interface CountryTextModel {
    Title?: string;
}

export interface WebCountryModel extends HttpRequestModel  {
    WebCountry?: WebCountry;
}


export interface WebBaseProvinceModel  {
    WebBaseProvinceList?: WebBase[];
}
