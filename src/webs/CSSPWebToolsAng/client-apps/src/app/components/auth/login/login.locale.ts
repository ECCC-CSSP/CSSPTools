import { LoginService } from './login.service';
import { LoginModel } from './login.models';

export function LoadLocalesLogin(loginService: LoginService) {
  let loginModel: LoginModel = { 
    Locale_Login: 'Login',
    Locale_LoginEmail: 'Login Email',
    Locale_LoginEmailIsRequired: 'Login Email is required',
    Locale_Password: 'Password',
    Locale_PasswordIsRequired: 'Password is required',
    Locale_Register: 'Register',
  }

  if ($localize.locale === 'fr-CA') {
    loginModel.Locale_Login = 'S\'inscrire';
    loginModel.Locale_LoginEmail = 'Courriel d\'inscription';
    loginModel.Locale_LoginEmailIsRequired = 'Le courriel d\'inscription est requis';
    loginModel.Locale_Password = 'Mot de passe';
    loginModel.Locale_PasswordIsRequired = 'Mot de passe est requis';
    loginModel.Locale_Register = 'S\'enregistrer';
  }

  loginService.UpdateLogin(loginModel);
}
