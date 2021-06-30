import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { count } from 'rxjs/operators';
import { AlarmSystemTypeEnum_GetIDText, GetAlarmSystemTypeEnum } from 'src/app/enums/generated/AlarmSystemTypeEnum';
import { GetInfrastructureTypeEnum, InfrastructureTypeEnum } from 'src/app/enums/generated/InfrastructureTypeEnum';
import { InfrastructureModelPath } from 'src/app/models/generated/web/InfrastructureModelPath.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';

@Component({
  selector: 'app-infrastructure-item',
  templateUrl: './infrastructure-item.component.html',
  styleUrls: ['./infrastructure-item.component.css']
})
export class InfrastructureItemComponent implements OnInit, OnDestroy {
  @Input() InfrastructureModelPath: InfrastructureModelPath;
  @Input() Level: number;

  counter: number[] = [];

  alarmSystemType = GetAlarmSystemTypeEnum();
  infrastructureType = GetInfrastructureTypeEnum();

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public showTVItemService: ShowTVItemService) { }

  ngOnInit(): void {
    for (let i = 0, count = this.Level; i < count; i++) {
      this.counter.push(1);
    }
  }

  ngOnDestroy(): void {
  }

  GetBorderColor(infrastructureTypeToCheck?: InfrastructureTypeEnum) {
    let infrastructureType = GetInfrastructureTypeEnum();

    switch (infrastructureTypeToCheck) {
      case infrastructureType.WWTP:
        {
          return 'BorderWWTP';
        }
      case infrastructureType.LiftStation:
        {
          return 'BorderLiftStation';
        }
      case infrastructureType.LineOverflow:
        {
          return 'BorderLineOverflow';
        }
      case infrastructureType.Other:
      case infrastructureType.SeeOtherMunicipality:
        {
          return 'BorderOtherInfrastructure';
        }
      default:
        {
          return 'BorderOtherInfrastructure';
        }
    }
  }

  GetHasAlarmSystem(infrastructureModelPath: InfrastructureModelPath): boolean {

    if (infrastructureModelPath.InfrastructureModel.Infrastructure.AlarmSystemType == null) {
      return false;
    }
    if (infrastructureModelPath.InfrastructureModel.Infrastructure.AlarmSystemType == this.alarmSystemType.None) {
      return false;
    }

    return true;
  }

  GetAlarmSystemTypeText(infrastructureModelPath: InfrastructureModelPath): string {
    return AlarmSystemTypeEnum_GetIDText(infrastructureModelPath.InfrastructureModel.Infrastructure.AlarmSystemType, this.appLanguageService);
  }


  GetCanOverflow(infrastructureModelPath: InfrastructureModelPath): boolean {
    if (infrastructureModelPath.InfrastructureModel.TVItemModel.TVItem.TVItemID == 28707)
    {
      let a = 23;
    }
    if (infrastructureModelPath.InfrastructureModel.Infrastructure.CanOverflow == null
      || infrastructureModelPath.InfrastructureModel.Infrastructure.CanOverflow == true) {
      return true;
    }

    return false;
  }

  GetIsNotOtherOrSeeOther(infrastructureModelPath: InfrastructureModelPath) {
    if (infrastructureModelPath.InfrastructureModel.Infrastructure.InfrastructureType == null
      || infrastructureModelPath.InfrastructureModel.Infrastructure.InfrastructureType == this.infrastructureType.Other
      || infrastructureModelPath.InfrastructureModel.Infrastructure.InfrastructureType == this.infrastructureType.SeeOtherMunicipality) {
      return false;
    }

    return true;
  }
}
