import { Injectable } from '@angular/core';
import { TVTypeEnum_GetIDText } from 'src/app/enums/generated/TVTypeEnum';
import { AppLanguageService } from '../app-language.service';

@Injectable({
  providedIn: 'root'
})
export class TypeTextService {

  constructor(private appLanguageService: AppLanguageService) {
  }

  GetTypeText(tvType: number) {
    return TVTypeEnum_GetIDText(tvType, this.appLanguageService);
  }
}
