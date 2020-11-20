import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetTopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { WebContactService } from 'src/app/services/loaders/web-contact.service';

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
    public webContactService: WebContactService,
    public loggedInContactService: LoggedInContactService) {
  }

  ngOnInit() {
    this.webContactService.DoWebContact(false);
    this.loggedInContactService.DoLoggedInContact();
  }

  ngOnDestroy() {
  }
}

