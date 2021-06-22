import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { BoxModelResultTypeEnum } from 'src/app/enums/generated/BoxModelResultTypeEnum';
import { BoxModelModel } from 'src/app/models/generated/web/BoxModelModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-box-model-item-result',
  templateUrl: './box-model-item-result.component.html',
  styleUrls: ['./box-model-item-result.component.css']
})
export class BoxModelItemResultComponent implements OnInit, OnDestroy {
  @Input() BoxModelModel: BoxModelModel;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }
  
  GetTextOfBoxModelResultType(boxModelResultType: BoxModelResultTypeEnum) {
    switch (boxModelResultType) {
      case BoxModelResultTypeEnum.Dilution:
        {
          return this.appLanguageService.Dilution[this.appLanguageService.LangID];
        }
      case BoxModelResultTypeEnum.NoDecayUntreated:
        {
          return this.appLanguageService.NoDecayUntreated[this.appLanguageService.LangID];
        }
      case BoxModelResultTypeEnum.NoDecayPreDisinfection:
        {
          return this.appLanguageService.NoDecayPreDisinfection[this.appLanguageService.LangID];
        }
      case BoxModelResultTypeEnum.DecayUntreated:
        {
          return this.appLanguageService.DecayUntreated[this.appLanguageService.LangID];
        }
      case BoxModelResultTypeEnum.DecayPreDisinfection:
        {
          return this.appLanguageService.DecayPreDisinfection[this.appLanguageService.LangID];
        }
      default:
        break;
    }
  }

}
