import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css']
})
export class ErrorComponent implements OnInit, OnDestroy {
  @Input() Error: HttpErrorResponse;

  InnerErrorMessageVisible: boolean = false;

  constructor(private appStateService: AppStateService) {
  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

  ClearErrorMessage() {
    this.appStateService.Error = null;
  }

  ToggleInnerErrorMessageVisibility()
  {
    this.InnerErrorMessageVisible = !this.InnerErrorMessageVisible;
  }
}
