export interface RegisterModel {
    ID?: number;
    LoginEmail?: string;
    Password?: string;
    FirstName?: string;
    Initial?: string;
    LastName?: string;
    Token?: string;    
    Error?: string;
    Loading?: boolean;
    Submitted?: boolean;
    returnUrl?: string;
}