import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableMonitoringStatsByYearComponent } from 'src/app/components/table/table-monitoring-stats-by-year/table-monitoring-stats-by-year.component';

describe('TableMonitoringStatsByYearComponent', () => {
  let component: TableMonitoringStatsByYearComponent;
  let fixture: ComponentFixture<TableMonitoringStatsByYearComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableMonitoringStatsByYearComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableMonitoringStatsByYearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
