import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { TelModel } from 'src/app/models/generated/web/TelModel.model';
import { GetTelTypeEnum } from 'src/app/enums/generated/TelTypeEnum';
import { TelService } from 'src/app/services/tel/tel.service';

@Component({
  selector: 'app-tel',
  templateUrl: './tel.component.html',
  styleUrls: ['./tel.component.css']
})
export class TelComponent implements OnInit, OnDestroy {
  @Input() TVItemID: number;

  telModel: TelModel;

  telType = GetTelTypeEnum();
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public telService: TelService) {
  }

  ngOnInit() {
    this.telModel = this.telService.GetTelModel(this.TVItemID);
  }

  ngOnDestroy() {
  }
}
