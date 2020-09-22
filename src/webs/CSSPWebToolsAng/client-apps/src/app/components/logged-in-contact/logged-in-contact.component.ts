import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { LoggedInContactService } from './logged-in-contact.service';

@Component({
  selector: 'app-logged-in-contact',
  templateUrl: './logged-in-contact.component.html',
  styleUrls: ['./logged-in-contact.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoggedInContactComponent implements OnInit, OnDestroy {
  sub: Subscription;
  
  constructor(public loggedInContactService: LoggedInContactService) {
  }

  ngOnInit() {
    this.sub = this.loggedInContactService.GetLoggedInContact().subscribe();
  }

  ngOnDestroy()
  {
    if(this.sub)
    {
      this.sub.unsubscribe();
    }
  }
}
