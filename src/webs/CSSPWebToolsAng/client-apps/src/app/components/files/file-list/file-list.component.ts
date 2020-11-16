import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { FilePurposeEnum_GetIDText } from 'src/app/enums/generated/FilePurposeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-file-list',
  templateUrl: './file-list.component.html',
  styleUrls: ['./file-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FileListComponent implements OnInit, OnDestroy {
  @Input() TVFileModelListList: TVFileModel[][];
  @Input() AppState: AppState;

  constructor(public appStateService: AppStateService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  GetFilePurposeEnum_GetIDText(filePurposeEnum: number): string {
    return FilePurposeEnum_GetIDText(filePurposeEnum, this.appStateService);
  }
}
