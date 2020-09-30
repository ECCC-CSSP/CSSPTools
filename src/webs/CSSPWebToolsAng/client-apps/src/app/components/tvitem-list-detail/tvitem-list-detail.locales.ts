import { TVItemListDetailTextModel } from './tvitem-list-detail.models';
import { TVItemListDetailService } from './tvitem-list-detail.service';

export function LoadLocalesTVItemListDetailText(TVItemListDetailService: TVItemListDetailService) {
  let TVItemListDetailTextModel: TVItemListDetailTextModel = {
    Title: 'Yes The title',
  }

  if ($localize.locale === 'fr-CA') {
    TVItemListDetailTextModel.Title = 'Yes Le Titre';
  }

  TVItemListDetailService.UpdateTVItemListDetailText(TVItemListDetailTextModel);
}
