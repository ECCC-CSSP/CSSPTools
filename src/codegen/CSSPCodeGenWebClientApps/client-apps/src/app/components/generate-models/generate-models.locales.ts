import { GenerateModelsService } from './generate-models.service';
import { GenerateModelsModel } from './generate-models.models';

export function LoadLocalesModels(generateModelsService: GenerateModelsService) {
  let generateModelsModel: GenerateModelsModel = { 
    Title: 'somethng', 
  }

  if ($localize.locale === 'fr-CA') {
    generateModelsModel.Title = "something";
  }

  generateModelsService.UpdateModels(generateModelsModel);
}
