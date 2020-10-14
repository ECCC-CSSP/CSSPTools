import { ProvinceVar } from './province.models';
import { ProvinceService } from './province.service';

export function LoadLocalesProvinceVar(provinceService: ProvinceService) {
  let provinceVar: ProvinceVar = { 
    ProvinceTitle: 'The title',
}

  if ($localize.locale === 'fr-CA') {
      provinceVar.ProvinceTitle = 'Le Titre';
    }

  provinceService.UpdateProvinceVar(provinceVar);
}
