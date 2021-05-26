import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';

@Component({
  selector: 'app-mwqm-site-item-modify',
  templateUrl: './mwqm-site-item-modify.component.html',
  styleUrls: ['./mwqm-site-item-modify.component.css']
})
export class MWQMSiteItemModifyComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;


  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public loaderService: LoaderService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
