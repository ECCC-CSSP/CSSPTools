/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { CSSPFilesManagementDBContextTextModel } from './csspfilesmanagementdbcontext.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesCSSPFilesManagementDBContextText(csspfilesmanagementdbcontextTextModel$: BehaviorSubject<CSSPFilesManagementDBContextTextModel>) {
    let csspfilesmanagementdbcontextTextModel: CSSPFilesManagementDBContextTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        csspfilesmanagementdbcontextTextModel.Title = 'Le Titre';
    }

    csspfilesmanagementdbcontextTextModel$.next(csspfilesmanagementdbcontextTextModel);
}
