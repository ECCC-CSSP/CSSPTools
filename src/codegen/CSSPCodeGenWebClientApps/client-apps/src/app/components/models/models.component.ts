import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { Subscription } from 'rxjs';
import { ModelsModel } from './models.models';
import { ModelsService } from './models.service';

@Component({
  selector: 'app-models',
  templateUrl: './models.component.html',
  styleUrls: ['./models.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ModelsComponent implements OnInit, OnDestroy {
  sub: Subscription;
  modelsModel: ModelsModel;

  constructor(private modelsService: ModelsService) { }

  ngOnInit(): void {
    this.sub = this.modelsService.modelsModel$.subscribe(x => this.modelsModel = x);
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

}
