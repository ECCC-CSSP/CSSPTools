import { TVItem } from './generated/TVItem.model';
import { TVItemLanguage } from './generated/TVItemLanguage.model';

export class SearchResult {
    TVItem: TVItem = new TVItem();
    TVItemLanguage: TVItemLanguage = new TVItemLanguage();
}
