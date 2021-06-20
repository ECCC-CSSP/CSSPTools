import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { EmailModel } from 'src/app/models/generated/web/EmailModel.model';
import { GetEmailTypeEnum } from 'src/app/enums/generated/EmailTypeEnum';
import { EmailService } from 'src/app/services/email/email.service';

@Component({
  selector: 'app-email',
  templateUrl: './email.component.html',
  styleUrls: ['./email.component.css']
})
export class EmailComponent implements OnInit, OnDestroy {
  @Input() TVItemID: number;

  emailModel: EmailModel;

  emailType = GetEmailTypeEnum();
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public emailService: EmailService) {
  }

  ngOnInit() {
    this.emailModel = this.emailService.GetEmailModel(this.TVItemID);
  }

  ngOnDestroy() {
  }
}
