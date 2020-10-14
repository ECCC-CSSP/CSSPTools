import { SearchVar } from './search.models';
import { SearchService } from './search.service';

export function LoadLocalesSearchVar(searchService: SearchService) {
  let searchVar: SearchVar = { 
    SearchTitle: 'Yes The title',
}

  if ($localize.locale === 'fr-CA') {
      searchVar.SearchTitle = 'Yes Le Titre';
    }

  searchService.UpdateSearchVar(searchVar);
}
