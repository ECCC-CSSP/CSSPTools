import { ServicesService } from './services.service';
import { ServicesModel } from './services.models';

export function LoadLocales(servicesService: ServicesService) {
  let servicesModel: ServicesModel = { 
    Title: 'somethng', 
  }

  if ($localize.locale === 'fr-CA') {
    servicesModel.Title = "something";
  }

  servicesService.Update(servicesModel);
}
