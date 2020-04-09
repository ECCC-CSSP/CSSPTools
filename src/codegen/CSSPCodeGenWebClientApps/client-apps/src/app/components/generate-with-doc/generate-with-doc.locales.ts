import { GenerateWithDocService } from './generate-with-doc.service';
import { GenerateWithDocModel } from './generate-with-doc.models';

export function LoadLocalesWithDoc(generateWithDocService: GenerateWithDocService) {
  let generateWithDocModel: GenerateWithDocModel = { 
    Title: 'somethng', 
    Generate: 'Generate',
    OpenCode: 'Open code',
    GetTheWeather: 'Get Weather',
    GetMoreWeather: 'Get More Weather',
    ClearWeather: 'Empty the data',
}

  if ($localize.locale === 'fr-CA') {
      generateWithDocModel.Title = 'Quelque chose';
      generateWithDocModel.Generate = 'Générer';
      generateWithDocModel.OpenCode = 'Ouvrire le code';
      generateWithDocModel.GetTheWeather = 'Aller chercher météo';
      generateWithDocModel.GetMoreWeather = 'Aller chercher plus de météo';
      generateWithDocModel.ClearWeather = 'Videz les données';
  }

  generateWithDocService.UpdateWithDoc(generateWithDocModel);
}
