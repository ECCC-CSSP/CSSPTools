import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMRunItemViewComponent } from 'src/app/components/mwqm-run/mwqm-run-item-view/mwqm-run-item-view.component';

describe('MWQMRunItemViewComponent', () => {
  let component: MWQMRunItemViewComponent;
  let fixture: ComponentFixture<MWQMRunItemViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMRunItemViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMRunItemViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
