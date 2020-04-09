import { GenerateAngularService } from './generate-angular.service';
import { GenerateAngularModel } from './generate-angular.models';

export function LoadLocalesAngular(generateAngularService: GenerateAngularService) {
  let generateAngularModel: GenerateAngularModel = { 
    Title: 'somethng', 
    Generate: 'Generate',
    OpenCode: 'Open code',
    GetTheWeather: 'Get Weather',
    GetMoreWeather: 'Get More Weather',
    ClearWeather: 'Empty the data',
}

  if ($localize.locale === 'fr-CA') {
      generateAngularModel.Title = 'Quelque chose';
      generateAngularModel.Generate = 'Générer';
      generateAngularModel.OpenCode = 'Ouvrire le code';
      generateAngularModel.GetTheWeather = 'Aller chercher météo';
      generateAngularModel.GetMoreWeather = 'Aller chercher plus de météo';
      generateAngularModel.ClearWeather = 'Videz les données';
  }

  generateAngularService.UpdateAngular(generateAngularModel);
}
