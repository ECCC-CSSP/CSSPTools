import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { PolSourceSiteModel } from 'src/app/models/generated/web/PolSourceSiteModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AddressService } from 'src/app/services/address/address.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { PolSourceSiteService } from 'src/app/services/helpers/pol-source-site.service';
import { flattenDiagnosticMessageText } from 'typescript';

@Component({
  selector: 'app-pol-source-site-item-view',
  templateUrl: './pol-source-site-item-view.component.html',
  styleUrls: ['./pol-source-site-item-view.component.css']
})
export class PolSourceSiteItemViewComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  
  InformationVisible: boolean = true;
  FilesVisible: boolean = false;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public polSourceSiteService: PolSourceSiteService,
    public addressService: AddressService
    ) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

  GetFileCount(): number {
    let PolSourceSiteModelList: PolSourceSiteModel[] = this.appLoadedService.WebPolSourceSites.PolSourceSiteModelList.filter(c => c.TVItemModel.TVItem.TVItemID == this.TVItemModel.TVItem.TVItemID);
    if (PolSourceSiteModelList != undefined && PolSourceSiteModelList.length > 0) {
      return PolSourceSiteModelList[0].TVFileModelList.length;
    }

  }
}
