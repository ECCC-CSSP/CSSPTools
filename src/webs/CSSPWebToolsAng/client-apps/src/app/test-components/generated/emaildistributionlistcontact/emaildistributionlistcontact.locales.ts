/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { EmailDistributionListContactTextModel } from './emaildistributionlistcontact.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesEmailDistributionListContactText(emaildistributionlistcontactTextModel$: BehaviorSubject<EmailDistributionListContactTextModel>) {
    let emaildistributionlistcontactTextModel: EmailDistributionListContactTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        emaildistributionlistcontactTextModel.Title = 'Le Titre';
    }

    emaildistributionlistcontactTextModel$.next(emaildistributionlistcontactTextModel);
}
