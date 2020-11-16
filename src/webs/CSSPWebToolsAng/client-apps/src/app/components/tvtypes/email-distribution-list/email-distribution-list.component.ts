import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-email-distribution-list',
  templateUrl: './email-distribution-list.component.html',
  styleUrls: ['./email-distribution-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmailDistributionListComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
