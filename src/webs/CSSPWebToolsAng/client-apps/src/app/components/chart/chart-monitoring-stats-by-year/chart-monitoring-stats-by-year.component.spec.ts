import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartMonitoringStatsByYearComponent } from 'src/app/components/chart/chart-monitoring-stats-by-year/chart-monitoring-stats-by-year.component';

describe('ChartMonitoringStatsByYearComponent', () => {
  let component: ChartMonitoringStatsByYearComponent;
  let fixture: ComponentFixture<ChartMonitoringStatsByYearComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChartMonitoringStatsByYearComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChartMonitoringStatsByYearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
