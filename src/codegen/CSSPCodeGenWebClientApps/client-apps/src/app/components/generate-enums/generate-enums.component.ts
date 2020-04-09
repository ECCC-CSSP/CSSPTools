import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { GenerateEnumsService } from './generate-enums.service';
import { LoadLocalesEnums } from './generate-enums.locales';
import { GenerateEnumsModel } from '.';
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

  ngOnInit(): void {
    LoadLocalesEnums(this.generateEnumsService);
  }

  ngOnDestroy()
  {
    this.sub.unsubscribe();
  }

  CompareEnumsAndOldEnums() {
    this.sub = this.generateEnumsService.CompareEnumsAndOldEnums(this.router).subscribe();
  }

  EnumsGenerated_cs() {
    this.sub = this.generateEnumsService.EnumsGenerated_cs(this.router).subscribe();
  }

  EnumsTestGenerated_cs() {
    this.sub = this.generateEnumsService.EnumsTestGenerated_cs(this.router).subscribe();
 }

 GeneratePolSourceEnumCodeFiles() {
  this.sub = this.generateEnumsService.GeneratePolSourceEnumCodeFiles(this.router).subscribe();
}
}
