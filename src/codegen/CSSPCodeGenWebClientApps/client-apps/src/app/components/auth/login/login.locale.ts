import { LoginService } from './login.service';
import { LoginModel } from './login.models';

export function LoadLocales(loginService: LoginService) {
  let loginModel: LoginModel = { 
    //Title: 'somethng', 
  }

  if ($localize.locale === 'fr-CA') {
    //loginModel.Title = "something";
  }

  loginService.Update(loginModel);
}
