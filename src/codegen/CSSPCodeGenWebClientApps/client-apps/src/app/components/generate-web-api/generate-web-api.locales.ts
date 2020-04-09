import { GenerateWebAPIService } from './generate-web-api.service';
import { GenerateWebAPIModel } from './generate-web-api.models';

export function LoadLocalesWebAPI(generateWebAPIService: GenerateWebAPIService) {
  let generateWebAPIModel: GenerateWebAPIModel = { 
    Title: 'somethng', 
    Generate: 'Generate',
    OpenCode: 'Open code',
    GetTheWeather: 'Get Weather',
    GetMoreWeather: 'Get More Weather',
    ClearWeather: 'Empty the data',
}

  if ($localize.locale === 'fr-CA') {
      generateWebAPIModel.Title = 'Quelque chose';
      generateWebAPIModel.Generate = 'Générer';
      generateWebAPIModel.OpenCode = 'Ouvrire le code';
      generateWebAPIModel.GetTheWeather = 'Aller chercher météo';
      generateWebAPIModel.GetMoreWeather = 'Aller chercher plus de météo';
      generateWebAPIModel.ClearWeather = 'Videz les données';
  }

  generateWebAPIService.UpdateWebAPI(generateWebAPIModel);
}
