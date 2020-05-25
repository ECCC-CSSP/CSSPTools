import { HttpRequestModel } from './http.model';

export interface UserModel extends HttpRequestModel {
    ContactID?: number,
    Id?: string,
    ContactTVItemID?: number,
    LoginEmail?: string,
    FirstName?: string,
    LastName?: string,
    Initial?: string,
    Password?: string,
    Token?: string
}