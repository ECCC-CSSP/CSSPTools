import { Injectable } from '@angular/core';
import { TVTypeEnum_GetIDText } from 'src/app/enums/generated/TVTypeEnum';
import { AppStateService } from '../app-state.service';

@Injectable({
  providedIn: 'root'
})
export class TypeTextService {

  constructor(private appStateService: AppStateService) {
  }

  GetTypeText(tvType: number) {
    return TVTypeEnum_GetIDText(tvType, this.appStateService);
  }
}
