import { TVItemLanguage } from 'src/app/models/generated/TVItemLanguage.model';
import { SearchResult } from 'src/app/models/SearchResult.model';
import { HttpRequestModel } from '../../models/HttpRequest.model';

export interface SearchTextModel {
    Title?: string
}

export interface SearchResultModel extends HttpRequestModel  {
    searchResult?: SearchResult[];
}

