import { GenerateServicesService } from './generate-services.service';
import { GenerateServicesModel } from './generate-services.models';

export function LoadLocalesServices(generateServicesService: GenerateServicesService) {
  let generateServicesModel: GenerateServicesModel = { 
    Title: 'somethng', 
  }

  if ($localize.locale === 'fr-CA') {
    generateServicesModel.Title = "something";
  }

  generateServicesService.UpdateServices(generateServicesModel);
}
