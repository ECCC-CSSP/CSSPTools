import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { VPScenarioModel } from 'src/app/models/generated/models/VPScenarioModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppTextService } from 'src/app/services/helpers/app-text.service';

@Component({
  selector: 'app-visual-plumes-item',
  templateUrl: './visual-plumes-item.component.html',
  styleUrls: ['./visual-plumes-item.component.css']
})
export class VisualPlumesItemComponent implements OnInit, OnDestroy {
  @Input() VPScenarioModel: VPScenarioModel;

  VPScenarioVisible: boolean = false;

  ShowInputDiffuser: boolean = true;
  ShowInputAmbient: boolean = false;
  ShowResults: boolean = false;
  ShowResultsRaw: boolean = false;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public appTextService: AppTextService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

  GetResultAsPre(vpScenarioModel: VPScenarioModel): string {
    let rowList: string[] = [];
    rowList.push(`     Conc.      Dil.     Dist.     Width      Time`);
    for (let i = 0, count = vpScenarioModel.VPResultList.length; i < count; i++) {
      let conc: string = this.appTextService.pad(vpScenarioModel.VPResultList[i].Concentration_MPN_100ml, 10, ' ');
      let dil: string = this.appTextService.pad(vpScenarioModel.VPResultList[i].Dilution, 10, ' ');
      let dist: string = this.appTextService.pad(vpScenarioModel.VPResultList[i].DispersionDistance_m, 10, ' ');
      let width: string = this.appTextService.pad(vpScenarioModel.VPResultList[i].FarFieldWidth_m, 10, ' ');
      let time: string = this.appTextService.pad(vpScenarioModel.VPResultList[i].TravelTime_hour, 10, ' ');
      rowList.push(`${conc}${dil}${dist}${width}${time}`);
    }

    return rowList.join('\r\n');
  }
}
