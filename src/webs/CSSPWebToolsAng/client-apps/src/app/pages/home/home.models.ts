import { HttpRequestModel } from '../../models/HttpRequest.model';
import { Contact } from '../../models/generated/Contact.model';

export interface HomeTextModel {
    Title?: string;
}

export interface AdminContactModel extends HttpRequestModel {
    AdminList: Contact[];
}
