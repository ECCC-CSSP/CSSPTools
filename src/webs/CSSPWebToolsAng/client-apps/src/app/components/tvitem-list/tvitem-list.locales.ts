import { TVItemListTextModel } from './tvitem-list.models';
import { TVItemListService } from './tvitem-list.service';

export function LoadLocalesTVItemListText(TVItemListService: TVItemListService) {
  let TVItemListTextModel: TVItemListTextModel = {
    Title: 'Yes The title',
  }

  if ($localize.locale === 'fr-CA') {
    TVItemListTextModel.Title = 'Yes Le Titre';
  }

  TVItemListService.UpdateTVItemListText(TVItemListTextModel);
}
