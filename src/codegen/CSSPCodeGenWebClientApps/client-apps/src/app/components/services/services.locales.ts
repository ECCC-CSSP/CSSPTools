import { ServicesService } from './services.service';
import { ServicesModel } from './services.models';

export function LoadLocalesServices(servicesService: ServicesService) {
  let servicesModel: ServicesModel = { 
    Title: 'somethng', 
  }

  if ($localize.locale === 'fr-CA') {
    servicesModel.Title = "something";
  }

  servicesService.UpdateServices(servicesModel);
}
