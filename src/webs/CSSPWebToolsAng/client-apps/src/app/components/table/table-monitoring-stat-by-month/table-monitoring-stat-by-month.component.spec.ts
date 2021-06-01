import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableMonitoringStatByMonthComponent } from 'src/app/components/table/table-monitoring-stat-by-month/table-monitoring-stat-by-month.component';

describe('TableMonitoringStatByMonthComponent', () => {
  let component: TableMonitoringStatByMonthComponent;
  let fixture: ComponentFixture<TableMonitoringStatByMonthComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableMonitoringStatByMonthComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableMonitoringStatByMonthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
