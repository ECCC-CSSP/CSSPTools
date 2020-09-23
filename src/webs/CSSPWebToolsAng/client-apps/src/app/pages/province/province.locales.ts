import { ProvinceTextModel } from './province.models';
import { ProvinceService } from './province.service';

export function LoadLocalesProvinceText(provinceService: ProvinceService) {
  let ProvinceTextModel: ProvinceTextModel = { 
    Title: 'The title',
}

  if ($localize.locale === 'fr-CA') {
      ProvinceTextModel.Title = 'Le Titre';
    }

  provinceService.UpdateProvinceText(ProvinceTextModel);
}
