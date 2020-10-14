import { HttpStatus } from '../../models/HttpStatus.model';
import { SearchResult } from '../../models/generated/SearchResult.model';

export interface SearchVar extends HttpStatus  {
    SearchTitle?: string
    searchResult?: SearchResult[];
}

