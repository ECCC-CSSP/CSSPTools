import { RegisterService } from './register.service';
import { RegisterModel } from './register.models';

export function LoadLocalesRegister(registerService: RegisterService) {
  let registerModel: RegisterModel = {
    Register: 'Register',
    FirstName: 'First name',
    FirstNameIsRequired: 'First name is required',
    Initial: 'Initial',
    InitialIsRequired: 'Initial is required',
    LastName: 'Last name',
    LastNameIsRequired: 'Last name is required',
    LoginEmail: 'Login email',
    LoginEmailIsRequired: 'Login email is required',
    Password: 'Password',
    PasswordIsRequired: 'Password is required',
    PasswordMustBeAtLeast6Characters: "Password must be at least 6 characters",
    ConfirmPassword: 'Confirm password',
    ConfirmPasswordIsRequired: 'Confirm password is required',
  }

  if ($localize.locale === 'fr-CA') {
    registerModel.Register = 'S\'enregistrer';
    registerModel.FirstName = 'Prénom';
    registerModel.FirstNameIsRequired = 'Prénom est requis';
    registerModel.Initial = 'Initiale';
    registerModel.InitialIsRequired = 'Initiale est requis';
    registerModel.LastName = 'Nom de famille';
    registerModel.LastNameIsRequired = 'Nom de famille est requis';
    registerModel.LoginEmail = 'Courriel d\'inscription';
    registerModel.LoginEmailIsRequired = 'Courriel d\'inscription est requis';
    registerModel.Password = 'Mot de passe';
    registerModel.PasswordIsRequired = 'Mot de passe est requis';
    registerModel.ConfirmPassword = 'Confirmation de mot de passe';
    registerModel.ConfirmPasswordIsRequired = 'Confirmation de mot de passe est requis';
  }

  registerService.UpdateRegister(registerModel);
}
