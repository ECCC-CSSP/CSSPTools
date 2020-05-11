import { DotNetService } from './dotnet.service';
import { DotNetModel } from './dotnet.models';

export function LoadLocalesDotNet(dotnetService: DotNetService) {
  let dotnetModel: DotNetModel = { 
    CompareEnumsAndOldEnums: 'Compare Enums And Old Enums', 
    EnumsGenerated_cs: 'EnumsGenerated.cs',
    EnumsTestGenerated_cs: 'EnumsTestGenerated.cs',
    GeneratePolSourceEnumCodeFiles: 'Generate Pollution Source Enum Code Files',
    // CurrentStatus: 'Current Status',
    // WorkingText: 'Working...',
}

  if ($localize.locale === 'fr-CA') {
      dotnetModel.CompareEnumsAndOldEnums = 'Compare Enums And Old Enums';
      dotnetModel.EnumsGenerated_cs = 'EnumsGenerated.cs';
      dotnetModel.EnumsTestGenerated_cs = 'EnumsTestGenerated.cs';
      dotnetModel.GeneratePolSourceEnumCodeFiles = 'Generate Pollution Source Enum Code Files';
      // generateEnumsModel.CurrentStatus = 'États actuel';
      // generateEnumsModel.WorkingText = 'Traitement en cour';
    }

  dotnetService.UpdateDotNet(dotnetModel);
}
