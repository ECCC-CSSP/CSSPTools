import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { TVFileModel } from '../../models/generated/TVFileModel.model';
import { ShellService } from '../../pages/shell';

@Component({
  selector: 'app-file-list-item-detail',
  templateUrl: './file-list-item-detail.component.html',
  styleUrls: ['./file-list-item-detail.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FileListItemDetailComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel = null;
  
  constructor(public shellService: ShellService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }


}
