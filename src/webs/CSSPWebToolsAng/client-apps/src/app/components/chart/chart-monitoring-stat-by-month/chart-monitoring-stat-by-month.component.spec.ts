import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartMonitoringStatByMonthComponent } from 'src/app/components/chart/chart-monitoring-stat-by-month/chart-monitoring-stat-by-month.component';

describe('ChartMonitoringStatByMonthComponent', () => {
  let component: ChartMonitoringStatByMonthComponent;
  let fixture: ComponentFixture<ChartMonitoringStatByMonthComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChartMonitoringStatByMonthComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChartMonitoringStatByMonthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
