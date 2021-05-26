import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMRunItemCreateComponent } from 'src/app/components/mwqm-run/mwqm-run-item-create/mwqm-run-item-create.component';

describe('MWQMRunItemCreateComponent', () => {
  let component: MWQMRunItemCreateComponent;
  let fixture: ComponentFixture<MWQMRunItemCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMRunItemCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMRunItemCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
