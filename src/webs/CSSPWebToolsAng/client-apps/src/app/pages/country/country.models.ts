import { WebCountry } from '../../models/generated/WebCountry.model';
import { WebBase } from '../../models/generated/WebBase.model';
import { HttpStatus } from '../../models/HttpStatus.model';

export interface CountryVar extends HttpStatus  {
    CountryTitle?: string;
    WebCountry?: WebCountry;
    WebBaseProvinceList?: WebBase[];
}
