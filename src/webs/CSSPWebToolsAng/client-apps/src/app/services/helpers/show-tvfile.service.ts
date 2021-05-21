import { Injectable } from '@angular/core';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
    providedIn: 'root'
})
export class ShowTVFileService {
    constructor(private appStateService: AppStateService) {

    }

    ToggleShowTVFile(tvFileModel: TVFileModel): void {
        if (this.TVFileVisible(tvFileModel)) {
            this.RemoveShowTVFile(tvFileModel);
        }
        else {
            this.AddShowTVFile(tvFileModel);
        }
    }

    TVFileVisible(tvFileModel: TVFileModel): boolean {
        let tvFileModelExist: TVFileModel[] = this.appStateService.ShowTVFileModelList.filter(c => c == tvFileModel);
        if (tvFileModelExist != undefined && tvFileModelExist?.length > 0) {
            return true;
        }

        return false;
    }

    private AddShowTVFile(tvFileModel: TVFileModel): void {
        let tvFileModelExist: TVFileModel[] = this.appStateService.ShowTVFileModelList.filter(c => c.TVFile.TVFileID == tvFileModel.TVFile.TVFileID);
        if (!(tvFileModelExist != undefined && tvFileModelExist?.length > 0)) {
            this.appStateService.ShowTVFileModelList.push(tvFileModel);
        }
    }

    private RemoveShowTVFile(tvFileModel: TVFileModel): void {
        let tvFileModelExist: TVFileModel[] = this.appStateService.ShowTVFileModelList.filter(c => c == tvFileModel);
        if ((tvFileModelExist != undefined && tvFileModelExist?.length > 0)) {
            let ShowNewTVFileModelList: TVFileModel[] = this.appStateService.ShowTVFileModelList;
            let count: number = ShowNewTVFileModelList?.length;
            for (let i = 0; i < count; i++) {
                if (ShowNewTVFileModelList[i] === tvFileModel) {
                    ShowNewTVFileModelList.splice(i, 1);
                    break;
                }
            }

            this.appStateService.ShowTVFileModelList = ShowNewTVFileModelList;
        }
    }

}
