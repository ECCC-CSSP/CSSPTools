import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVItemModelInfrastructureModel } from 'src/app/models/generated/web/TVItemModelInfrastructureModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-municipality-tvitem-list-item',
  templateUrl: './municipality-tvitem-list-item.component.html',
  styleUrls: ['./municipality-tvitem-list-item.component.css']
})
export class MunicipalityTVItemListItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModelInfrastructureModel: TVItemModelInfrastructureModel;

  HasInfOpt: boolean[] = [true, false];

  languageEnum = GetLanguageEnum();

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public subPageService: SubPageService,
    public mapService: MapService,
    public showTVItemService: ShowTVItemService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
