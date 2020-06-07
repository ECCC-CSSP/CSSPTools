/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { ContactTextModel }
from './contact.models';
import { ContactService }
from './contact.service';

export function LoadLocalesContactText(contactService: ContactService) {
    let contactTextModel: ContactTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        contactTextModel.Title = 'Le Titre';
    }

    contactService.UpdateContactText(contactTextModel);
}