import { GenerateEnumsService } from './generate-enums.service';
import { GenerateEnumsModel } from './generate-enums.models';

export function LoadLocalesEnums(generateEnumsService: GenerateEnumsService) {
  let generateEnumsModel: GenerateEnumsModel = { 
    CompareEnumsAndOldEnums: 'Compare Enums And Old Enums', 
    EnumsGenerated_cs: 'EnumsGenerated.cs',
    EnumsTestGenerated_cs: 'EnumsTestGenerated.cs',
    GeneratePolSourceEnumCodeFiles: 'Generate Pollution Source Enum Code Files',
    CurrentStatus: 'Current Status',
    WorkingText: 'Working...',
}

  if ($localize.locale === 'fr-CA') {
      generateEnumsModel.CompareEnumsAndOldEnums = 'Compare Enums And Old Enums';
      generateEnumsModel.EnumsGenerated_cs = 'EnumsGenerated.cs';
      generateEnumsModel.EnumsTestGenerated_cs = 'EnumsTestGenerated.cs';
      generateEnumsModel.GeneratePolSourceEnumCodeFiles = 'Generate Pollution Source Enum Code Files';
      generateEnumsModel.CurrentStatus = 'États actuel';
      generateEnumsModel.WorkingText = 'Traitement en cour';
    }

  generateEnumsService.UpdateEnums(generateEnumsModel);
}
