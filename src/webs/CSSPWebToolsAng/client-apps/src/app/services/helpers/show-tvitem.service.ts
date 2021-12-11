import { Injectable } from '@angular/core';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Injectable({
    providedIn: 'root'
})
export class ShowTVItemService {
    constructor(private appStateService: AppStateService) {

    }

    ToggleShowTVItem(tvItemModel: TVItemModel): void {
        if (this.TVItemVisible(tvItemModel)) {
            this.RemoveShowTVItem(tvItemModel);
        }
        else {
            this.AddShowTVItem(tvItemModel);
        }
    }

    TVItemVisible(tvItemModel: TVItemModel): boolean {
        let tvItemModelExist: TVItemModel[] = this.appStateService.ShowTVItemModelList.filter(c => c == tvItemModel);
        if (tvItemModelExist != undefined && tvItemModelExist?.length > 0) {
            return true;
        }

        return false;
    }

    private AddShowTVItem(tvItemModel: TVItemModel): void {
        let tvItemModelExist: TVItemModel[] = this.appStateService.ShowTVItemModelList.filter(c => c.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);
        if (!(tvItemModelExist != undefined && tvItemModelExist?.length > 0)) {
            this.appStateService.ShowTVItemModelList.push(tvItemModel);
        }
    }

    private RemoveShowTVItem(tvItemModel: TVItemModel): void {
        let tvItemModelExist: TVItemModel[] = this.appStateService.ShowTVItemModelList.filter(c => c == tvItemModel);
        if ((tvItemModelExist != undefined && tvItemModelExist?.length > 0)) {
            let ShowNewTVItemModelList: TVItemModel[] = this.appStateService.ShowTVItemModelList;
            let count: number = ShowNewTVItemModelList?.length;
            for (let i = 0; i < count; i++) {
                if (ShowNewTVItemModelList[i] === tvItemModel) {
                    ShowNewTVItemModelList.splice(i, 1);
                    break;
                }
            }

            this.appStateService.ShowTVItemModelList = ShowNewTVItemModelList;
        }
    }

}
