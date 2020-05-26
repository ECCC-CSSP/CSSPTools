import { HttpRequestModel } from 'src/app/models/http.model';

export interface RegisterModel extends HttpRequestModel {
    Language?: string;
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
