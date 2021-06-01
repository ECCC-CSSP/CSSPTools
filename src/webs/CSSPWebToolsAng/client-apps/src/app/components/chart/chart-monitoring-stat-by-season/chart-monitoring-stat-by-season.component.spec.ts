import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartMonitoringStatBySeasonComponent } from 'src/app/components/chart/chart-monitoring-stat-by-season/chart-monitoring-stat-by-season.component';

describe('ChartMonitoringStatBySeasonComponent', () => {
  let component: ChartMonitoringStatBySeasonComponent;
  let fixture: ComponentFixture<ChartMonitoringStatBySeasonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChartMonitoringStatBySeasonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChartMonitoringStatBySeasonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
