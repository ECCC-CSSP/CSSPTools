import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { Subscription } from 'rxjs';
import { GenerateServicesModel } from './generate-services.models';
import { GenerateServicesService } from './generate-services.service';

@Component({
  selector: 'app-enums',
  templateUrl: './generate-services.component.html',
  styleUrls: ['./generate-services.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GenerateServicesComponent implements OnInit, OnDestroy {
  sub: Subscription;
  generateServicesModel: GenerateServicesModel;

  constructor(private generateServicesService: GenerateServicesService) { }

  ngOnInit(): void {
    this.sub = this.generateServicesService.generateServicesModel$.subscribe(x => this.generateServicesModel = x);
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

}
