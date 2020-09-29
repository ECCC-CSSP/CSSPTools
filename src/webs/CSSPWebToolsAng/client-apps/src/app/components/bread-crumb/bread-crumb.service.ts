import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { BreadCrumbTextModel } from './bread-crumb.models';

@Injectable({
  providedIn: 'root'
})
export class BreadCrumbService {
  BreadCrumbTextModel$: BehaviorSubject<BreadCrumbTextModel> = new BehaviorSubject<BreadCrumbTextModel>(<BreadCrumbTextModel>{});

  constructor() {
    this.UpdateBreadCrumbText(<BreadCrumbTextModel>{});
  }

  UpdateBreadCrumbText(breadCrumbTextModel: BreadCrumbTextModel) {
    this.BreadCrumbTextModel$.next(<BreadCrumbTextModel>{ ...this.BreadCrumbTextModel$.getValue(), ...breadCrumbTextModel });
  }

}
