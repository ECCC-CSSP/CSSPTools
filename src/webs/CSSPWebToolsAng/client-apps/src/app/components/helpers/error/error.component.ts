import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLoaded } from 'src/app/models/AppLoaded.model';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ErrorComponent implements OnInit, OnDestroy {
  @Input() Error: HttpErrorResponse;

  constructor(private appLoadedService: AppLoadedService) {
  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

  ClearErrorMessage() {
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Error: null });
  }
}
