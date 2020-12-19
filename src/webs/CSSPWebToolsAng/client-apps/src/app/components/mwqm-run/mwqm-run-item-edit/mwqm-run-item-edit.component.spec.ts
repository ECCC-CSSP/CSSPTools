import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMRunItemComponent } from 'src/app/components/mwqm-run/mwqm-run-item/mwqm-run-item.component';

describe('MWQMRunItemComponent', () => {
  let component: MWQMRunItemComponent;
  let fixture: ComponentFixture<MWQMRunItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMRunItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMRunItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
