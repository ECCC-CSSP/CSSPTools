import { Component, OnInit, OnDestroy } from '@angular/core';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { TogglesService } from 'src/app/services/helpers/toggles.service';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css']
})
export class ErrorComponent implements OnInit, OnDestroy {
  InnerErrorMessageVisible: boolean = false;

  constructor(public appStateService: AppStateService,
    private toggleService: TogglesService) {
  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

  ClearErrorMessage() {
    this.appStateService.Error = null;
    this.toggleService.ReloadPage();
  }

  ToggleInnerErrorMessageVisibility()
  {
    this.InnerErrorMessageVisible = !this.InnerErrorMessageVisible;
  }
}
