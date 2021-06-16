import { Injectable } from '@angular/core';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { JsonDoUpdateBreadCrumbOnlyService, JsonDoUpdateWebMapService } from '.';
import { AppLoadedService } from '../app/app-loaded.service';
import { HistoryService } from '../helpers/history.service';
import { StatService } from '../helpers/stat.service';
import { LocalFileInfo } from 'src/app/models/generated/web/LocalFileInfo.model';

@Injectable({
    providedIn: 'root'
})
export class JsonDoUpdateLocalFileInfoSwitchService {

    constructor(private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private statService: StatService,
        private historyService: HistoryService,
        private jsonDoUpdateBreadCrumbOnlyService: JsonDoUpdateBreadCrumbOnlyService,
        private jsonDoUpdateWebMapService: JsonDoUpdateWebMapService) {
    }


    DoUpdateLocalFileInfoSwitch(WebType: WebTypeEnum, LocalFileInfoList: LocalFileInfo[]) {
        switch (WebType) {
            case WebTypeEnum.WebArea:
                {
                    for(let i = 0, count = this.appLoadedService.WebArea.TVFileModelList.length; i < count; i++)
                    {
                        let ServerFileName = this.appLoadedService.WebArea.TVFileModelList[i].TVFile.ServerFileName;

                        let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                        if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0)
                        {
                            this.appLoadedService.WebArea.TVFileModelList[i].IsLocalized = true;
                        }
                    }
                }
                break;
            case WebTypeEnum.WebCountry:
                {
                    for(let i = 0, count = this.appLoadedService.WebCountry.TVFileModelList.length; i < count; i++)
                    {
                        let ServerFileName = this.appLoadedService.WebCountry.TVFileModelList[i].TVFile.ServerFileName;

                        let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                        if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0)
                        {
                            this.appLoadedService.WebCountry.TVFileModelList[i].IsLocalized = true;
                        }
                    }
                }
                break;
            case WebTypeEnum.WebMunicipality:
                {
                    for(let i = 0, count = this.appLoadedService.WebMunicipality.TVFileModelList.length; i < count; i++)
                    {
                        let ServerFileName = this.appLoadedService.WebMunicipality.TVFileModelList[i].TVFile.ServerFileName;

                        let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                        if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0)
                        {
                            this.appLoadedService.WebMunicipality.TVFileModelList[i].IsLocalized = true;
                        }
                    }
                }
                break;
            case WebTypeEnum.WebProvince:
                {
                    for(let i = 0, count = this.appLoadedService.WebProvince.TVFileModelList.length; i < count; i++)
                    {
                        let ServerFileName = this.appLoadedService.WebProvince.TVFileModelList[i].TVFile.ServerFileName;

                        let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                        if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0)
                        {
                            this.appLoadedService.WebProvince.TVFileModelList[i].IsLocalized = true;
                        }
                    }
                }
                break;
            case WebTypeEnum.WebRoot:
                {
                    for(let i = 0, count = this.appLoadedService.WebRoot.TVFileModelList.length; i < count; i++)
                    {
                        let ServerFileName = this.appLoadedService.WebRoot.TVFileModelList[i].TVFile.ServerFileName;

                        let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                        if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0)
                        {
                            this.appLoadedService.WebRoot.TVFileModelList[i].IsLocalized = true;
                        }
                    }
                }
                break;
            case WebTypeEnum.WebSector:
                {
                    for(let i = 0, count = this.appLoadedService.WebSector.TVFileModelList.length; i < count; i++)
                    {
                        let ServerFileName = this.appLoadedService.WebSector.TVFileModelList[i].TVFile.ServerFileName;

                        let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                        if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0)
                        {
                            this.appLoadedService.WebSector.TVFileModelList[i].IsLocalized = true;
                        }
                    }
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    for(let i = 0, count = this.appLoadedService.WebSubsector.TVFileModelList.length; i < count; i++)
                    {
                        let ServerFileName = this.appLoadedService.WebSubsector.TVFileModelList[i].TVFile.ServerFileName;

                        let LocalFileInfoListFound = LocalFileInfoList.filter(c => c.FileName == ServerFileName);
                        if (LocalFileInfoListFound != undefined && LocalFileInfoListFound.length > 0)
                        {
                            this.appLoadedService.WebSubsector.TVFileModelList[i].IsLocalized = true;
                        }
                    }
                }
                break;
            default:
                break;
        }
    }
}