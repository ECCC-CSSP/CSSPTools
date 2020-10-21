import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubsectorComponent } from './subsector.component';

describe('SubsectorComponent', () => {
  let component: SubsectorComponent;
  let fixture: ComponentFixture<SubsectorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ SubsectorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubsectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
