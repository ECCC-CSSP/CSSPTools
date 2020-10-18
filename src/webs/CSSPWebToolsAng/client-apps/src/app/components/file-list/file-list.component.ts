import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { TVFileModel } from '../../models/generated/TVFileModel.model';

@Component({
  selector: 'app-file-list',
  templateUrl: './file-list.component.html',
  styleUrls: ['./file-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FileListComponent implements OnInit, OnDestroy {
  @Input() TVFileModelList: TVFileModel[];
  @Input() AppState: AppState;

  constructor() {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }
}
