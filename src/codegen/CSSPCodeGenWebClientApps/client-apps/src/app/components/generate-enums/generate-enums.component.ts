import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { LoadLocalesEnums } from './generate-enums.locales';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { GenerateEnumsService } from './index';
import { DotNetService } from 'src/app/services/dotnet';

@Component({
  selector: 'app-enums',
  templateUrl: './generate-enums.component.html',
  styleUrls: ['./generate-enums.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GenerateEnumsComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public dotNetService: DotNetService, public generateEnumsService: GenerateEnumsService, private router: Router) { }

  RunEnums(solutionFileName: string)
  {
    this.sub = this.dotNetService.DotNet(this.router, "Run", solutionFileName).subscribe();
  }

  RunStatus(solutionFileName: string)
  {
    this.sub = this.dotNetService.DotNetStatus(this.router, "Status", solutionFileName).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesEnums(this.generateEnumsService);
  }

  ngOnDestroy()
  {
    this.sub?.unsubscribe();
  }

}
