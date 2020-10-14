import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { BreadCrumbVar } from './bread-crumb.models';

@Injectable({
  providedIn: 'root'
})
export class BreadCrumbService {
  BreadCrumbVar$: BehaviorSubject<BreadCrumbVar> = new BehaviorSubject<BreadCrumbVar>(<BreadCrumbVar>{});

  constructor() {
    this.UpdateBreadCrumbVar(<BreadCrumbVar>{});
  }

  UpdateBreadCrumbVar(breadCrumbVar: BreadCrumbVar) {
    this.BreadCrumbVar$.next(<BreadCrumbVar>{ ...this.BreadCrumbVar$.getValue(), ...breadCrumbVar });
  }

}
