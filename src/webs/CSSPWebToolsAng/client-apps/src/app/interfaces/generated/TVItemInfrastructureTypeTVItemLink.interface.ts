/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularInterfacesGenerated\bin\Debug\netcoreapp3.1\AngularInterfacesGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { TVItemInfrastructureTypeTVItemLink } from './TVItemInfrastructureTypeTVItemLink.interface';
import { InfrastructureTypeEnum } from '../../enums/generated/InfrastructureTypeEnum';
import { TVItem } from './TVItem.interface';
import { TVItemLink } from './TVItemLink.interface';

export interface TVItemInfrastructureTypeTVItemLink {
    FlowTo: TVItemInfrastructureTypeTVItemLink;
    InfrastructureType: InfrastructureTypeEnum;
    InfrastructureTypeText: string;
    SeeOtherMunicipalityTVItemID?: number;
    TVItem: TVItem;
    TVItemLinkList: TVItemLink[];
}
