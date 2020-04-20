import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { GenerateModelsService } from './generate-models.service';
import { LoadLocalesModels } from './generate-models.locales';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-models',
  templateUrl: './generate-models.component.html',
  styleUrls: ['./generate-models.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GenerateModelsComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public generateModelsService: GenerateModelsService, private router: Router) { }

  GenerateModels(command: string)
  {
    this.sub = this.generateModelsService.GenerateModels(this.router, command).subscribe();
  }

  StatusModels(command: string)
  {
    this.sub = this.generateModelsService.StatusModels(this.router, command).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesModels(this.generateModelsService);
  }

  ngOnDestroy()
  {
    this.sub?.unsubscribe();
  }

}
