/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateAngularCSSPHelperModels\bin\Debug\net6.0\GenerateAngularCSSPHelperModels.exe
 *
 * Do not edit this file.
 *
 */

import { AnalysisCalculationTypeEnum } from 'src/app/enums/generated/AnalysisCalculationTypeEnum';
import { FilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { AscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';

export class UserPreferenceModel {
    AnalysisCalculationType: AnalysisCalculationTypeEnum;
    AnalysisDry24h: number;
    AnalysisDry48h: number;
    AnalysisDry72h: number;
    AnalysisDry96h: number;
    AnalysisFCDataVisible: boolean;
    AnalysisFullYear: boolean;
    AnalysisGeoMeanDataVisible: boolean;
    AnalysisHighlightSalFromAverage: number;
    AnalysisMedianDataVisible: boolean;
    AnalysisMidRange: number;
    AnalysisP90DataVisible: boolean;
    AnalysisPerOver260DataVisible: boolean;
    AnalysisPerOver43DataVisible: boolean;
    AnalysisRuns: number;
    AnalysisSalDataVisible: boolean;
    AnalysisShortRange: number;
    AnalysisTempDataVisible: boolean;
    AnalysisWet24h: number;
    AnalysisWet48h: number;
    AnalysisWet72h: number;
    AnalysisWet96h: number;
    AreaFilesSortByProp: FilesSortPropEnum;
    AreaSectorsSortOrder: AscDescEnum;
    AreaSubComponent: AreaSubComponentEnum;
    ClassificationColorApproved: string;
    ClassificationColorConditionallyApproved: string;
    ClassificationColorConditionallyRestricted: string;
    ClassificationColorProhibited: string;
    ClassificationColorRestricted: string;
    CountryFilesSortByProp: FilesSortPropEnum;
    CountryProvincesSortOrder: AscDescEnum;
    CountrySubComponent: CountrySubComponentEnum;
    CurrentAreaTVItemID: number;
    CurrentCountryTVItemID: number;
    CurrentMunicipalityTVItemID: number;
    CurrentProvinceTVItemID: number;
    CurrentRootTVItemID: number;
    CurrentSectorTVItemID: number;
    CurrentSubsectorTVItemID: number;
    DetailVisible: boolean;
    EditVisible: boolean;
    History: TVItemModel[];
    InactVisible: boolean;
    InfrastructureFilesSortByProp: FilesSortPropEnum;
    LastUpdateVisible: boolean;
    LeftSideNavVisible: boolean;
    MapColorNotFound: string;
    MapMarkerColorArea: string;
    MapMarkerColorClimateSite: string;
    MapMarkerColorCountry: string;
    MapMarkerColorFailed: string;
    MapMarkerColorHydrometricSite: string;
    MapMarkerColorInfrastructure: string;
    MapMarkerColorLessThan10: string;
    MapMarkerColorLiftStation: string;
    MapMarkerColorLineOverflow: string;
    MapMarkerColorMeshNode: string;
    MapMarkerColorMikeBoundaryConditionMesh: string;
    MapMarkerColorMikeBoundaryConditionWebTide: string;
    MapMarkerColorMikeScenario: string;
    MapMarkerColorMikeSource: string;
    MapMarkerColorMikeSourceIncluded: string;
    MapMarkerColorMikeSourceIsRiver: string;
    MapMarkerColorMikeSourceNotIncluded: string;
    MapMarkerColorMunicipality: string;
    MapMarkerColorMWQMRun: string;
    MapMarkerColorMWQMSite: string;
    MapMarkerColorNoData: string;
    MapMarkerColorNoDepuration: string;
    MapMarkerColorOtherInfrastructure: string;
    MapMarkerColorOutfall: string;
    MapMarkerColorPassed: string;
    MapMarkerColorPolSourceSite: string;
    MapMarkerColorProvince: string;
    MapMarkerColorSector: string;
    MapMarkerColorSeeOtherMunicipality: string;
    MapMarkerColorSubsector: string;
    MapMarkerColorTideSite: string;
    MapMarkerColorWasteWaterTreatmentPlant: string;
    MapMarkerColorWebTideNode: string;
    MapPolygonColorArea: string;
    MapPolygonColorCountry: string;
    MapPolygonColorProvince: string;
    MapPolygonColorSector: string;
    MapPolygonColorSubsector: string;
    MapPolylineColorInfrastructureLiftStationToLiftStation: string;
    MapPolylineColorInfrastructureLiftStationToOutfall: string;
    MapPolylineColorInfrastructureLiftStationToWWTP: string;
    MapPolylineColorInfrastructureLineOverflowToOutfall: string;
    MapPolylineColorInfrastructureWWTPToOutfall: string;
    MapWidthText: string;
    MapVisible: boolean;
    MunicipalityContactsSortOrder: AscDescEnum;
    MunicipalityFilesSortByProp: FilesSortPropEnum;
    MunicipalityInfrastructuresSortOrder: AscDescEnum;
    MunicipalityMikeScenariosSortOrder: AscDescEnum;
    MunicipalitySubComponent: MunicipalitySubComponentEnum;
    MWQMSiteFilesSortByProp: FilesSortPropEnum;
    PolSourceSiteFilesSortByProp: FilesSortPropEnum;
    ProvinceAreasSortOrder: AscDescEnum;
    ProvinceFilesSortByProp: FilesSortPropEnum;
    ProvinceMunicipalitiesSortOrder: AscDescEnum;
    ProvinceSubComponent: ProvinceSubComponentEnum;
    RootCountriesSortOrder: AscDescEnum;
    RootFilesSortByProp: FilesSortPropEnum;
    RootSubComponent: RootSubComponentEnum;
    SectorFilesSortByProp: FilesSortPropEnum;
    SectorSubComponent: SectorSubComponentEnum;
    SectorSubsectorsSortOrder: AscDescEnum;
    ShellSubComponent: ShellSubComponentEnum;
    StatCountVisible: boolean;
    StatRunsForDetail: number;
    SubsectorFilesSortByProp: FilesSortPropEnum;
    SubsectorMWQMRunsSortOrder: AscDescEnum;
    SubsectorMWQMSitesSortOrder: AscDescEnum;
    SubsectorPolSourceSitesSortOrder: AscDescEnum;
    SubsectorSubComponent: SubsectorSubComponentEnum;
    TopComponent: TopComponentEnum;
}
