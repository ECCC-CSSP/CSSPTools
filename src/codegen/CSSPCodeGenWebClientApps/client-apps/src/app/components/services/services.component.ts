import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { Subscription } from 'rxjs';
import { ServicesModel } from './services.models';
import { ServicesService } from './services.service';

@Component({
  selector: 'app-enums',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ServicesComponent implements OnInit, OnDestroy {
  sub: Subscription;
  servicesModel: ServicesModel;

  constructor(private servicesService: ServicesService) { }

  ngOnInit(): void {
    this.sub = this.servicesService.servicesModel$.subscribe(x => this.servicesModel = x);
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

}
