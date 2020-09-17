import { EmailDistributionList } from './generated/EmailDistributionList.model';
import { EmailDistributionListContact } from './generated/EmailDistributionListContact.model';
import { EmailDistributionListContactLanguage } from './generated/EmailDistributionListContactLanguage.model';
import { EmailDistributionListLanguage } from './generated/EmailDistributionListLanguage.model';
import { WebBase } from './webbase';

export class WebCountry extends WebBase {
    TVItemParentList: WebBase[] = [];
    TVItemProvinceList: WebBase[] = [];
    EmailDistributionListList: EmailDistributionList[] = [];
    EmailDistributionListLanguageList: EmailDistributionListLanguage[] = [];
    EmailDistributionListContactList: EmailDistributionListContact[] = [];
    EmailDistributionListContactLanguageList: EmailDistributionListContactLanguage[] = [];
}
