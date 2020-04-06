export interface RegisterModel {
    Language?: string;
    Error?: string;
    Loading?: boolean;
    Submitted?: boolean;
    returnUrl?: string;
    //
    Register?: string;
    FirstName?: string;
    FirstNameIsRequired?: string;
    Initial?: string;
    InitialIsRequired?: string;
    LastName?: string;
    LastNameIsRequired?: string;
    LoginEmail?: string;
    LoginEmailIsRequired?: string;   
    Password?: string;
    PasswordIsRequired?: string;
    PasswordMustBeAtLeast6Characters?: string;
    ConfirmPassword?: string;
    ConfirmPasswordIsRequired?: string;
}
