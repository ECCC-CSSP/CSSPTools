import { Injectable } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
    providedIn: 'root'
})
export class ShowItemForEditService {
    constructor(private appStateService: AppStateService) {

    }

    ToggleShowTVItemForEdit(tvItemModel: TVItemModel): void {
        if (this.TVItemModelForEditVisible(tvItemModel)) {
            this.RemoveShowItemForEdit(tvItemModel);
        }
        else {
            this.AddShowItemForEdit(tvItemModel);
        }
    }

    TVItemModelForEditVisible(tvItemModel: TVItemModel): boolean {
        let tvItemModelExist: TVItemModel[] = this.appStateService.AppState$.getValue().ShowEditTVItemModelList.filter(c => c == tvItemModel);
        if ((tvItemModelExist != undefined && tvItemModelExist.length > 0)) {
            return true;
        }

        return false;
    }

    AddShowItemForEdit(tvItemModel: TVItemModel): void {
        let tvItemModelExist: TVItemModel[] = this.appStateService.AppState$.getValue().ShowEditTVItemModelList.filter(c => c.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);
        if (!(tvItemModelExist != undefined && tvItemModelExist.length > 0)) {
            this.appStateService.AppState$.getValue().ShowEditTVItemModelList.push(tvItemModel);
        }
    }

    RemoveShowItemForEdit(tvItemModel: TVItemModel): void {
        let tvItemModelExist: TVItemModel[] = this.appStateService.AppState$.getValue().ShowEditTVItemModelList.filter(c => c == tvItemModel);
        if ((tvItemModelExist != undefined && tvItemModelExist.length > 0)) {
            let ShowNewEditTVItemModelList: TVItemModel[] = this.appStateService.AppState$.getValue().ShowEditTVItemModelList;
            let count: number = ShowNewEditTVItemModelList.length;
            for (let i = 0; i < count; i++) {
                if (ShowNewEditTVItemModelList[i] === tvItemModel) {
                    ShowNewEditTVItemModelList.splice(i, 1);
                    break;
                }
            }

            this.appStateService.UpdateAppState(<AppState>{ ShowEditTVItemModelList: ShowNewEditTVItemModelList });
        }
    }

}
