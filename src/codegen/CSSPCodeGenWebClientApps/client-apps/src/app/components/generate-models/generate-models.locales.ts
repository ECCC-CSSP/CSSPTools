import { GenerateModelsService } from './generate-models.service';
import { GenerateModelsModel } from './generate-models.models';

export function LoadLocalesModels(generateModelsService: GenerateModelsService) {
  let generateModelsModel: GenerateModelsModel = { 
    Models_ModelClassName_Test: 'Models_ModelClassName_Test', 
    ModelsGenerated_cs: 'ModelsGenerated.cs',
    ModelsTestGenerated_cs: 'ModelsTestGenerated.cs',
    GeneratePolSourceEnumCodeFiles: 'Generate Pollution Source Enum Code Files',
    CurrentStatus: 'Current Status',
    WorkingText: 'Working...',
}

  if ($localize.locale === 'fr-CA') {
      generateModelsModel.Models_ModelClassName_Test = 'Models_ModelClassName_Test (fr)';
      generateModelsModel.ModelsGenerated_cs = 'ModelsGenerated.cs';
      generateModelsModel.ModelsTestGenerated_cs = 'ModelsTestGenerated.cs';
      generateModelsModel.GeneratePolSourceEnumCodeFiles = 'Generate Pollution Source Enum Code Files';
      generateModelsModel.CurrentStatus = 'États actuel';
      generateModelsModel.WorkingText = 'Traitement en cour';
    }

  generateModelsService.UpdateModels(generateModelsModel);
}
