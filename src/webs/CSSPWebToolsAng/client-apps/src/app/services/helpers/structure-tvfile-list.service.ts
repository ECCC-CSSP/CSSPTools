import { Injectable } from '@angular/core';
import { AppStateService } from 'src/app/services/app-state.service';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { PredicateAscByService } from 'src/app/services/helpers/predicate-asc-by.service';
import { TVFileID_ServerFileName_Sort } from 'src/app/models/TVFileID_ServerFileName_Sort.model';
import { FilePurposeEnum_GetOrderedText } from 'src/app/enums/generated/FilePurposeEnum';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';

@Injectable({
  providedIn: 'root'
})
export class StructureTVFileListService {
  constructor(private appStateService: AppStateService,
    private predicateAscByService: PredicateAscByService) {
  }

  StructureTVFileList(TVFileModelList: TVFileModel[]): TVFileModel[][] {
    if (!TVFileModelList) return [[]];

    let tvFileModelListList: TVFileModel[][] = [[]];

    let arrFile2: TVFileID_ServerFileName_Sort[] = [];
    let sortable: TVFileID_ServerFileName_Sort[] = [];

    let enumIDAndTextList: EnumIDAndText[] = FilePurposeEnum_GetOrderedText(this.appStateService);

    for (let i = 0; i < enumIDAndTextList.length; i++) {
      let tvFileModelList: TVFileModel[] = [];
      let tvFileModelSortedList: TVFileModel[] = [];
      for (let j = 0; j < TVFileModelList.length; j++) {
        if (enumIDAndTextList[i].EnumID == TVFileModelList[j].TVFile.FilePurpose) {
          tvFileModelList.push(TVFileModelList[j]);
        }
      }
      if (tvFileModelList.length > 0) {

        for (let k = 0; k < tvFileModelList.length; k++) {
          sortable.push(<TVFileID_ServerFileName_Sort>{
            TVFileID: tvFileModelList[k].TVFile.TVFileID,
            ServerFileName: tvFileModelList[k].TVFile.ServerFileName.toLowerCase(),
          });
        }

        arrFile2 = sortable.sort(this.predicateAscByService.PredicateAscBy('ServerFileName'));

        for (let k = 0; k < sortable.length; k++) {
          for (let l = 0; l < tvFileModelList.length; l++) {
            if (arrFile2[k].TVFileID == tvFileModelList[l].TVFile.TVFileID) {
              tvFileModelSortedList.push(tvFileModelList[l]);
              break;
            }
          }
        }
    
        tvFileModelListList.push(tvFileModelSortedList);
      }
    }

    return tvFileModelListList;
  }
}
