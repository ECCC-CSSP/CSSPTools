import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableMonitoringStatDataComponent } from 'src/app/components/table/table-monitoring-stat-data/table-monitoring-stat-data.component';

describe('TableMonitoringStatDataComponent', () => {
  let component: TableMonitoringStatDataComponent;
  let fixture: ComponentFixture<TableMonitoringStatDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableMonitoringStatDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableMonitoringStatDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
