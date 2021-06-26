import { Injectable } from '@angular/core';
import { AppLoadedService } from '../app/app-loaded.service';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

@Injectable({
    providedIn: 'root'
})
export class FileLocalizeSwitchService {

    constructor(private appLoadedService: AppLoadedService) {
    }


    DoFileLocalizeSwitch(tvType: TVTypeEnum, tvFileModel: TVFileModel, localizedOK: boolean) {
        switch (tvType) {
            case TVTypeEnum.Area:
                {
                    for (let i = 0, count = this.appLoadedService.WebArea?.TVFileModelList.length; i < count; i++) {
                        if (this.appLoadedService.WebArea?.TVFileModelList[i]?.TVItem?.TVItemID == tvFileModel?.TVItem?.TVItemID) {
                            this.appLoadedService.WebArea.TVFileModelList[i].IsLocalized = localizedOK;
                            this.appLoadedService.WebArea.TVFileModelList[i].ErrorLocalizing = !localizedOK;
                            break;
                        }
                    }
                }
                break;
            case TVTypeEnum.Country:
                {
                    for (let i = 0, count = this.appLoadedService.WebCountry?.TVFileModelList.length; i < count; i++) {
                        if (this.appLoadedService.WebCountry.TVFileModelList[i]?.TVItem?.TVItemID == tvFileModel?.TVItem?.TVItemID) {
                            this.appLoadedService.WebCountry.TVFileModelList[i].IsLocalized = localizedOK;
                            this.appLoadedService.WebCountry.TVFileModelList[i].ErrorLocalizing = !localizedOK;
                            break;
                        }
                    }
                }
                break;
            case TVTypeEnum.Infrastructure:
                {
                    for (let i = 0, countI = this.appLoadedService.WebMunicipality?.InfrastructureModelList.length; i < countI; i++) {
                        for (let j = 0, countJ = this.appLoadedService.WebMunicipality?.InfrastructureModelList[i]?.TVFileModelList.length; j < countJ; j++) {
                            if (this.appLoadedService.WebMunicipality?.InfrastructureModelList[i]?.TVFileModelList[j]?.TVItem?.TVItemID == tvFileModel?.TVItem?.TVItemID) {
                                this.appLoadedService.WebMunicipality.InfrastructureModelList[i].TVFileModelList[j].IsLocalized = localizedOK;
                                this.appLoadedService.WebMunicipality.InfrastructureModelList[i].TVFileModelList[j].ErrorLocalizing = !localizedOK;
                                break;
                            }
                        }
                    }
                }
                break;
            case TVTypeEnum.Municipality:
                {
                    for (let i = 0, count = this.appLoadedService.WebMunicipality?.TVFileModelList.length; i < count; i++) {
                        if (this.appLoadedService.WebMunicipality?.TVFileModelList[i]?.TVItem?.TVItemID == tvFileModel?.TVItem?.TVItemID) {
                            this.appLoadedService.WebMunicipality.TVFileModelList[i].IsLocalized = localizedOK;
                            this.appLoadedService.WebMunicipality.TVFileModelList[i].ErrorLocalizing = !localizedOK;
                            break;
                        }
                    }
                }
                break;
            case TVTypeEnum.MWQMSite:
                {
                    for (let i = 0, countI = this.appLoadedService.WebMWQMSites?.MWQMSiteModelList.length; i < countI; i++) {
                        for (let j = 0, countJ = this.appLoadedService.WebMWQMSites?.MWQMSiteModelList[i]?.TVFileModelList.length; j < countJ; j++) {
                            if (this.appLoadedService.WebMWQMSites?.MWQMSiteModelList[i]?.TVFileModelList[j]?.TVItem?.TVItemID == tvFileModel?.TVItem?.TVItemID) {
                                this.appLoadedService.WebMWQMSites.MWQMSiteModelList[i].TVFileModelList[j].IsLocalized = localizedOK;
                                this.appLoadedService.WebMWQMSites.MWQMSiteModelList[i].TVFileModelList[j].ErrorLocalizing = !localizedOK;
                                break;
                            }
                        }
                    }
                }
                break;
            case TVTypeEnum.PolSourceSite:
                {
                    for (let i = 0, countI = this.appLoadedService.WebPolSourceSites?.PolSourceSiteModelList.length; i < countI; i++) {
                        for (let j = 0, countJ = this.appLoadedService.WebPolSourceSites?.PolSourceSiteModelList[i]?.TVFileModelList.length; j < countJ; j++) {
                            if (this.appLoadedService.WebPolSourceSites?.PolSourceSiteModelList[i]?.TVFileModelList[j]?.TVItem?.TVItemID == tvFileModel?.TVItem?.TVItemID) {
                                this.appLoadedService.WebPolSourceSites.PolSourceSiteModelList[i].TVFileModelList[j].IsLocalized = localizedOK;
                                this.appLoadedService.WebPolSourceSites.PolSourceSiteModelList[i].TVFileModelList[j].ErrorLocalizing = !localizedOK;
                                break;
                            }
                        }
                    }
                }
                break;
            case TVTypeEnum.Province:
                {
                    for (let i = 0, count = this.appLoadedService.WebProvince?.TVFileModelList.length; i < count; i++) {
                        if (this.appLoadedService.WebProvince?.TVFileModelList[i]?.TVItem?.TVItemID == tvFileModel?.TVItem?.TVItemID) {
                            this.appLoadedService.WebProvince.TVFileModelList[i].IsLocalized = localizedOK;
                            this.appLoadedService.WebProvince.TVFileModelList[i].ErrorLocalizing = !localizedOK;
                            break;
                        }
                    }
                }
                break;
            case TVTypeEnum.Root:
                {
                    for (let i = 0, count = this.appLoadedService.WebRoot?.TVFileModelList.length; i < count; i++) {
                        if (this.appLoadedService.WebRoot?.TVFileModelList[i]?.TVItem?.TVItemID == tvFileModel?.TVItem?.TVItemID) {
                            this.appLoadedService.WebRoot.TVFileModelList[i].IsLocalized = localizedOK;
                            this.appLoadedService.WebRoot.TVFileModelList[i].ErrorLocalizing = !localizedOK;
                            break;
                        }
                    }
                }
                break;
            case TVTypeEnum.Sector:
                {
                    for (let i = 0, count = this.appLoadedService.WebSector?.TVFileModelList.length; i < count; i++) {
                        if (this.appLoadedService.WebSector?.TVFileModelList[i]?.TVItem?.TVItemID == tvFileModel?.TVItem?.TVItemID) {
                            this.appLoadedService.WebSector.TVFileModelList[i].IsLocalized = localizedOK;
                            this.appLoadedService.WebSector.TVFileModelList[i].ErrorLocalizing = !localizedOK;
                            break;
                        }
                    }
                }
                break;
            case TVTypeEnum.Subsector:
                {
                    for (let i = 0, count = this.appLoadedService.WebSubsector?.TVFileModelList.length; i < count; i++) {
                        if (this.appLoadedService.WebSubsector?.TVFileModelList[i]?.TVItem?.TVItemID == tvFileModel?.TVItem?.TVItemID) {
                            this.appLoadedService.WebSubsector.TVFileModelList[i].IsLocalized = localizedOK;
                            this.appLoadedService.WebSubsector.TVFileModelList[i].ErrorLocalizing = !localizedOK;
                            break;
                        }
                    }
                }
                break;
            default:
                break;
        }
    }
}