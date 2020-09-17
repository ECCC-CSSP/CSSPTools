import { Contact } from '../../models/generated/Contact.model';
import { HttpRequestModel } from '../../models/http.model';
import { LanguageEnum } from '../grouping';

export interface ShellModel extends HttpRequestModel {
    AppTitle?: string;
    Language?: LanguageEnum;
    Contact?: Contact;
}
