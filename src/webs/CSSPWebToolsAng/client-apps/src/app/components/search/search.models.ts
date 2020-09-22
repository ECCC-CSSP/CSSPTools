import { TVItemLanguage } from 'src/app/models/generated/TVItemLanguage.model';
import { SearchResult } from 'src/app/models/searchresult';
import { HttpRequestModel } from '../../models/http.model';

export interface SearchTextModel {
    Title?: string
}

export interface SearchResultModel extends HttpRequestModel  {
    searchResult?: SearchResult[];
}

