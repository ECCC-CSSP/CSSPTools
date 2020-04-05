import { RegisterService } from './register.service';
import { RegisterModel } from './register.models';

export function LoadLocales(registerService: RegisterService) {
  let registerModel: RegisterModel = { 
    //Title: 'somethng', 
  }

  if ($localize.locale === 'fr-CA') {
    //registerModel.Title = "something";
  }

  registerService.Update(registerModel);
}
