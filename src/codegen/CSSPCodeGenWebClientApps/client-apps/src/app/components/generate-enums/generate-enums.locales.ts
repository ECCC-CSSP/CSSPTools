import { GenerateEnumsService } from './generate-enums.service';
import { GenerateEnumsModel } from './generate-enums.models';

export function LoadLocalesEnums(generateEnumsService: GenerateEnumsService) {
  let generateEnumsModel: GenerateEnumsModel = { 
    CompareEnumsAndOldEnums: 'Compare Enums And Old Enums', 
    EnumsGenerated_cs: 'EnumsGenerated.cs',
    EnumsTestGenerated_cs: 'EnumsTestGenerated.cs',
    GeneratePolSourceEnumCodeFiles: 'Generate Pollution Source Enum Code Files',
    StatusTitle: 'Current Status of execution',
    WorkingText: 'Working...',
}

  if ($localize.locale === 'fr-CA') {
      generateEnumsModel.CompareEnumsAndOldEnums = 'Compare Enums And Old Enums';
      generateEnumsModel.EnumsGenerated_cs = 'EnumsGenerated.cs';
      generateEnumsModel.EnumsTestGenerated_cs = 'EnumsTestGenerated.cs';
      generateEnumsModel.GeneratePolSourceEnumCodeFiles = 'Generate Pollution Source Enum Code Files';
      generateEnumsModel.StatusTitle = 'Status actuel de l\'exécution';
      generateEnumsModel.WorkingText = 'Traitement en cour';
    }

  generateEnumsService.UpdateEnums(generateEnumsModel);
}
