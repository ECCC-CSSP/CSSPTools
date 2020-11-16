import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppState } from 'src/app/models/AppState.model';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ErrorComponent implements OnInit, OnDestroy {
  @Input() Error: HttpErrorResponse;

  constructor(private appStateService: AppStateService) {
  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

  ClearErrorMessage() {
    this.appStateService.UpdateAppState(<AppState>{ Error: null });
  }
}
