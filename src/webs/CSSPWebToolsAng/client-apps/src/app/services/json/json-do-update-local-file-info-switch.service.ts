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
                    let temp = LocalFileInfoList;
                }
                break;
            case WebTypeEnum.WebCountry:
                {
                    let temp = LocalFileInfoList;
                }
                break;
            case WebTypeEnum.WebMunicipality:
                {
                    let temp = LocalFileInfoList;
                }
                break;
            case WebTypeEnum.WebProvince:
                {
                    let temp = LocalFileInfoList;
                }
                break;
            case WebTypeEnum.WebRoot:
                {
                    let temp = LocalFileInfoList;
                }
                break;
            case WebTypeEnum.WebSector:
                {
                    let temp = LocalFileInfoList;
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    let temp = LocalFileInfoList;
                }
                break;
            default:
                break;
        }
    }
}