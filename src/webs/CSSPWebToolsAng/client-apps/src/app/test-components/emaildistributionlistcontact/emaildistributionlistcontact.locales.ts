/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EmailDistributionListContactTextModel }
from './emaildistributionlistcontact.models';
import { EmailDistributionListContactService }
from './emaildistributionlistcontact.service';

export function LoadLocalesEmailDistributionListContactText(emaildistributionlistcontactService: EmailDistributionListContactService) {
    let emaildistributionlistcontactTextModel: EmailDistributionListContactTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        emaildistributionlistcontactTextModel.Title = 'Le Titre';
    }

    emaildistributionlistcontactService.UpdateEmailDistributionListContactText(emaildistributionlistcontactTextModel);
}
