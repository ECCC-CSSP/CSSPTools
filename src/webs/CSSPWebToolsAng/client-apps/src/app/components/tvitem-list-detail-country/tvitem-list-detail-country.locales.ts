import { TVItemListDetailCountryTextModel } from './tvitem-list-detail-country.models';
import { TVItemListDetailCountryService } from './tvitem-list-detail-country.service';

export function LoadLocalesTVItemListDetailCountryText(TVItemListDetailCountryService: TVItemListDetailCountryService) {
  let TVItemListDetailCountryTextModel: TVItemListDetailCountryTextModel = {
    Title: 'Yes The title',
  }

  if ($localize.locale === 'fr-CA') {
    TVItemListDetailCountryTextModel.Title = 'Yes Le Titre';
  }

  TVItemListDetailCountryService.UpdateTVItemListDetailCountryText(TVItemListDetailCountryTextModel);
}
