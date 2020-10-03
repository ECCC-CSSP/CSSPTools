import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { ShellModel } from 'src/app/pages/shell';
import { TVFileModel } from '../../models/generated/TVFileModel.model';

@Component({
  selector: 'app-file-list',
  templateUrl: './file-list.component.html',
  styleUrls: ['./file-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FileListComponent implements OnInit, OnDestroy {
  @Input() TVFileModelList: TVFileModel[];
  @Input() ShellModel: ShellModel;

  constructor() {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }
}
