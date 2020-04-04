import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ShellModel } from './shell.models';

@Injectable({
  providedIn: 'root'
})
export class ShellService {
  shellModel$: BehaviorSubject<ShellModel> = new BehaviorSubject<ShellModel>(<ShellModel>{});

  constructor() {
    this.Init();
   }

  Init()
  {
    this.Update(<ShellModel>{ isEnglish: true, leftIconsVisible: true });
  } 
  Update(shellModel: ShellModel)
  {
    let shellModelTemp: ShellModel = {...this.shellModel$.getValue(), ...shellModel};
    this.shellModel$ = new BehaviorSubject<ShellModel>(shellModelTemp);
  }
}
