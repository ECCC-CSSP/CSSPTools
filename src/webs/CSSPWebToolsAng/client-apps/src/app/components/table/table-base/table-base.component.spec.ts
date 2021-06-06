import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableBaseComponent } from 'src/app/components/table/table-base/table-base.component';

describe('TableBaseComponent', () => {
  let component: TableBaseComponent;
  let fixture: ComponentFixture<TableBaseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableBaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
