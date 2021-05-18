import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableFCStatComponent } from 'src/app/components/table/table-fc-stat/table-fc-stat.component';

describe('TableFCStatComponent', () => {
  let component: TableFCStatComponent;
  let fixture: ComponentFixture<TableFCStatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableFCStatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableFCStatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
