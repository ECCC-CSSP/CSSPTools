import { HttpRequestModel } from 'src/app/models/http.model';

export interface LoginModel extends HttpRequestModel {
    Language?: string;
    ReturnUrl?: string;
    LoginEmail?: string;
    Password?: string;

    Locale_Login?: string;
    Locale_LoginEmail?: string;
    Locale_LoginEmailIsRequired?: string;
    Locale_Password?: string;
    Locale_PasswordIsRequired?: string;
    Locale_Register?: string;

}
