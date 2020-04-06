export interface LoginModel {
    Language?: string;
    Error?: string;
    Loading?: boolean;
    Submitted?: boolean;
    ReturnUrl?: string;
    //
    Login?: string;
    LoginEmail?: string;
    LoginEmailIsRequired?: string;
    Password?: string;
    PasswordIsRequired?: string;
    Register?: string;
}

export interface UserModel {
    ContactID?: number,
    Id?: string,
    ContactTVItemID?: number,
    LoginEmail?: string,
    FirstName?: string,
    LastName?: string,
    Initial?: string,
    Password?: string,
    Token?: string,
}