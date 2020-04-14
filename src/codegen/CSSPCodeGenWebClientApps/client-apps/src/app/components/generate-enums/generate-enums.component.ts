import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { GenerateEnumsService } from './generate-enums.service';
import { LoadLocalesEnums } from './generate-enums.locales';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-enums',
  templateUrl: './generate-enums.component.html',
  styleUrls: ['./generate-enums.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GenerateEnumsComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public generateEnumsService: GenerateEnumsService, private router: Router) { }

  GenerateEnums(command: string)
  {
    this.sub = this.generateEnumsService.GenerateEnums(this.router, command).subscribe();
  }

  StatusEnums(command: string)
  {
    this.sub = this.generateEnumsService.StatusEnums(this.router, command).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesEnums(this.generateEnumsService);
  }

  ngOnDestroy()
  {
    this.sub?.unsubscribe();
  }

}
