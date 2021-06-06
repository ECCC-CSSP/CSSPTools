import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableMonitoringStatsByMonthComponent } from 'src/app/components/table/table-monitoring-stats-by-month/table-monitoring-stats-by-month.component';

describe('TableMonitoringStatsByMonthComponent', () => {
  let component: TableMonitoringStatsByMonthComponent;
  let fixture: ComponentFixture<TableMonitoringStatsByMonthComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableMonitoringStatsByMonthComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableMonitoringStatsByMonthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
