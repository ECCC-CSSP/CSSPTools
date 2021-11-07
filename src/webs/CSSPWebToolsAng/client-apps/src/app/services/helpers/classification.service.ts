import { Injectable } from '@angular/core';
import { AppLanguageService } from '../app/app-language.service';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { ClassificationModel } from 'src/app/models/generated/web/ClassificationModel.model';

@Injectable({
    providedIn: 'root'
})
export class ClassificationService {
    constructor(private appLanguageService: AppLanguageService) {
    }

    GetClassificationTVItemModelList(classificationModelList: ClassificationModel[]): TVItemModel[] {
        let language: number = <number>this.appLanguageService.Language;

        if (!classificationModelList || classificationModelList?.length == 0) return <TVItemModel[]>[];

        let tvItemModelList: TVItemModel[] = [];

        for (let i = 0; i < classificationModelList?.length; i++) {
            tvItemModelList.push(classificationModelList[i].TVItemModel);
        }

        return tvItemModelList;
    }
}
