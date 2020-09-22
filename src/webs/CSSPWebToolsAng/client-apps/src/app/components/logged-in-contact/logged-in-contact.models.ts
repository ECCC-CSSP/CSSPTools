import { Contact } from 'src/app/models/generated/Contact.model';
import { HttpRequestModel } from '../../models/http.model';

export interface LoggedInContactTextModel {
    Title?: string
}

export interface LoggedInContactModel extends HttpRequestModel  {
    Contact?: Contact;
}

