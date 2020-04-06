import { EnumsService } from './enums.service';
import { EnumsModel } from './enums.models';

export function LoadLocalesEnums(enumsService: EnumsService) {
  let enumsModel: EnumsModel = { 
    Title: 'somethng', 
    Generate: 'Generate',
    OpenCode: 'Open code',
    GetTheWeather: 'Get Weather',
    GetMoreWeather: 'Get More Weather',
    ClearWeather: 'Empty the data',
}

  if ($localize.locale === 'fr-CA') {
      enumsModel.Title = 'Quelque chose';
      enumsModel.Generate = 'Générer';
      enumsModel.OpenCode = 'Ouvrire le code';
      enumsModel.GetTheWeather = 'Aller chercher météo';
      enumsModel.GetMoreWeather = 'Aller chercher plus de météo';
      enumsModel.ClearWeather = 'Videz les données';
  }

  enumsService.UpdateEnums(enumsModel);
}
