import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-log-book-item',
  templateUrl: './log-book-item.component.html',
  styleUrls: ['./log-book-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LogBookItemComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
