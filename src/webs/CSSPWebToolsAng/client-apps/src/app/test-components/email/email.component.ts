/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { EmailService } from './email.service';
import { LoadLocalesEmailText } from './email.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { EmailTypeEnum_GetIDText } from 'src/app/enums/generated/EmailTypeEnum';

@Component({
  selector: 'app-email',
  templateUrl: './email.component.html',
  styleUrls: ['./email.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmailComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public emailService: EmailService, public router: Router) { }

  GetEmail() {
    this.sub = this.emailService.GetEmail(this.router).subscribe();
  }

  GetEmailTypeEnumText(enumID: number) {
    return EmailTypeEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesEmailText(this.emailService);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
