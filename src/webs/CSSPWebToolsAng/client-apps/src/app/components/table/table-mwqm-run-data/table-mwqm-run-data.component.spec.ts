import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableMWQMRunDataComponent } from 'src/app/components/table/table-mwqm-run-data/table-mwqm-run-data.component';

describe('TableMWQMRunDataComponent', () => {
  let component: TableMWQMRunDataComponent;
  let fixture: ComponentFixture<TableMWQMRunDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableMWQMRunDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableMWQMRunDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
