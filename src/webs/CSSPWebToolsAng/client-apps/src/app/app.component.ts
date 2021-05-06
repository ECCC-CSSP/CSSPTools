import { Component, OnInit, OnDestroy } from '@angular/core';
import { GetTopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { AppLanguageService } from './services/app-language.service';
import { AppLoadedService } from './services/app-loaded.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit, OnDestroy {
  topComponentEnum = GetTopComponentEnum();
    
  constructor(
    public loggedInContactService: LoggedInContactService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    ) {
  }

  ngOnInit() {
    this.loggedInContactService.DoLoggedInContact(true);
  }

  ngOnDestroy() {
  }
}

