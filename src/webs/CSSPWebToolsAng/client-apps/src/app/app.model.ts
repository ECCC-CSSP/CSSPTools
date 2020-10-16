import { CountryComponent } from './components/country/country.component';
import { CountrySubComponentEnum } from './enums/CountrySubComponentEnum';
import { LanguageEnum } from './enums/generated/LanguageEnum';
import { TVTypeEnum } from './enums/generated/TVTypeEnum';
import { MapSizeEnum } from './enums/MapSizeEnum';
import { ProvinceSubComponentEnum } from './enums/ProvinceSubComponentEnum';
import { RootSubComponentEnum } from './enums/RootSubComponentEnum';
import { ShellSubComponentEnum } from './enums/ShellSubComponentEnum';
import { TopComponentEnum } from './enums/TopComponentEnum';
import { Contact } from './models/generated/Contact.model';
import { WebBase } from './models/generated/WebBase.model';
import { WebContact } from './models/generated/WebContact.model';
import { HttpStatus } from './models/HttpStatus.model';

export interface AppVar extends HttpStatus {
    TopComponent?: TopComponentEnum;
    ShellSubComponent?: ShellSubComponentEnum;
    RootSubComponent?: RootSubComponentEnum;
    CountrySubComponent?: CountrySubComponentEnum;
    ProvinceSubComponent?: ProvinceSubComponentEnum;
    CurrentTVItemID?: number;
    Language?: LanguageEnum;
    BaseApiUrl?: string;
    LoggedInContact?: Contact;

    DetailVisible?: boolean;
    EditVisible?: boolean;
    InactVisible?: boolean;
    MapVisible?: boolean;
    MenuVisible?: boolean;

    MapSize?: MapSizeEnum;

    BreadCrumbWebBaseList?: WebBase[];
    WebContact?: WebContact;
    AdminContactList?: Contact[];
}
