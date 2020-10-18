import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { TVFileModel } from '../../models/generated/TVFileModel.model';
import { AppState } from 'src/app/models/AppState.model';

@Component({
  selector: 'app-file-list-item',
  templateUrl: './file-list-item.component.html',
  styleUrls: ['./file-list-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FileListItemComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel = null;
  @Input() AppState: AppState;
  
  constructor() {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }


}
