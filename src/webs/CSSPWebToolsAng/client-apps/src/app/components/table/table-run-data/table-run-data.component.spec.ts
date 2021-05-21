import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableRunDataComponent } from 'src/app/components/table/table-run-data/table-run-data.component';

describe('TableRunDataComponent', () => {
  let component: TableRunDataComponent;
  let fixture: ComponentFixture<TableRunDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableRunDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableRunDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
