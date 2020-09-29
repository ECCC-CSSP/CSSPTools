import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { ChildCountTextModel } from './child-count.models';

@Injectable({
  providedIn: 'root'
})
export class ChildCountService {
  ChildCountTextModel$: BehaviorSubject<ChildCountTextModel> = new BehaviorSubject<ChildCountTextModel>(<ChildCountTextModel>{});

  constructor() {
    this.UpdateChildCountText(<ChildCountTextModel>{});
  }

  UpdateChildCountText(childCountTextModel: ChildCountTextModel) {
    this.ChildCountTextModel$.next(<ChildCountTextModel>{ ...this.ChildCountTextModel$.getValue(), ...childCountTextModel });
  }

}
