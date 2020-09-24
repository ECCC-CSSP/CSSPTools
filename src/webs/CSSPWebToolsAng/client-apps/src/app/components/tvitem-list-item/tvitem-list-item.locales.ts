import { TVItemListItemTextModel } from './tvitem-list-item.models';
import { TVItemListItemService } from './tvitem-list-item.service';

export function LoadLocalesTVItemListItemText(TVItemListItemService: TVItemListItemService) {
  let TVItemListItemTextModel: TVItemListItemTextModel = {
    Title: 'Yes The title',
  }

  if ($localize.locale === 'fr-CA') {
    TVItemListItemTextModel.Title = 'Yes Le Titre';
  }

  TVItemListItemService.UpdateTVItemListItemText(TVItemListItemTextModel);
}
