import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartMonitoringStatComponent } from 'src/app/components/chart/chart-monitoring-stat/chart-monitoring-stat.component';

describe('ChartMonitoringStatComponent', () => {
  let component: ChartMonitoringStatComponent;
  let fixture: ComponentFixture<ChartMonitoringStatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChartMonitoringStatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChartMonitoringStatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
