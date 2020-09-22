import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { LanguageEnum } from '../grouping';
import { ShellModel } from './shell.models';

@Injectable({
  providedIn: 'root'
})
export class ShellService {
  shellModel$: BehaviorSubject<ShellModel> = new BehaviorSubject<ShellModel>(<ShellModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateShell(<ShellModel>{ Language: $localize.locale == "fr-CA" ? LanguageEnum.fr : LanguageEnum.en });
   }


  UpdateShell(shellModel: ShellModel)
  {
    this.shellModel$.next(<ShellModel>{...this.shellModel$.getValue(), ...shellModel});
  }
}
