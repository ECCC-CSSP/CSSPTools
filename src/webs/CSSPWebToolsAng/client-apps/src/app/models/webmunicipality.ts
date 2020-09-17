import { Address } from './generated/Address.model';
import { BoxModel } from './generated/BoxModel.model';
import { BoxModelLanguage } from './generated/BoxModelLanguage.model';
import { BoxModelResult } from './generated/BoxModelResult.model';
import { Contact } from './generated/Contact.model';
import { Email } from './generated/Email.model';
import { Infrastructure } from './generated/Infrastructure.model';
import { InfrastructureLanguage } from './generated/InfrastructureLanguage.model';
import { Tel } from './generated/Tel.model';
import { TVItemLink } from './generated/TVItemLink.model';
import { VPAmbient } from './generated/VPAmbient.model';
import { VPResult } from './generated/VPResult.model';
import { VPScenario } from './generated/VPScenario.model';
import { VPScenarioLanguage } from './generated/VPScenarioLanguage.model';
import { WebBase } from './webbase';

export class WebMunicipality extends WebBase {
    TVItemParentList: WebBase[] = [];
    TVItemMikeScenarioList: WebBase[] = [];
    InfrastructureModelList: InfrastructureModel[] = [];
    MunicipalityContactModelList: ContactModel[] = [];
    MunicipalityTVItemLinkList: TVItemLink[] = [];
}

export class InfrastructureModel extends WebBase {
    Infrastructure: Infrastructure = new Infrastructure();
    InfrastructureLanguageList: InfrastructureLanguage[] = [];
    InfrastructureCivicAddress: Address[] = [];
    BoxModelModelList: BoxModelModel[] = [];
    VPScenarioModelList: VPScenarioModel[] = []
}

export class ContactModel extends WebBase {
    Contact: Contact = new Contact();
    ContactEmailModelList: EmailModel[] = [];
    ContactTelModelList: TelModel[] = [];
    ContactAddressModelList: AddressModel[] = [];
}

export class EmailModel extends WebBase {
    Email: Email = new Email();
}

export class TelModel extends WebBase {
    Tel: Tel = new Tel();
}

export class AddressModel extends WebBase {
    Email: Email = new Email();
}

export class BoxModelModel {
    BoxModel: BoxModel = new BoxModel();
    BoxModelLanguageList: BoxModelLanguage[] = [];
    BoxModelResultList: BoxModelResult[] = [];
}

export class VPScenarioModel {
    VPScenario: VPScenario = new VPScenario();
    VPScenarioLanguageList: VPScenarioLanguage[] = [];
    VPAmbientList: VPAmbient[] = [];
    VPResultList: VPResult[] = [];
}
