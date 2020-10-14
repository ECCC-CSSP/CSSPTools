import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppService } from '../../app.service';
import { AppVar } from '../../app.model';
import { TVFileModel } from '../../models/generated/TVFileModel.model';

@Component({
  selector: 'app-file-list-item-detail',
  templateUrl: './file-list-item-detail.component.html',
  styleUrls: ['./file-list-item-detail.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FileListItemDetailComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel = null;
  @Input() AppVar: AppVar;
  
  constructor(public appService: AppService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }


}
