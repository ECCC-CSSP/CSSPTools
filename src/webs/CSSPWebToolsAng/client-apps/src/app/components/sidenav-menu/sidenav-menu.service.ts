import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AppService } from '../../app.service';
import { SideNavMenuTextModel } from './sidenav-menu.models';

@Injectable({
  providedIn: 'root'
})
export class SideNavMenuService {
  SideNavMenuTextModel$: BehaviorSubject<SideNavMenuTextModel> = new BehaviorSubject<SideNavMenuTextModel>(<SideNavMenuTextModel>{});

  constructor(private appService: AppService) {
    this.UpdateSideNavMenuText(<SideNavMenuTextModel>{});
  }

  UpdateSideNavMenuText(SideNavMenuTextModel: SideNavMenuTextModel) {
    this.SideNavMenuTextModel$.next(<SideNavMenuTextModel>{ ...this.SideNavMenuTextModel$.getValue(), ...SideNavMenuTextModel });
  }
}
