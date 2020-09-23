import { HttpRequestModel } from '../../models/HttpRequest.model';
import { WebCountry } from '../../models/generated/WebCountry.model';

export interface CountryTextModel {
    Title?: string;
}

export interface WebCountryModel extends HttpRequestModel  {
    WebCountry?: WebCountry;
}

