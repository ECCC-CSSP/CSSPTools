import { GenerateEnumsService } from './generate-enums.service';
import { GenerateEnumsModel } from './generate-enums.models';

export function LoadLocalesEnums(generateEnumsService: GenerateEnumsService) {
  let generateEnumsModel: GenerateEnumsModel = { 
    Title: 'somethng', 
    Generate: 'Generate',
    OpenCode: 'Open code',
    GetTheWeather: 'Get Weather',
    GetMoreWeather: 'Get More Weather',
    ClearWeather: 'Empty the data',
}

  if ($localize.locale === 'fr-CA') {
      generateEnumsModel.Title = 'Quelque chose';
      generateEnumsModel.Generate = 'Générer';
      generateEnumsModel.OpenCode = 'Ouvrire le code';
      generateEnumsModel.GetTheWeather = 'Aller chercher météo';
      generateEnumsModel.GetMoreWeather = 'Aller chercher plus de météo';
      generateEnumsModel.ClearWeather = 'Videz les données';
  }

  generateEnumsService.UpdateEnums(generateEnumsModel);
}
