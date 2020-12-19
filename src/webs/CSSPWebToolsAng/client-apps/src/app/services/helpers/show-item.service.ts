import { Injectable } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
    providedIn: 'root'
})
export class ShowItemService {
    constructor(private appStateService: AppStateService) {

    }

    ToggleShowTVItemModel(tvItemModel: TVItemModel): void {
        if (this.TVItemModelVisible(tvItemModel)) {
            this.RemoveShowItem(tvItemModel);
        }
        else {
            this.AddShowItem(tvItemModel);
        }
    }

    TVItemModelVisible(tvItemModel: TVItemModel): boolean {
        let tvItemModelExist: TVItemModel[] = this.appStateService.AppState$.getValue().ShowTVItemModelList.filter(c => c == tvItemModel);
        if (tvItemModelExist != undefined && tvItemModelExist.length > 0) {
            return true;
        }

        return false;
    }

    AddShowItem(tvItemModel: TVItemModel): void {
        let tvItemModelExist: TVItemModel[] = this.appStateService.AppState$.getValue().ShowTVItemModelList.filter(c => c.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);
        if (!(tvItemModelExist != undefined && tvItemModelExist.length > 0)) {
            this.appStateService.AppState$.getValue().ShowTVItemModelList.push(tvItemModel);
        }
    }

    RemoveShowItem(tvItemModel: TVItemModel): void {
        let tvItemModelExist: TVItemModel[] = this.appStateService.AppState$.getValue().ShowTVItemModelList.filter(c => c == tvItemModel);
        if ((tvItemModelExist != undefined && tvItemModelExist.length > 0)) {
            let ShowNewTVItemModelList: TVItemModel[] = this.appStateService.AppState$.getValue().ShowTVItemModelList;
            let count: number = ShowNewTVItemModelList.length;
            for (let i = 0; i < count; i++) {
                if (ShowNewTVItemModelList[i] === tvItemModel) {
                    ShowNewTVItemModelList.splice(i, 1);
                    break;
                }
            }

            this.appStateService.UpdateAppState(<AppState>{ ShowTVItemModelList: ShowNewTVItemModelList });
        }
    }

}
