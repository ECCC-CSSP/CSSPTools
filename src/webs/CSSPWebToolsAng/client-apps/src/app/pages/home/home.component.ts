import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { HomeService } from './home.service';
import { LoadLocalesHomeText } from './home.locales';
import { AppService } from 'src/app/app.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent implements OnInit, OnDestroy {

  constructor(public homeService: HomeService, public appService: AppService) { }

  ngOnInit(): void {
    LoadLocalesHomeText(this.homeService);
  }

  ngOnDestroy() {
  }
}
