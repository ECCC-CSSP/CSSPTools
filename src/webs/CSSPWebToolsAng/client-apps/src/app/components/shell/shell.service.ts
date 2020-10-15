import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ShellVar } from '.';

@Injectable({
  providedIn: 'root'
})
export class ShellService {
  ShellVar$: BehaviorSubject<ShellVar> = new BehaviorSubject<ShellVar>(<ShellVar>{});

  constructor() {
  }

  UpdateShellVar(shellVar: ShellVar) {
    this.ShellVar$.next(<ShellVar>{ ...this.ShellVar$.getValue(), ...shellVar });
  }
}
