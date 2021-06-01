import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartMonitoringStatByYearComponent } from 'src/app/components/chart/chart-monitoring-stat-by-year/chart-monitoring-stat-by-year.component';

describe('ChartMonitoringStatByYearComponent', () => {
  let component: ChartMonitoringStatByYearComponent;
  let fixture: ComponentFixture<ChartMonitoringStatByYearComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChartMonitoringStatByYearComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChartMonitoringStatByYearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
