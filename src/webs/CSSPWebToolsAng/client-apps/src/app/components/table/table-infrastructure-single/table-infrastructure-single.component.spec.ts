import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableInfrastructureSingleComponent } from 'src/app/components/table/table-infrastructure-single/table-infrastructure-single.component';

describe('TableInfrastructureSingleComponent', () => {
  let component: TableInfrastructureSingleComponent;
  let fixture: ComponentFixture<TableInfrastructureSingleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableInfrastructureSingleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableInfrastructureSingleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
