import { Injectable } from '@angular/core';
import { MWQMSiteModel } from 'src/app/models/generated/web/MWQMSiteModel.model';
import { AppLanguageService } from '../app/app-language.service';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';

@Injectable({
    providedIn: 'root'
})
export class MWQMSiteService {
    constructor(private appLanguageService: AppLanguageService) {
    }

    GetMWQMSiteTVItemModelList(mwqmSiteModelList: MWQMSiteModel[]): TVItemModel[] {
        let language: number = <number>this.appLanguageService.Language;

        if (!mwqmSiteModelList || mwqmSiteModelList?.length == 0) return <TVItemModel[]>[];

        let tvItemModelList: TVItemModel[] = [];

        for (let i = 0; i < mwqmSiteModelList?.length; i++) {
            tvItemModelList.push(mwqmSiteModelList[i].TVItemModel);
        }

        return tvItemModelList;
    }
}
