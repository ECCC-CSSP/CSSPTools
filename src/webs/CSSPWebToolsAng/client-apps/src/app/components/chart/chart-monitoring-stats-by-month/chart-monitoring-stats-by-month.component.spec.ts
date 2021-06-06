import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartMonitoringStatsByMonthComponent } from 'src/app/components/chart/chart-monitoring-stats-by-month/chart-monitoring-stats-by-month.component';

describe('ChartMonitoringStatsByMonthComponent', () => {
  let component: ChartMonitoringStatsByMonthComponent;
  let fixture: ComponentFixture<ChartMonitoringStatsByMonthComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChartMonitoringStatsByMonthComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChartMonitoringStatsByMonthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
