import { HttpErrorResponse } from '@angular/common/http';

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
    Error?: string;
    Loading?: boolean;
    Submitted?: boolean;
}