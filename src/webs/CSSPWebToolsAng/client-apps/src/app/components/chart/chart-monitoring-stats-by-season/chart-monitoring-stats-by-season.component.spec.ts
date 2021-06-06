import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartMonitoringStatsBySeasonComponent } from 'src/app/components/chart/chart-monitoring-stats-by-season/chart-monitoring-stats-by-season.component';

describe('ChartMonitoringStatsBySeasonComponent', () => {
  let component: ChartMonitoringStatsBySeasonComponent;
  let fixture: ComponentFixture<ChartMonitoringStatsBySeasonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChartMonitoringStatsBySeasonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChartMonitoringStatsBySeasonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
