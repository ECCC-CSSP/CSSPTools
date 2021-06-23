import { Injectable } from '@angular/core';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { AppLoadedService } from '../app/app-loaded.service';
import { LocalFileInfo } from 'src/app/models/generated/web/LocalFileInfo.model';

@Injectable({
    providedIn: 'root'
})
export class JsonDoUpdateLocalFileInfoSwitchService {

    constructor(private appLoadedService: AppLoadedService) {
    }


    DoUpdateLocalFileInfoSwitch(WebType: WebTypeEnum, LocalFileInfoList: LocalFileInfo[]) {
        switch (WebType) {
            case WebTypeEnum.WebArea:
                {
                    for (let i = 0, count = this.appLoadedService.WebArea.TVFileModelList.length; i < count; i++) {
                        let ServerFileName = this.appLoadedService.WebArea.TVFileModelList[i].TVFile.ServerFileName;

                        let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                        if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0) {
                            this.appLoadedService.WebArea.TVFileModelList[i].IsLocalized = true;
                            //this.appLoadedService.WebArea.TVFileModelList[i].ErrorLocalizing = false;
                        }
                    }
                }
                break;
            case WebTypeEnum.WebCountry:
                {
                    for (let i = 0, count = this.appLoadedService.WebCountry.TVFileModelList.length; i < count; i++) {
                        let ServerFileName = this.appLoadedService.WebCountry.TVFileModelList[i].TVFile.ServerFileName;

                        let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                        if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0) {
                            this.appLoadedService.WebCountry.TVFileModelList[i].IsLocalized = true;
                            //this.appLoadedService.WebCountry.TVFileModelList[i].ErrorLocalizing = false;
                        }
                    }
                }
                break;
            case WebTypeEnum.WebMunicipality:
                {
                    for (let i = 0, count = this.appLoadedService.WebMunicipality.TVFileModelList.length; i < count; i++) {
                        let ServerFileName = this.appLoadedService.WebMunicipality.TVFileModelList[i].TVFile.ServerFileName;

                        let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                        if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0) {
                            this.appLoadedService.WebMunicipality.TVFileModelList[i].IsLocalized = true;
                            //this.appLoadedService.WebMunicipality.TVFileModelList[i].ErrorLocalizing = false;
                        }
                    }

                    for (let i = 0, countI = this.appLoadedService.WebMunicipality.InfrastructureModelList.length; i < countI; i++) {
                        for (let j = 0, countJ = this.appLoadedService.WebMunicipality.InfrastructureModelList.length; j < countJ; j++) {
                            let ServerFileName = this.appLoadedService.WebMunicipality.InfrastructureModelList[i].TVFileModelList[j].TVFile.ServerFileName;

                            let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                            if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0) {
                                this.appLoadedService.WebMunicipality.InfrastructureModelList[i].TVFileModelList[j].IsLocalized = true;
                                //this.appLoadedService.WebMunicipality.InfrastructureModelList[i].TVFileModelList[j].ErrorLocalizing = false;
                            }
                        }
                    }
                }
                break;
            case WebTypeEnum.WebProvince:
                {
                    for (let i = 0, count = this.appLoadedService.WebProvince.TVFileModelList.length; i < count; i++) {
                        let ServerFileName = this.appLoadedService.WebProvince.TVFileModelList[i].TVFile.ServerFileName;

                        let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                        if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0) {
                            this.appLoadedService.WebProvince.TVFileModelList[i].IsLocalized = true;
                            //this.appLoadedService.WebProvince.TVFileModelList[i].ErrorLocalizing = false;
                        }
                    }
                }
                break;
            case WebTypeEnum.WebRoot:
                {
                    for (let i = 0, count = this.appLoadedService.WebRoot.TVFileModelList.length; i < count; i++) {
                        let ServerFileName = this.appLoadedService.WebRoot.TVFileModelList[i].TVFile.ServerFileName;

                        let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                        if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0) {
                            this.appLoadedService.WebRoot.TVFileModelList[i].IsLocalized = true;
                            //this.appLoadedService.WebRoot.TVFileModelList[i].ErrorLocalizing = false;
                        }
                    }
                }
                break;
            case WebTypeEnum.WebSector:
                {
                    for (let i = 0, count = this.appLoadedService.WebSector.TVFileModelList.length; i < count; i++) {
                        let ServerFileName = this.appLoadedService.WebSector.TVFileModelList[i].TVFile.ServerFileName;

                        let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                        if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0) {
                            this.appLoadedService.WebSector.TVFileModelList[i].IsLocalized = true;
                            //this.appLoadedService.WebSector.TVFileModelList[i].ErrorLocalizing = false;
                        }
                    }
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    for (let i = 0, count = this.appLoadedService.WebSubsector.TVFileModelList.length; i < count; i++) {
                        let ServerFileName = this.appLoadedService.WebSubsector.TVFileModelList[i].TVFile.ServerFileName;

                        let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                        if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0) {
                            this.appLoadedService.WebSubsector.TVFileModelList[i].IsLocalized = true;
                            //this.appLoadedService.WebSubsector.TVFileModelList[i].ErrorLocalizing = false;
                        }
                    }

                    for (let i = 0, countI = this.appLoadedService.WebMWQMSites.MWQMSiteModelList.length; i < countI; i++) {
                        for (let j = 0, countJ = this.appLoadedService.WebMWQMSites.MWQMSiteModelList.length; j < countJ; j++) {
                            let ServerFileName = this.appLoadedService.WebMWQMSites.MWQMSiteModelList[i].TVFileModelList[j].TVFile.ServerFileName;

                            let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                            if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0) {
                                this.appLoadedService.WebMWQMSites.MWQMSiteModelList[i].TVFileModelList[j].IsLocalized = true;
                                //this.appLoadedService.WebMWQMSites.MWQMSiteModelList[i].TVFileModelList[j].ErrorLocalizing = false;
                            }
                        }
                    }

                    for (let i = 0, countI = this.appLoadedService.WebPolSourceSites.PolSourceSiteModelList.length; i < countI; i++) {
                        for (let j = 0, countJ = this.appLoadedService.WebPolSourceSites.PolSourceSiteModelList.length; j < countJ; j++) {
                            let ServerFileName = this.appLoadedService.WebPolSourceSites.PolSourceSiteModelList[i].TVFileModelList[j].TVFile.ServerFileName;

                            let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                            if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0) {
                                this.appLoadedService.WebPolSourceSites.PolSourceSiteModelList[i].TVFileModelList[j].IsLocalized = true;
                                //this.appLoadedService.WebPolSourceSites.PolSourceSiteModelList[i].TVFileModelList[j].ErrorLocalizing = false;
                            }
                        }
                    }

                }
                break;
            default:
                break;
        }
    }
}