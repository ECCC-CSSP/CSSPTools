import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Subscription } from 'rxjs';
import { Contact } from 'src/app/models/generated/Contact.model';
import { LoggedInContactService } from './logged-in-contact.service';

@Component({
  selector: 'app-logged-in-contact',
  templateUrl: './logged-in-contact.component.html',
  styleUrls: ['./logged-in-contact.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoggedInContactComponent implements OnInit, OnDestroy {
  @Input() LoggedInContact: Contact;

  
  constructor() {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }
}
