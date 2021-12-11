import { Injectable } from '@angular/core';
import { MWQMRunModel } from 'src/app/models/generated/models/MWQMRunModel.model';
import { AppLanguageService } from '../app/app-language.service';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';

@Injectable({
    providedIn: 'root'
})
export class MWQMRunService {
    constructor(private appLanguageService: AppLanguageService) {
    }

    GetMWQMRunTVItemModelList(mwqmRunModelList: MWQMRunModel[]): TVItemModel[] {
        let language: number = <number>this.appLanguageService.Language;

        if (!mwqmRunModelList || mwqmRunModelList?.length == 0) return <TVItemModel[]>[];

        let tvItemModelList: TVItemModel[] = [];

        for (let i = 0, count = mwqmRunModelList?.length; i < count; i++) {
            tvItemModelList.push(mwqmRunModelList[i].TVItemModel);
        }

        return tvItemModelList;
    }
}
