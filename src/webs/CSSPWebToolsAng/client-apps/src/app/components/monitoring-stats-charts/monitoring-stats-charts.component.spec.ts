import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MonitoringStatsChartsComponent } from 'src/app/components/monitoring-stats-charts/monitoring-stats-charts.component';

describe('MonitoringStatsChartsComponent', () => {
  let component: MonitoringStatsChartsComponent;
  let fixture: ComponentFixture<MonitoringStatsChartsComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MonitoringStatsChartsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MonitoringStatsChartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
