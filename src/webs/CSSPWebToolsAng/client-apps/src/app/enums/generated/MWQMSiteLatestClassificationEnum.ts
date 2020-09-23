/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';

export enum MWQMSiteLatestClassificationEnum {
    Approved = 1,
    ConditionallyApproved = 2,
    Restricted = 3,
    ConditionallyRestricted = 4,
    Prohibited = 5,
    Unclassified = 6,
}

export function MWQMSiteLatestClassificationEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Approved (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'ConditionallyApproved (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Restricted (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'ConditionallyRestricted (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Prohibited (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Unclassified (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Approved' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'ConditionallyApproved' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Restricted' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'ConditionallyRestricted' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Prohibited' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Unclassified' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function MWQMSiteLatestClassificationEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    MWQMSiteLatestClassificationEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
