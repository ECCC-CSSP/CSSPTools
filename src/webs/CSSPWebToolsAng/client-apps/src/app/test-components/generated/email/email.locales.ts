/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EmailTextModel } from './email.models';
import { EmailService } from './email.service';

export function LoadLocalesEmailText(emailService: EmailService) {
    let emailTextModel: EmailTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        emailTextModel.Title = 'Le Titre';
    }

    emailService.emailTextModel$.next(emailTextModel);
}
