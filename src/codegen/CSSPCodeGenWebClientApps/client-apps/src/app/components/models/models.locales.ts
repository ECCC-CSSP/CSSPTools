import { ModelsService } from './models.service';
import { ModelsModel } from './models.models';

export function LoadLocalesModels(modelsService: ModelsService) {
  let modelsModel: ModelsModel = { 
    Title: 'somethng', 
  }

  if ($localize.locale === 'fr-CA') {
    modelsModel.Title = "something";
  }

  modelsService.UpdateModels(modelsModel);
}
