/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularModelsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from './LastUpdate.model';
import { ScenarioStatusEnum } from '../../enums/generated/ScenarioStatusEnum';

export class VPScenario extends LastUpdate {
    AcuteMixZone_m?: number;
    ChronicMixZone_m?: number;
    EffluentConcentration_MPN_100ml?: number;
    EffluentFlow_m3_s?: number;
    EffluentSalinity_PSU?: number;
    EffluentTemperature_C?: number;
    EffluentVelocity_m_s?: number;
    FroudeNumber?: number;
    HorizontalAngle_deg?: number;
    InfrastructureTVItemID: number;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    NumberOfPorts?: number;
    PortDepth_m?: number;
    PortDiameter_m?: number;
    PortElevation_m?: number;
    PortSpacing_m?: number;
    RawResults: string;
    UseAsBestEstimate: boolean;
    VerticalAngle_deg?: number;
    VPScenarioID: number;
    VPScenarioStatus: ScenarioStatusEnum;
}
