import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetTopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { WebAllContactsService } from 'src/app/services/loaders/web-all-contacts.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent implements OnInit, OnDestroy {
  topComponentEnum = GetTopComponentEnum();

  constructor(
    public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public webAllContactsService: WebAllContactsService,
    public loggedInContactService: LoggedInContactService) {
  }

  ngOnInit() {
    this.loggedInContactService.DoLoggedInContact();
    this.webAllContactsService.DoWebAllContacts(false);
  }

  ngOnDestroy() {
  }
}

