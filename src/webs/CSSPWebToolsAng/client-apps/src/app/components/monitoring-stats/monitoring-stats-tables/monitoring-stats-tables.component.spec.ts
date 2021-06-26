import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MonitoringStatsTablesComponent } from 'src/app/components/monitoring-stats/monitoring-stats-tables/monitoring-stats-tables.component';

describe('MonitoringStatsTablesComponent', () => {
  let component: MonitoringStatsTablesComponent;
  let fixture: ComponentFixture<MonitoringStatsTablesComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MonitoringStatsTablesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MonitoringStatsTablesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
