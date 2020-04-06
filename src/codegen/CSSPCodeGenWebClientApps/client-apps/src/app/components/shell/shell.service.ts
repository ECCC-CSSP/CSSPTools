import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ShellModel } from './shell.models';

@Injectable({
  providedIn: 'root'
})
export class ShellService {
  shellModel$: BehaviorSubject<ShellModel> = new BehaviorSubject<ShellModel>(<ShellModel>{});

  constructor() {
    this.UpdateShell(<ShellModel>{ isEnglish: true, leftIconsVisible: true });
   }

  UpdateShell(shellModel: ShellModel)
  {
    this.shellModel$.next(<ShellModel>{...this.shellModel$.getValue(), ...shellModel});
  }
}
