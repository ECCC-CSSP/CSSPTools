import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMRunItemEditComponent } from 'src/app/components/mwqm-run/mwqm-run-item-edit/mwqm-run-item-edit.component';

describe('MWQMRunItemEditComponent', () => {
  let component: MWQMRunItemEditComponent;
  let fixture: ComponentFixture<MWQMRunItemEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMRunItemEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMRunItemEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
