import { Injectable } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
    providedIn: 'root'
})
export class HistoryService {
    constructor(private appStateService: AppStateService) {

    }

    AddHistory(tvItemModel: TVItemModel): void {
        let tvItemModelExist: TVItemModel[] = this.appStateService.AppState$.getValue().History.filter(c => c.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);
        if (!(tvItemModelExist != undefined && tvItemModelExist.length > 0))
        {
            this.appStateService.AppState$.getValue().History.push(tvItemModel);
        }
    }

    RemoveHistory(tvItemModel: TVItemModel): void {
        let tvItemModelExist: TVItemModel[] = this.appStateService.AppState$.getValue().History.filter(c => c == tvItemModel);
        if (!(tvItemModelExist != undefined && tvItemModelExist.length > 0))
        {
            let History: TVItemModel[] = this.appStateService.AppState$.getValue().History;
            let count: number = History.length;
            for(let i = 0; i < count; i++)
            {
                if (History[i] === tvItemModel)
                {
                    History.splice(i, 1);
                    break;
                }
            }

            this.appStateService.UpdateAppState(<AppState> { History: History });
        }
    }

}
