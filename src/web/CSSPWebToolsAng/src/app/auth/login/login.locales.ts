import { loadTranslations } from '@angular/localize';

export function LoadLocales() {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'login.Login': `Login (fr)`,
      'login.UserName': `User Name (fr)`,
      'login.UserNameIsRequired': `User name is required (fr)`,
      'login.Password': `Password (fr)`,
      'login.PasswordIsRequired': `Password is required (fr)`,
      'login.Register': `Register (fr)`,
    });
  }
  else { // en-CA
    loadTranslations({
      'login.Login': `Login`,
      'login.UserName': `User Name`,
      'login.UserNameIsRequired': `User name is required`,
      'login.Password': `Password`,
      'login.PasswordIsRequired': `Password is required`,
      'login.Register': `Register`,
    });
  }
}
