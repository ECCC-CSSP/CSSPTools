import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableMonitoringStatByYearComponent } from 'src/app/components/table/table-monitoring-stat-by-year/table-monitoring-stat-by-year.component';

describe('TableMonitoringStatByYearComponent', () => {
  let component: TableMonitoringStatByYearComponent;
  let fixture: ComponentFixture<TableMonitoringStatByYearComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableMonitoringStatByYearComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableMonitoringStatByYearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
