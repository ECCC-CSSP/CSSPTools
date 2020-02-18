import { loadTranslations } from '@angular/localize';

export function LoadLocales() {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'register.Register': `Register (fr)`,
      'register.FirstName': `First name (fr)`,
      'register.FirstNameIsRequired': `First name is required (fr)`,
      'register.LastName': `Last name (fr)`,
      'register.LastNameIsRequired': `Last name is required (fr)`,
      'register.UserName': `User name (fr)`,
      'register.UserNameIsRequired': `User name is required (fr)`,
      'register.Password': `Password (fr)`,
      'register.PasswordIsRequired': `Password is required (fr)`,  
      'register.PasswordMustBeAtLeast6Characters': `Password must be at least 6 characters  (fr)`,     
      'register.Cancel': `Cancel (fr)`,
    });
  }
  else {
    loadTranslations({
      'register.Register': `Register`,
      'register.FirstName': `First name`,
      'register.FirstNameIsRequired': `First name is required`,
      'register.LastName': `Last name`,
      'register.LastNameIsRequired': `Last name is required`,
      'register.UserName': `User name`,
      'register.UserNameIsRequired': `User name is required`,
      'register.Password': `Password`,
      'register.PasswordIsRequired': `Password is required`,     
      'register.PasswordMustBeAtLeast6Characters': `Password must be at least 6 characters`,     
      'register.Cancel': `Cancel`,
    });
  }
}
