import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ShellModel, ShellService } from 'src/app/pages/shell';
import { SideNavMenuTextModel } from './sidenav-menu.models';

@Injectable({
  providedIn: 'root'
})
export class SideNavMenuService {
  SideNavMenuTextModel$: BehaviorSubject<SideNavMenuTextModel> = new BehaviorSubject<SideNavMenuTextModel>(<SideNavMenuTextModel>{});

  constructor(private shellService: ShellService) {
    this.UpdateSideNavMenuText(<SideNavMenuTextModel>{});
  }

  UpdateSideNavMenuText(SideNavMenuTextModel: SideNavMenuTextModel) {
    this.SideNavMenuTextModel$.next(<SideNavMenuTextModel>{ ...this.SideNavMenuTextModel$.getValue(), ...SideNavMenuTextModel });
  }
}
