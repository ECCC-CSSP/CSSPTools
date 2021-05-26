import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMRunItemModifyComponent } from 'src/app/components/mwqm-run/mwqm-run-item-modify/mwqm-run-item-modify.component';

describe('MWQMRunItemModifyComponent', () => {
  let component: MWQMRunItemModifyComponent;
  let fixture: ComponentFixture<MWQMRunItemModifyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMRunItemModifyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMRunItemModifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
