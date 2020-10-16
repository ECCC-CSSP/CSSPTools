import { AppService } from 'src/app/app.service';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { ProvinceVar } from './province.models';
import { ProvinceService } from './province.service';

export function LoadLocalesProvinceVar(appService: AppService, provinceService: ProvinceService) {
  let provinceVar: ProvinceVar = { 
    ProvinceTitle: 'The title',
}

  if (appService.AppVar$.getValue().Language == LanguageEnum.fr) {
      provinceVar.ProvinceTitle = 'Le Titre';
    }

  provinceService.UpdateProvinceVar(provinceVar);
}
