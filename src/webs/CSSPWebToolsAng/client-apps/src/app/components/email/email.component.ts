import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { GetEmailTypeEnum } from 'src/app/enums/generated/EmailTypeEnum';
import { EmailService } from 'src/app/services/email/email.service';
import { Email } from 'src/app/models/generated/db/Email.model';

@Component({
  selector: 'app-email',
  templateUrl: './email.component.html',
  styleUrls: ['./email.component.css']
})
export class EmailComponent implements OnInit, OnDestroy {
  @Input() TVItemID: number;

  email: Email;

  emailType = GetEmailTypeEnum();
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public emailService: EmailService) {
  }

  ngOnInit() {
    this.email = this.emailService.GetEmail(this.TVItemID);
  }

  ngOnDestroy() {
  }
}
