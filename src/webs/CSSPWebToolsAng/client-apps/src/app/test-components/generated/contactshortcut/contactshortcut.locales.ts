/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { ContactShortcutTextModel } from './contactshortcut.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesContactShortcutText(contactshortcutTextModel$: BehaviorSubject<ContactShortcutTextModel>) {
    let contactshortcutTextModel: ContactShortcutTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        contactshortcutTextModel.Title = 'Le Titre';
    }

    contactshortcutTextModel$.next(contactshortcutTextModel);
}
