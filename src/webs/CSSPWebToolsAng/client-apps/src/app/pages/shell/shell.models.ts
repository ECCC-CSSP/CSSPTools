import { Contact } from '../../models/generated/Contact.model';
import { HttpRequestModel } from '../../models/HttpRequest.model';
import { LanguageEnum } from '../grouping';

export interface ShellModel extends HttpRequestModel {
    AppTitle?: string;
    Language?: LanguageEnum;
    BaseApiUrl?: string;
    Contact?: Contact;

    ActiveVisible?: boolean;
    DetailVisible?: boolean;
    EditVisible?: boolean;
    FileVisible?: boolean;
    InactVisible?: boolean;
    MapVisible?: boolean;
    MenuVisible?: boolean;
}
