/*
 * Auto generated C:\CSSPTools\src\codegen\AngularEnumsGenerated\bin\Debug\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.model';

export enum TVTypeEnum {
    Root = 1,
    Address = 2,
    Area = 3,
    ClimateSite = 4,
    Contact = 5,
    Country = 6,
    Email = 7,
    File = 8,
    HydrometricSite = 9,
    Infrastructure = 10,
    MikeBoundaryConditionWebTide = 11,
    MikeBoundaryConditionMesh = 12,
    MikeScenario = 13,
    MikeSource = 14,
    Municipality = 15,
    MWQMSite = 16,
    PolSourceSite = 17,
    Province = 18,
    Sector = 19,
    Subsector = 20,
    Tel = 21,
    TideSite = 22,
    MWQMSiteSample = 23,
    WasteWaterTreatmentPlant = 24,
    LiftStation = 25,
    Spill = 26,
    BoxModel = 27,
    VisualPlumesScenario = 28,
    Outfall = 29,
    OtherInfrastructure = 30,
    MWQMRun = 31,
    NoDepuration = 33,
    Failed = 34,
    Passed = 35,
    NoData = 36,
    LessThan10 = 37,
    MeshNode = 38,
    WebTideNode = 39,
    SamplingPlan = 40,
    SeeOtherMunicipality = 41,
    LineOverflow = 42,
    BoxModelInputs = 43,
    BoxModelResults = 44,
    ClimateSiteInfo = 45,
    ClimateSiteData = 46,
    HydrometricSiteInfo = 47,
    HydrometricSiteData = 48,
    InfrastructureInfo = 49,
    LabSheetInfo = 50,
    LabSheetDetailInfo = 51,
    MapInfo = 52,
    MapInfoPoint = 53,
    MikeSourceStartEndInfo = 54,
    MWQMLookupMPNInfo = 55,
    SamplingPlanInfo = 56,
    SamplingPlanSubsectorInfo = 57,
    SamplingPlanSubsectorSiteInfo = 58,
    MWQMSiteStartEndInfo = 59,
    MWQMSubsectorInfo = 60,
    PolSourceSiteInfo = 61,
    PolSourceSiteObsInfo = 62,
    HydrometricRatingCurveInfo = 63,
    HydrometricRatingCurveDataInfo = 64,
    TideLocationInfo = 65,
    TideSiteDataInfo = 66,
    UseOfSite = 67,
    VisualPlumesScenarioInfo = 68,
    VisualPlumesScenarioAmbient = 69,
    VisualPlumesScenarioResults = 70,
    TotalFile = 71,
    MikeSourceIsRiver = 72,
    MikeSourceIncluded = 73,
    MikeSourceNotIncluded = 74,
    RainExceedance = 75,
    EmailDistributionList = 76,
    OpenData = 77,
    ProvinceTools = 78,
    Classification = 79,
    Approved = 80,
    Restricted = 81,
    Prohibited = 82,
    ConditionallyApproved = 83,
    ConditionallyRestricted = 84,
    OpenDataNational = 85,
    PolSourceSiteMikeScenario = 86,
    SubsectorTools = 87,
}

export function TVTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Base' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Adresse' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Région' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Climate Site (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Contact (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Pays' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Courriel' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Fichier' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Poste hydrométrique' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Infrastructure' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'Mike Boundary Condition Web Tide (fr)' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'Mike Boundary Condition Mesh (fr)' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'Scénario MIKE' });
        enumTextOrderedList.push({ EnumID: 14, EnumText: 'Source MIKE' });
        enumTextOrderedList.push({ EnumID: 15, EnumText: 'Municipalité' });
        enumTextOrderedList.push({ EnumID: 16, EnumText: 'MWQM Site (fr)' });
        enumTextOrderedList.push({ EnumID: 17, EnumText: 'Site de la source de pollution' });
        enumTextOrderedList.push({ EnumID: 18, EnumText: 'Province ' });
        enumTextOrderedList.push({ EnumID: 19, EnumText: 'Secteur' });
        enumTextOrderedList.push({ EnumID: 20, EnumText: 'Sous-secteur' });
        enumTextOrderedList.push({ EnumID: 21, EnumText: 'Tél' });
        enumTextOrderedList.push({ EnumID: 22, EnumText: 'Poste de marée' });
        enumTextOrderedList.push({ EnumID: 23, EnumText: 'MWQM Site Sample (fr)' });
        enumTextOrderedList.push({ EnumID: 24, EnumText: 'Usine de traitement de eaux usées' });
        enumTextOrderedList.push({ EnumID: 25, EnumText: 'Poste de pompage' });
        enumTextOrderedList.push({ EnumID: 26, EnumText: 'Déversement' });
        enumTextOrderedList.push({ EnumID: 27, EnumText: 'Box Model' });
        enumTextOrderedList.push({ EnumID: 28, EnumText: 'Scénario Visual Plumes' });
        enumTextOrderedList.push({ EnumID: 29, EnumText: 'Émissaire' });
        enumTextOrderedList.push({ EnumID: 30, EnumText: 'Other Infrastructure (fr)' });
        enumTextOrderedList.push({ EnumID: 31, EnumText: 'MWQM Run (fr)' });
        enumTextOrderedList.push({ EnumID: 33, EnumText: 'No Depuration (fr)' });
        enumTextOrderedList.push({ EnumID: 34, EnumText: 'Échec' });
        enumTextOrderedList.push({ EnumID: 35, EnumText: 'Réussi' });
        enumTextOrderedList.push({ EnumID: 36, EnumText: 'Aucune donnée' });
        enumTextOrderedList.push({ EnumID: 37, EnumText: 'Less Than 10 Samples (fr)' });
        enumTextOrderedList.push({ EnumID: 38, EnumText: 'Mesh Node (fr)' });
        enumTextOrderedList.push({ EnumID: 39, EnumText: 'Web Tide Node (fr)' });
        enumTextOrderedList.push({ EnumID: 40, EnumText: 'MWQM Plan (fr)' });
        enumTextOrderedList.push({ EnumID: 41, EnumText: 'Voir autre municipalité' });
        enumTextOrderedList.push({ EnumID: 42, EnumText: 'Line overflow (fr)' });
        enumTextOrderedList.push({ EnumID: 43, EnumText: 'Box Model Inputs (fr)' });
        enumTextOrderedList.push({ EnumID: 44, EnumText: 'Box Model Results (fr)' });
        enumTextOrderedList.push({ EnumID: 45, EnumText: 'Climate Site Info (fr)' });
        enumTextOrderedList.push({ EnumID: 46, EnumText: 'Climate Site Data (fr)' });
        enumTextOrderedList.push({ EnumID: 47, EnumText: 'Hydrometric Site Info (fr)' });
        enumTextOrderedList.push({ EnumID: 48, EnumText: 'Hydrometric Site Data (fr)' });
        enumTextOrderedList.push({ EnumID: 49, EnumText: 'Infrastructure Info (fr)' });
        enumTextOrderedList.push({ EnumID: 50, EnumText: 'Lab Sheet Info (fr)' });
        enumTextOrderedList.push({ EnumID: 51, EnumText: 'Lab Sheet Detail Info (fr)' });
        enumTextOrderedList.push({ EnumID: 52, EnumText: 'Map Info (fr)' });
        enumTextOrderedList.push({ EnumID: 53, EnumText: 'Map Info Point (fr)' });
        enumTextOrderedList.push({ EnumID: 54, EnumText: 'Mike Source Start End Info (fr)' });
        enumTextOrderedList.push({ EnumID: 55, EnumText: 'MWQM Lookup MPN Info (fr)' });
        enumTextOrderedList.push({ EnumID: 56, EnumText: 'MWQM Plan Info (fr)' });
        enumTextOrderedList.push({ EnumID: 57, EnumText: 'MWQM Plan Subsector Info (fr)' });
        enumTextOrderedList.push({ EnumID: 58, EnumText: 'MWQM Plan Subsector Site Info (fr)' });
        enumTextOrderedList.push({ EnumID: 59, EnumText: 'MWQM Site Start End Info (fr)' });
        enumTextOrderedList.push({ EnumID: 60, EnumText: 'MWQM Subsector Info (fr)' });
        enumTextOrderedList.push({ EnumID: 61, EnumText: 'Pollution Source Site Info (fr)' });
        enumTextOrderedList.push({ EnumID: 62, EnumText: 'Pollution Source Site Observation Info (fr)' });
        enumTextOrderedList.push({ EnumID: 63, EnumText: 'Hydrometric Rating Curve Info (fr)' });
        enumTextOrderedList.push({ EnumID: 64, EnumText: 'Hydrometric Rating Curve Data Info (fr)' });
        enumTextOrderedList.push({ EnumID: 65, EnumText: 'Tide Location Info (fr)' });
        enumTextOrderedList.push({ EnumID: 66, EnumText: 'Tide Site Data Info (fr)' });
        enumTextOrderedList.push({ EnumID: 67, EnumText: 'Use Of Site (fr)' });
        enumTextOrderedList.push({ EnumID: 68, EnumText: 'Visual Plumes Scenario Info (fr)' });
        enumTextOrderedList.push({ EnumID: 69, EnumText: 'Visual Plumes Scenario Ambient (fr)' });
        enumTextOrderedList.push({ EnumID: 70, EnumText: 'Visual Plumes Scenario Results (fr)' });
        enumTextOrderedList.push({ EnumID: 71, EnumText: 'Totale filière' });
        enumTextOrderedList.push({ EnumID: 72, EnumText: 'Source de pollution MIKE rivière' });
        enumTextOrderedList.push({ EnumID: 73, EnumText: 'Source de pollution MIKE inclus' });
        enumTextOrderedList.push({ EnumID: 74, EnumText: 'Source de pollution MIKE non inclus' });
        enumTextOrderedList.push({ EnumID: 75, EnumText: 'Exceedance de pluie' });
        enumTextOrderedList.push({ EnumID: 76, EnumText: 'Liste de distribution des courriels' });
        enumTextOrderedList.push({ EnumID: 77, EnumText: 'Open Data (fr)' });
        enumTextOrderedList.push({ EnumID: 78, EnumText: 'Province Tools' });
        enumTextOrderedList.push({ EnumID: 79, EnumText: 'Classification' });
        enumTextOrderedList.push({ EnumID: 80, EnumText: 'Agréé' });
        enumTextOrderedList.push({ EnumID: 81, EnumText: 'Restreint' });
        enumTextOrderedList.push({ EnumID: 82, EnumText: 'Interdit' });
        enumTextOrderedList.push({ EnumID: 83, EnumText: 'Agréé sous condition' });
        enumTextOrderedList.push({ EnumID: 84, EnumText: 'Restreint sous condition' });
        enumTextOrderedList.push({ EnumID: 85, EnumText: 'Open Data national (fr)' });
        enumTextOrderedList.push({ EnumID: 86, EnumText: 'Pollution source site Mike Scenario (fr)' });
        enumTextOrderedList.push({ EnumID: 87, EnumText: 'Subsector tools (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Root' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Address' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Area' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Climate Site' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Contact' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Country' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Email' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'File' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Hydrometric Site' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Infrastructure' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'Mike Boundary Condition Web Tide' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'Mike Boundary Condition Mesh' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'Mike Scenario' });
        enumTextOrderedList.push({ EnumID: 14, EnumText: 'Mike Source' });
        enumTextOrderedList.push({ EnumID: 15, EnumText: 'Municipality' });
        enumTextOrderedList.push({ EnumID: 16, EnumText: 'MWQM Site' });
        enumTextOrderedList.push({ EnumID: 17, EnumText: 'Pollution Source Site' });
        enumTextOrderedList.push({ EnumID: 18, EnumText: 'Province' });
        enumTextOrderedList.push({ EnumID: 19, EnumText: 'Sector' });
        enumTextOrderedList.push({ EnumID: 20, EnumText: 'Subsector' });
        enumTextOrderedList.push({ EnumID: 21, EnumText: 'Tel' });
        enumTextOrderedList.push({ EnumID: 22, EnumText: 'Tide Site' });
        enumTextOrderedList.push({ EnumID: 23, EnumText: 'MWQM Site Sample' });
        enumTextOrderedList.push({ EnumID: 24, EnumText: 'Waste Water Treatment Plant' });
        enumTextOrderedList.push({ EnumID: 25, EnumText: 'Lift Station' });
        enumTextOrderedList.push({ EnumID: 26, EnumText: 'Spill' });
        enumTextOrderedList.push({ EnumID: 27, EnumText: 'Box Model' });
        enumTextOrderedList.push({ EnumID: 28, EnumText: 'Visual Plumes Scenario' });
        enumTextOrderedList.push({ EnumID: 29, EnumText: 'Outfall' });
        enumTextOrderedList.push({ EnumID: 30, EnumText: 'Other Infrastructure' });
        enumTextOrderedList.push({ EnumID: 31, EnumText: 'MWQM Run' });
        enumTextOrderedList.push({ EnumID: 33, EnumText: 'No Depuration' });
        enumTextOrderedList.push({ EnumID: 34, EnumText: 'Failed' });
        enumTextOrderedList.push({ EnumID: 35, EnumText: 'Passed' });
        enumTextOrderedList.push({ EnumID: 36, EnumText: 'No Data' });
        enumTextOrderedList.push({ EnumID: 37, EnumText: 'Less Than 10 Samples' });
        enumTextOrderedList.push({ EnumID: 38, EnumText: 'Mesh Node' });
        enumTextOrderedList.push({ EnumID: 39, EnumText: 'Web Tide Node' });
        enumTextOrderedList.push({ EnumID: 40, EnumText: 'MWQM Plan' });
        enumTextOrderedList.push({ EnumID: 41, EnumText: 'See other municipality' });
        enumTextOrderedList.push({ EnumID: 42, EnumText: 'Line overflow' });
        enumTextOrderedList.push({ EnumID: 43, EnumText: 'Box Model Inputs' });
        enumTextOrderedList.push({ EnumID: 44, EnumText: 'Box Model Results' });
        enumTextOrderedList.push({ EnumID: 45, EnumText: 'Climate Site Info' });
        enumTextOrderedList.push({ EnumID: 46, EnumText: 'Climate Site Data' });
        enumTextOrderedList.push({ EnumID: 47, EnumText: 'Hydrometric Site Info' });
        enumTextOrderedList.push({ EnumID: 48, EnumText: 'Hydrometric Site Data' });
        enumTextOrderedList.push({ EnumID: 49, EnumText: 'Infrastructure Info' });
        enumTextOrderedList.push({ EnumID: 50, EnumText: 'Lab Sheet Info' });
        enumTextOrderedList.push({ EnumID: 51, EnumText: 'Lab Sheet Detail Info' });
        enumTextOrderedList.push({ EnumID: 52, EnumText: 'Map Info' });
        enumTextOrderedList.push({ EnumID: 53, EnumText: 'Map Info Point' });
        enumTextOrderedList.push({ EnumID: 54, EnumText: 'Mike Source Start End Info' });
        enumTextOrderedList.push({ EnumID: 55, EnumText: 'MWQM Lookup MPN Info' });
        enumTextOrderedList.push({ EnumID: 56, EnumText: 'MWQM Plan Info' });
        enumTextOrderedList.push({ EnumID: 57, EnumText: 'MWQM Plan Subsector Info' });
        enumTextOrderedList.push({ EnumID: 58, EnumText: 'MWQM Plan Subsector Site Info' });
        enumTextOrderedList.push({ EnumID: 59, EnumText: 'MWQM Site Start End Info' });
        enumTextOrderedList.push({ EnumID: 60, EnumText: 'MWQM Subsector Info' });
        enumTextOrderedList.push({ EnumID: 61, EnumText: 'Pollution Source Site Info' });
        enumTextOrderedList.push({ EnumID: 62, EnumText: 'Pollution Source Site Observation Info' });
        enumTextOrderedList.push({ EnumID: 63, EnumText: 'Hydrometric Rating Curve Info' });
        enumTextOrderedList.push({ EnumID: 64, EnumText: 'Hydrometric Rating Curve Data Info' });
        enumTextOrderedList.push({ EnumID: 65, EnumText: 'Tide Location Info' });
        enumTextOrderedList.push({ EnumID: 66, EnumText: 'Tide Site Data Info' });
        enumTextOrderedList.push({ EnumID: 67, EnumText: 'Use Of Site' });
        enumTextOrderedList.push({ EnumID: 68, EnumText: 'Visual Plumes Scenario Info' });
        enumTextOrderedList.push({ EnumID: 69, EnumText: 'Visual Plumes Scenario Ambient' });
        enumTextOrderedList.push({ EnumID: 70, EnumText: 'Visual Plumes Scenario Results' });
        enumTextOrderedList.push({ EnumID: 71, EnumText: 'Total file' });
        enumTextOrderedList.push({ EnumID: 72, EnumText: 'Mike source is river' });
        enumTextOrderedList.push({ EnumID: 73, EnumText: 'Mike source included' });
        enumTextOrderedList.push({ EnumID: 74, EnumText: 'Mike source not included' });
        enumTextOrderedList.push({ EnumID: 75, EnumText: 'Rain exceedance' });
        enumTextOrderedList.push({ EnumID: 76, EnumText: 'Email distribution list' });
        enumTextOrderedList.push({ EnumID: 77, EnumText: 'Open Data' });
        enumTextOrderedList.push({ EnumID: 78, EnumText: 'Province Tools' });
        enumTextOrderedList.push({ EnumID: 79, EnumText: 'Classification' });
        enumTextOrderedList.push({ EnumID: 80, EnumText: 'Approved' });
        enumTextOrderedList.push({ EnumID: 81, EnumText: 'Restricted' });
        enumTextOrderedList.push({ EnumID: 82, EnumText: 'Prohibited' });
        enumTextOrderedList.push({ EnumID: 83, EnumText: 'Conditionally Approved' });
        enumTextOrderedList.push({ EnumID: 84, EnumText: 'Conditionally Restricted' });
        enumTextOrderedList.push({ EnumID: 85, EnumText: 'Open Data national' });
        enumTextOrderedList.push({ EnumID: 86, EnumText: 'Pollution source site Mike Scenario' });
        enumTextOrderedList.push({ EnumID: 87, EnumText: 'Subsector tools' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function TVTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    TVTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}