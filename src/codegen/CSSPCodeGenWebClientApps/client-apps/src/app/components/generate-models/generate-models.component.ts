import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { Subscription } from 'rxjs';
import { GenerateModelsModel } from './generate-models.models';
import { GenerateModelsService } from './generate-models.service';

@Component({
  selector: 'app-models',
  templateUrl: './generate-models.component.html',
  styleUrls: ['./generate-models.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GenerateModelsComponent implements OnInit, OnDestroy {
  sub: Subscription;
  generateModelsModel: GenerateModelsModel;

  constructor(private generateModelsService: GenerateModelsService) { }

  ngOnInit(): void {
    this.sub = this.generateModelsService.generateModelsModel$.subscribe(x => this.generateModelsModel = x);
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

}
