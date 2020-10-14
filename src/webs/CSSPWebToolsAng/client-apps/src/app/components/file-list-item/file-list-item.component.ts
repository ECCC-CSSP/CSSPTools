import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppService } from 'src/app/app.service';
import { AppVar } from 'src/app/app.model';
import { TVFileModel } from '../../models/generated/TVFileModel.model';

@Component({
  selector: 'app-file-list-item',
  templateUrl: './file-list-item.component.html',
  styleUrls: ['./file-list-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FileListItemComponent implements OnInit, OnDestroy {
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
