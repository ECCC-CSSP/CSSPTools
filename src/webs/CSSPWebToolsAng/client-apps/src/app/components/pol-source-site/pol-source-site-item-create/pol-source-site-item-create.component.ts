import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-pol-source-site-item-create',
  templateUrl: './pol-source-site-item-create.component.html',
  styleUrls: ['./pol-source-site-item-create.component.css']
})
export class PolSourceSiteItemCreateComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
