import { TVItemLanguage } from 'src/app/models/generated/TVItemLanguage.model';
import { HttpRequestModel } from '../../models/http.model';

export interface SearchTextModel {
    Title?: string
}

export interface SearchModel extends HttpRequestModel  {
    TVItemLanguageList?: TVItemLanguage[];
}

