import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetTopComponentEnum } from './enums/generated/TopComponentEnum';
import { AppLoadedService } from './services/app-loaded.service';
import { AppStateService } from './services/app-state.service';
import { LoggedInContactService } from './services/loaders/logged-in-contact.service';
import { WebContactService } from './services/loaders/web-contact.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent implements OnInit, OnDestroy {
  subWebContact: Subscription;
  subLoggedInContact: Subscription;
  
  topComponentEnum = GetTopComponentEnum();

  constructor(
    public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public webContactService: WebContactService,
    public loggedInContactService: LoggedInContactService) {
  }

  ngOnInit() {
    this.subWebContact = this.webContactService.GetWebContact().subscribe();
    this.subLoggedInContact = this.loggedInContactService.GetLoggedInContact().subscribe();
  }

  ngOnDestroy() {
    this.subWebContact != null ? this.subWebContact.unsubscribe() : null;
    this.subLoggedInContact != null ? this.subLoggedInContact.unsubscribe() : null;
  }
}

