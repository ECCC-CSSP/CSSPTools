import { TVItemListDetailProvinceTextModel } from './tvitem-list-detail-province.models';
import { TVItemListDetailProvinceService } from './tvitem-list-detail-province.service';

export function LoadLocalesTVItemListDetailProvinceText(TVItemListDetailProvinceService: TVItemListDetailProvinceService) {
  let TVItemListDetailProvinceTextModel: TVItemListDetailProvinceTextModel = {
    Title: 'Yes The title',
  }

  if ($localize.locale === 'fr-CA') {
    TVItemListDetailProvinceTextModel.Title = 'Yes Le Titre';
  }

  TVItemListDetailProvinceService.UpdateTVItemListDetailProvinceText(TVItemListDetailProvinceTextModel);
}
