import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MapComponent implements OnInit, OnDestroy {
 
  
  constructor() {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }
}
