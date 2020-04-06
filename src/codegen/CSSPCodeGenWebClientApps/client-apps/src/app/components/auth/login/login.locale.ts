import { LoginService } from './login.service';
import { LoginModel } from './login.models';

export function LoadLocalesLogin(loginService: LoginService) {
  let loginModel: LoginModel = { 
    Login: 'Login',
    LoginEmail: 'Login Email',
    LoginEmailIsRequired: 'Login Email is required',
    Password: 'Password',
    PasswordIsRequired: 'Password is required',
    Register: 'Register',
  }

  if ($localize.locale === 'fr-CA') {
    loginModel.Login = 'S\'inscrire';
    loginModel.LoginEmail = 'Courriel d\'inscription';
    loginModel.LoginEmailIsRequired = 'Le courriel d\'inscription est requis';
    loginModel.Password = 'Mot de passe';
    loginModel.PasswordIsRequired = 'Mot de passe est requis';
    loginModel.Register = 'S\'enregistrer';
  }

  loginService.UpdateLogin(loginModel);
}
