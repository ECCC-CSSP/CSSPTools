import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMRunComponent } from 'src/app/components/tvtypes/mwqm-run/mwqm-run.component';

describe('MWQMRunComponent', () => {
  let component: MWQMRunComponent;
  let fixture: ComponentFixture<MWQMRunComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMRunComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMRunComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
