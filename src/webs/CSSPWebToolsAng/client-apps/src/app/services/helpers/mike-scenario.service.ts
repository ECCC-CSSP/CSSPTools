import { Injectable } from '@angular/core';
import { AppLanguageService } from '../app/app-language.service';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { MikeScenarioModel } from 'src/app/models/generated/web/MikeScenarioModel.model';

@Injectable({
    providedIn: 'root'
})
export class MikeScenarioService {
    constructor(private appLanguageService: AppLanguageService) {
    }

    GetMikeScenarioTVItemModelList(mikeScenarioModelList: MikeScenarioModel[]): TVItemModel[] {
        let language: number = <number>this.appLanguageService.Language;

        if (!mikeScenarioModelList || mikeScenarioModelList?.length == 0) return <TVItemModel[]>[];

        let tvItemModelList: TVItemModel[] = [];

        for (let i = 0, count = mikeScenarioModelList?.length; i < count; i++) {
            tvItemModelList.push(mikeScenarioModelList[i].TVItemModel);
        }

        return tvItemModelList;
    }
}
