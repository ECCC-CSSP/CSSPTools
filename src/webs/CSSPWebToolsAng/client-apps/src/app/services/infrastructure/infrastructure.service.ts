import { Injectable } from '@angular/core';
import { AerationTypeEnum_GetIDText } from 'src/app/enums/generated/AerationTypeEnum';
import { AlarmSystemTypeEnum_GetIDText } from 'src/app/enums/generated/AlarmSystemTypeEnum';
import { CollectionSystemTypeEnum_GetIDText } from 'src/app/enums/generated/CollectionSystemTypeEnum';
import { DisinfectionTypeEnum_GetIDText } from 'src/app/enums/generated/DisinfectionTypeEnum';
import { FacilityTypeEnum, FacilityTypeEnum_GetIDText, GetFacilityTypeEnum } from 'src/app/enums/generated/FacilityTypeEnum';
import { GetInfrastructureTypeEnum, InfrastructureTypeEnum_GetIDText } from 'src/app/enums/generated/InfrastructureTypeEnum';
import { GetMapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { PreliminaryTreatmentTypeEnum_GetIDText } from 'src/app/enums/generated/PreliminaryTreatmentTypeEnum';
import { PrimaryTreatmentTypeEnum_GetIDText } from 'src/app/enums/generated/PrimaryTreatmentTypeEnum';
import { SecondaryTreatmentTypeEnum_GetIDText } from 'src/app/enums/generated/SecondaryTreatmentTypeEnum';
import { TertiaryTreatmentTypeEnum_GetIDText } from 'src/app/enums/generated/TertiaryTreatmentTypeEnum';
import { TreatmentTypeEnum_GetIDText } from 'src/app/enums/generated/TreatmentTypeEnum';
import { GetTVTypeEnum, TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { ValveTypeEnum_GetIDText } from 'src/app/enums/generated/ValveTypeEnum';
import { TVItemLink } from 'src/app/models/generated/db/TVItemLink.model';
import { InfrastructureItemValue } from 'src/app/models/generated/models/InfrastructureItemValue.model';
import { InfrastructureModel } from 'src/app/models/generated/models/InfrastructureModel.model';
import { InfrastructureModelPath } from 'src/app/models/generated/models/InfrastructureModelPath.model';
import { MapInfoModel } from 'src/app/models/generated/models/MapInfoModel.model';
import { AppLanguageService } from '../app/app-language.service';
import { AppLoadedService } from '../app/app-loaded.service';
import { AppStateService } from '../app/app-state.service';

@Injectable({
    providedIn: 'root'
})
export class InfrastructureService {
    private countInf: number = 0;

    constructor(private appLanguageService: AppLanguageService,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
    ) {
    }

    GetInfrastructureModelPathList(): InfrastructureModelPath[] {
        let InfrastructureType = GetInfrastructureTypeEnum();
        let InfrastructureModelPathList: InfrastructureModelPath[] = [];
        this.appLoadedService.TVItemModelInfrastructureList = [];

        let InfrastructureModelList: InfrastructureModel[] = this.appLoadedService.WebMunicipality.InfrastructureModelList;
        let TVItemLinkAllList: TVItemLink[] = this.appLoadedService.WebMunicipality.MunicipalityTVItemLinkList;

        // doing all except InfrastructureTypeEnum.Other
        this.countInf = 0;
        for (let i = 0, count = InfrastructureModelList.length; i < count; i++) {
            if (!(InfrastructureModelList[i].Infrastructure.InfrastructureType == null
                || InfrastructureModelList[i].Infrastructure.InfrastructureType == InfrastructureType.Other
                || InfrastructureModelList[i].Infrastructure.InfrastructureType == InfrastructureType.SeeOtherMunicipality)) {
                // getting all the infrastructure that does not have a child
                let TVItemLinkList: TVItemLink[] = TVItemLinkAllList.filter(c => c.FromTVItemID == InfrastructureModelList[i].TVItemModel.TVItem.TVItemID
                    && c.FromTVType == TVTypeEnum.Infrastructure);

                if (TVItemLinkList == undefined || TVItemLinkList.length == 0) {
                    this.countInf += 1;
                    let infrastructureModelPath = <InfrastructureModelPath>{
                        InfrastructureModel: InfrastructureModelList[i],
                        InfrastructureModelChildList: [],
                        Count: this.countInf,
                        ShowOnMap: true,
                    };
                    this.countInf += 1;
                    InfrastructureModelPathList.push(infrastructureModelPath);
                    this.appLoadedService.TVItemModelInfrastructureList.push(infrastructureModelPath.InfrastructureModel.TVItemModel);

                    this.GetInfrastructureModelChild(infrastructureModelPath, InfrastructureModelPathList, InfrastructureModelList, TVItemLinkAllList);
                }
            }
        }

        // doing all InfrastructureTypeEnum.Other && InfrastructureTypeEnum.SeeOtherMunicipality
        for (let i = 0, count = InfrastructureModelList.length; i < count; i++) {
            if (InfrastructureModelList[i].Infrastructure.InfrastructureType == null
                || InfrastructureModelList[i].Infrastructure.InfrastructureType == InfrastructureType.Other
                || InfrastructureModelList[i].Infrastructure.InfrastructureType == InfrastructureType.SeeOtherMunicipality) {
                this.countInf += 1;
                let infrastructureModelPath = <InfrastructureModelPath>{
                    InfrastructureModel: InfrastructureModelList[i],
                    InfrastructureModelChildList: [],
                    Count: this.countInf,
                    ShowOnMap: false,
                };
                InfrastructureModelPathList.push(infrastructureModelPath);
                this.appLoadedService.TVItemModelInfrastructureList.push(infrastructureModelPath.InfrastructureModel.TVItemModel);
            }
        }

        return InfrastructureModelPathList;
    }

    FillInfrastructureItemValue(infrastructureModel: InfrastructureModel): InfrastructureItemValue[] {
        let InfrastructureItemValueList: InfrastructureItemValue[] = [];
        let infrastructureType = GetInfrastructureTypeEnum();
        let mapInfoDrawType = GetMapInfoDrawTypeEnum();
        let tvType = GetTVTypeEnum();
        let facilityType = GetFacilityTypeEnum();

        let tvTypeCurrent: TVTypeEnum;
        switch (infrastructureModel.Infrastructure.InfrastructureType) {
            case infrastructureType.WWTP:
                {
                    tvTypeCurrent = tvType.WasteWaterTreatmentPlant;
                }
                break;
            case infrastructureType.LiftStation:
                {
                    tvTypeCurrent = tvType.LiftStation;
                }
                break;
            case infrastructureType.LineOverflow:
                {
                    tvTypeCurrent = tvType.LineOverflow;
                }
                break;
            case infrastructureType.Other:
                {
                    tvTypeCurrent = tvType.OtherInfrastructure;
                }
                break;
            case infrastructureType.SeeOtherMunicipality:
                {
                    tvTypeCurrent = tvType.SeeOtherMunicipality;
                }
                break;
            default:
                break;
        }

        InfrastructureItemValueList.push(<InfrastructureItemValue>{
            Item: this.appLanguageService.InfrastructureType[this.appLanguageService.LangID],
            Value: infrastructureModel.Infrastructure.InfrastructureType == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${InfrastructureTypeEnum_GetIDText(infrastructureModel.Infrastructure.InfrastructureType, this.appLanguageService)}`
        });
        if (infrastructureModel.Infrastructure.InfrastructureType == infrastructureType.WWTP) {
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.FacilityType[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.FacilityType == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${FacilityTypeEnum_GetIDText(infrastructureModel.Infrastructure.FacilityType, this.appLanguageService)}`
            });
            if (infrastructureModel.Infrastructure.FacilityType == facilityType.Lagoon) {
                InfrastructureItemValueList.push(<InfrastructureItemValue>{
                    Item: this.appLanguageService.IsMechanicallyAerated[this.appLanguageService.LangID],
                    Value: infrastructureModel.Infrastructure.IsMechanicallyAerated == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : (infrastructureModel.Infrastructure.IsMechanicallyAerated ? this.appLanguageService.Yes[this.appLanguageService.LangID] : this.appLanguageService.No[this.appLanguageService.LangID])
                });
                InfrastructureItemValueList.push(<InfrastructureItemValue>{
                    Item: this.appLanguageService.NumberOfCells[this.appLanguageService.LangID],
                    Value: infrastructureModel.Infrastructure.NumberOfCells == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.NumberOfCells}`
                });
                InfrastructureItemValueList.push(<InfrastructureItemValue>{
                    Item: this.appLanguageService.NumberOfAeratedCells[this.appLanguageService.LangID],
                    Value: infrastructureModel.Infrastructure.NumberOfAeratedCells == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.NumberOfAeratedCells}`
                });
                InfrastructureItemValueList.push(<InfrastructureItemValue>{
                    Item: this.appLanguageService.AerationType[this.appLanguageService.LangID],
                    Value: infrastructureModel.Infrastructure.AerationType == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${AerationTypeEnum_GetIDText(infrastructureModel.Infrastructure.AerationType, this.appLanguageService)}`
                });
            }
            if (infrastructureModel.Infrastructure.FacilityType == facilityType.Plant) {
                InfrastructureItemValueList.push(<InfrastructureItemValue>{
                    Item: this.appLanguageService.PreliminaryTreatmentType[this.appLanguageService.LangID],
                    Value: infrastructureModel.Infrastructure.PreliminaryTreatmentType == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${PreliminaryTreatmentTypeEnum_GetIDText(infrastructureModel.Infrastructure.PreliminaryTreatmentType, this.appLanguageService)}`
                });   
                InfrastructureItemValueList.push(<InfrastructureItemValue>{
                    Item: this.appLanguageService.PrimaryTreatmentType[this.appLanguageService.LangID],
                    Value: infrastructureModel.Infrastructure.PrimaryTreatmentType == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${PrimaryTreatmentTypeEnum_GetIDText(infrastructureModel.Infrastructure.PrimaryTreatmentType, this.appLanguageService)}`
                });   
                InfrastructureItemValueList.push(<InfrastructureItemValue>{
                    Item: this.appLanguageService.SecondaryTreatmentType[this.appLanguageService.LangID],
                    Value: infrastructureModel.Infrastructure.SecondaryTreatmentType == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${SecondaryTreatmentTypeEnum_GetIDText(infrastructureModel.Infrastructure.SecondaryTreatmentType, this.appLanguageService)}`
                });   
                InfrastructureItemValueList.push(<InfrastructureItemValue>{
                    Item: this.appLanguageService.TertiaryTreatmentType[this.appLanguageService.LangID],
                    Value: infrastructureModel.Infrastructure.TertiaryTreatmentType == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${TertiaryTreatmentTypeEnum_GetIDText(infrastructureModel.Infrastructure.TertiaryTreatmentType, this.appLanguageService)}`
                });   
                InfrastructureItemValueList.push(<InfrastructureItemValue>{
                    Item: this.appLanguageService.TreatmentType[this.appLanguageService.LangID],
                    Value: infrastructureModel.Infrastructure.TreatmentType == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${TreatmentTypeEnum_GetIDText(infrastructureModel.Infrastructure.TreatmentType, this.appLanguageService)}`
                });   
            } 
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.DisinfectionType[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.DisinfectionType == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${DisinfectionTypeEnum_GetIDText(infrastructureModel.Infrastructure.DisinfectionType, this.appLanguageService)}`
            });
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.CollectionSystemType[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.CollectionSystemType == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${CollectionSystemTypeEnum_GetIDText(infrastructureModel.Infrastructure.CollectionSystemType, this.appLanguageService)}`
            });
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.DesignFlow_m3_day[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.DesignFlow_m3_day == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.DesignFlow_m3_day}`
            });
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.AverageFlow_m3_day[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.AverageFlow_m3_day == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.AverageFlow_m3_day}`
            });
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.PeakFlow_m3_day[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.PeakFlow_m3_day == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.PeakFlow_m3_day}`
            });
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.PercFlowOfTotal[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.PercFlowOfTotal == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.PercFlowOfTotal}`
            });
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.PopServed[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.PopServed == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.PopServed}`
            });
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.AlarmSystemType[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.AlarmSystemType == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${AlarmSystemTypeEnum_GetIDText(infrastructureModel.Infrastructure.AlarmSystemType, this.appLanguageService)}`
            });
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.CanOverflow[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.CanOverflow == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : (infrastructureModel.Infrastructure.CanOverflow ? this.appLanguageService.Yes[this.appLanguageService.LangID] : this.appLanguageService.No[this.appLanguageService.LangID])
            });
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.ValveType[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.ValveType == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${ValveTypeEnum_GetIDText(infrastructureModel.Infrastructure.ValveType, this.appLanguageService)}`
            });
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.HasBackupPower[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.HasBackupPower == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : (infrastructureModel.Infrastructure.HasBackupPower ? this.appLanguageService.Yes[this.appLanguageService.LangID] : this.appLanguageService.No[this.appLanguageService.LangID])
            });

            let LatText: string = '';
            let LngText: string = '';
            let mapInfoInfrastructure: MapInfoModel[] = infrastructureModel.TVItemModel.MapInfoModelList.filter(c => c.MapInfo.TVItemID == infrastructureModel.TVItemModel.TVItem.TVItemID
                && c.MapInfo.MapInfoDrawType == mapInfoDrawType.Point
                && c.MapInfo.TVType == tvTypeCurrent);
            if (mapInfoInfrastructure != undefined && mapInfoInfrastructure.length > 0) {
                if (mapInfoInfrastructure[0].MapInfoPointList[0].Lat != null) {
                    LatText = mapInfoInfrastructure[0].MapInfoPointList[0].Lat.toFixed(6);
                    LngText = mapInfoInfrastructure[0].MapInfoPointList[0].Lng.toFixed(6);
                }
            }
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.LatitudeLongitude[this.appLanguageService.LangID],
                Value: LatText.length == 0 || LngText.length == 0 ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${LatText} ${LngText}`
            });

            LatText = '';
            LngText = '';
            mapInfoInfrastructure = infrastructureModel.TVItemModel.MapInfoModelList.filter(c => c.MapInfo.TVItemID == infrastructureModel.TVItemModel.TVItem.TVItemID
                && c.MapInfo.MapInfoDrawType == mapInfoDrawType.Point
                && c.MapInfo.TVType == TVTypeEnum.Outfall);
            if (mapInfoInfrastructure != undefined && mapInfoInfrastructure.length > 0) {
                if (mapInfoInfrastructure[0].MapInfoPointList[0].Lat != null) {
                    LatText = mapInfoInfrastructure[0].MapInfoPointList[0].Lat.toFixed(6);
                    LngText = mapInfoInfrastructure[0].MapInfoPointList[0].Lng.toFixed(6);
                }
            }
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.OutfallLatitudeLongitude[this.appLanguageService.LangID],
                Value: LatText.length == 0 || LngText.length == 0 ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${LatText} ${LngText}`
            });

        }
        else {
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.PercFlowOfTotal[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.PercFlowOfTotal == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.PercFlowOfTotal}`
            });

            let LatText: string = '';
            let LngText: string = '';
            let mapInfoInfrastructure: MapInfoModel[] = infrastructureModel.TVItemModel.MapInfoModelList.filter(c => c.MapInfo.TVItemID == infrastructureModel.TVItemModel.TVItem.TVItemID
                && c.MapInfo.MapInfoDrawType == mapInfoDrawType.Point
                && c.MapInfo.TVType == tvTypeCurrent);
            if (mapInfoInfrastructure != undefined && mapInfoInfrastructure.length > 0) {
                if (mapInfoInfrastructure[0].MapInfoPointList[0].Lat != null) {
                    LatText = mapInfoInfrastructure[0].MapInfoPointList[0].Lat.toFixed(6);
                    LngText = mapInfoInfrastructure[0].MapInfoPointList[0].Lng.toFixed(6);
                }
            }
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.LatitudeLongitude[this.appLanguageService.LangID],
                Value: LatText.length == 0 || LngText.length == 0 ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${LatText} ${LngText}`
            });

            LatText = '';
            LngText = '';
            mapInfoInfrastructure = infrastructureModel.TVItemModel.MapInfoModelList.filter(c => c.MapInfo.TVItemID == infrastructureModel.TVItemModel.TVItem.TVItemID
                && c.MapInfo.MapInfoDrawType == mapInfoDrawType.Point
                && c.MapInfo.TVType == TVTypeEnum.Outfall);
            if (mapInfoInfrastructure != undefined && mapInfoInfrastructure.length > 0) {
                if (mapInfoInfrastructure[0].MapInfoPointList[0].Lat != null) {
                    LatText = mapInfoInfrastructure[0].MapInfoPointList[0].Lat.toFixed(6);
                    LngText = mapInfoInfrastructure[0].MapInfoPointList[0].Lng.toFixed(6);
                }
            }
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.OutfallLatitudeLongitude[this.appLanguageService.LangID],
                Value: LatText.length == 0 || LngText.length == 0 ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${LatText} ${LngText}`
            });

            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.AlarmSystemType[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.AlarmSystemType == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${AlarmSystemTypeEnum_GetIDText(infrastructureModel.Infrastructure.AlarmSystemType, this.appLanguageService)}`
            });
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.CanOverflow[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.CanOverflow == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : (infrastructureModel.Infrastructure.CanOverflow ? this.appLanguageService.Yes[this.appLanguageService.LangID] : this.appLanguageService.No[this.appLanguageService.LangID])
            });
            InfrastructureItemValueList.push(<InfrastructureItemValue>{
                Item: this.appLanguageService.ValveType[this.appLanguageService.LangID],
                Value: infrastructureModel.Infrastructure.ValveType == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${ValveTypeEnum_GetIDText(infrastructureModel.Infrastructure.ValveType, this.appLanguageService)}`
            });

        }

        return InfrastructureItemValueList;
    }

    FillInfrastructureOutfallItemValue(infrastructureModel: InfrastructureModel): InfrastructureItemValue[] {
        let InfrastructureItemValueList: InfrastructureItemValue[] = [];
        let infrastructureType = GetInfrastructureTypeEnum();
        let mapInfoDrawType = GetMapInfoDrawTypeEnum();
        let tvType = GetTVTypeEnum();

        let tvTypeCurrent: TVTypeEnum;
        switch (infrastructureModel.Infrastructure.InfrastructureType) {
            case infrastructureType.WWTP:
                {
                    tvTypeCurrent = tvType.WasteWaterTreatmentPlant;
                }
                break;
            case infrastructureType.LiftStation:
                {
                    tvTypeCurrent = tvType.LiftStation;
                }
                break;
            case infrastructureType.LineOverflow:
                {
                    tvTypeCurrent = tvType.LineOverflow;
                }
                break;
            case infrastructureType.Other:
                {
                    tvTypeCurrent = tvType.OtherInfrastructure;
                }
                break;
            case infrastructureType.SeeOtherMunicipality:
                {
                    tvTypeCurrent = tvType.SeeOtherMunicipality;
                }
                break;
            default:
                break;
        }

        InfrastructureItemValueList.push(<InfrastructureItemValue>{
            Item: this.appLanguageService.AverageDepth_m[this.appLanguageService.LangID],
            Value: infrastructureModel.Infrastructure.AverageDepth_m == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.AverageDepth_m}`
        });
        InfrastructureItemValueList.push(<InfrastructureItemValue>{
            Item: this.appLanguageService.DecayRate_per_day[this.appLanguageService.LangID],
            Value: infrastructureModel.Infrastructure.DecayRate_per_day == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.DecayRate_per_day}`
        });
        InfrastructureItemValueList.push(<InfrastructureItemValue>{
            Item: this.appLanguageService.DistanceFromShore_m[this.appLanguageService.LangID],
            Value: infrastructureModel.Infrastructure.DistanceFromShore_m == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.DistanceFromShore_m}`
        });
        InfrastructureItemValueList.push(<InfrastructureItemValue>{
            Item: this.appLanguageService.FarFieldVelocity_m_s[this.appLanguageService.LangID],
            Value: infrastructureModel.Infrastructure.FarFieldVelocity_m_s == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.FarFieldVelocity_m_s}`
        });
        InfrastructureItemValueList.push(<InfrastructureItemValue>{
            Item: this.appLanguageService.HorizontalAngle_deg[this.appLanguageService.LangID],
            Value: infrastructureModel.Infrastructure.HorizontalAngle_deg == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.HorizontalAngle_deg}`
        });
        InfrastructureItemValueList.push(<InfrastructureItemValue>{
            Item: this.appLanguageService.NearFieldVelocity_m_s[this.appLanguageService.LangID],
            Value: infrastructureModel.Infrastructure.NearFieldVelocity_m_s == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.NearFieldVelocity_m_s}`
        });
        InfrastructureItemValueList.push(<InfrastructureItemValue>{
            Item: this.appLanguageService.NumberOfPorts[this.appLanguageService.LangID],
            Value: infrastructureModel.Infrastructure.NumberOfPorts == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.NumberOfPorts}`
        });
        InfrastructureItemValueList.push(<InfrastructureItemValue>{
            Item: this.appLanguageService.PortDiameter_m[this.appLanguageService.LangID],
            Value: infrastructureModel.Infrastructure.PortDiameter_m == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.PortDiameter_m}`
        });
        InfrastructureItemValueList.push(<InfrastructureItemValue>{
            Item: this.appLanguageService.PortElevation_m[this.appLanguageService.LangID],
            Value: infrastructureModel.Infrastructure.PortElevation_m == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.PortElevation_m}`
        });
        InfrastructureItemValueList.push(<InfrastructureItemValue>{
            Item: this.appLanguageService.PortSpacing_m[this.appLanguageService.LangID],
            Value: infrastructureModel.Infrastructure.PortSpacing_m == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.PortSpacing_m}`
        });
        InfrastructureItemValueList.push(<InfrastructureItemValue>{
            Item: this.appLanguageService.ReceivingWater_MPN_per_100ml[this.appLanguageService.LangID],
            Value: infrastructureModel.Infrastructure.ReceivingWater_MPN_per_100ml == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.ReceivingWater_MPN_per_100ml}`
        });
        InfrastructureItemValueList.push(<InfrastructureItemValue>{
            Item: this.appLanguageService.ReceivingWaterSalinity_PSU[this.appLanguageService.LangID],
            Value: infrastructureModel.Infrastructure.ReceivingWaterSalinity_PSU == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.ReceivingWaterSalinity_PSU}`
        });
        InfrastructureItemValueList.push(<InfrastructureItemValue>{
            Item: this.appLanguageService.ReceivingWaterTemperature_C[this.appLanguageService.LangID],
            Value: infrastructureModel.Infrastructure.ReceivingWaterTemperature_C == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.ReceivingWaterTemperature_C}`
        });
        InfrastructureItemValueList.push(<InfrastructureItemValue>{
            Item: this.appLanguageService.VerticalAngle_deg[this.appLanguageService.LangID],
            Value: infrastructureModel.Infrastructure.VerticalAngle_deg == null ? this.appLanguageService.NoData[this.appLanguageService.LangID] : `${infrastructureModel.Infrastructure.VerticalAngle_deg}`
        });

        return InfrastructureItemValueList;
    }

    private GetInfrastructureModelChild(InfrastructureModelPath: InfrastructureModelPath,
        InfrastructureModelPathList: InfrastructureModelPath[],
        InfrastructureModelList: InfrastructureModel[],
        TVItemLinkAllList: TVItemLink[]) {
        let InfrastructureType = GetInfrastructureTypeEnum();

        let TVItemLinkList: TVItemLink[] = TVItemLinkAllList.
            filter(c => c.ToTVItemID == InfrastructureModelPath.InfrastructureModel.TVItemModel.TVItem.TVItemID
                && c.ToTVType == TVTypeEnum.Infrastructure);

        if (TVItemLinkList != undefined || TVItemLinkList.length > 0) {
            for (let i = 0, count = TVItemLinkList.length; i < count; i++) {
                let InfrastructureModelListChild: InfrastructureModel[] = InfrastructureModelList.filter(c => c.TVItemModel.TVItem.TVItemID == TVItemLinkList[i].FromTVItemID);
                if (InfrastructureModelListChild != undefined && InfrastructureModelListChild.length > 0) {
                    if (!(InfrastructureModelList[i].Infrastructure.InfrastructureType == null
                        || InfrastructureModelList[i].Infrastructure.InfrastructureType == InfrastructureType.Other
                        || InfrastructureModelList[i].Infrastructure.InfrastructureType == InfrastructureType.SeeOtherMunicipality)) {

                        this.countInf += 1;
                        let infrastructureModelPath = <InfrastructureModelPath>{
                            InfrastructureModel: InfrastructureModelListChild[0],
                            InfrastructureModelChildList: [],
                            Count: this.countInf,
                            ShowOnMap: true,
                        };
                        this.countInf += 1;
                        InfrastructureModelPath.InfrastructureModelChildList.push(infrastructureModelPath);
                        this.appLoadedService.TVItemModelInfrastructureList.push(infrastructureModelPath.InfrastructureModel.TVItemModel);

                        this.GetInfrastructureModelChild(infrastructureModelPath,
                            InfrastructureModelPathList,
                            InfrastructureModelList,
                            TVItemLinkAllList);
                    }
                    if (InfrastructureModelList[i].Infrastructure.InfrastructureType == null
                        || InfrastructureModelList[i].Infrastructure.InfrastructureType == InfrastructureType.Other
                        || InfrastructureModelList[i].Infrastructure.InfrastructureType == InfrastructureType.SeeOtherMunicipality) {

                        this.countInf += 1;
                        let infrastructureModelPath = <InfrastructureModelPath>{
                            InfrastructureModel: InfrastructureModelListChild[0],
                            InfrastructureModelChildList: [],
                            Count: this.countInf,
                            ShowOnMap: false,
                        };
                        InfrastructureModelPath.InfrastructureModelChildList.push(infrastructureModelPath);
                        this.appLoadedService.TVItemModelInfrastructureList.push(infrastructureModelPath.InfrastructureModel.TVItemModel);

                        this.GetInfrastructureModelChild(infrastructureModelPath,
                            InfrastructureModelPathList,
                            InfrastructureModelList,
                            TVItemLinkAllList);
                    }
                }
            }
        }

    }
}
