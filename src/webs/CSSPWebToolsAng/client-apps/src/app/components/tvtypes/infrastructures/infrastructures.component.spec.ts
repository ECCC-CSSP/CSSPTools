import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfrastructuresComponent } from 'src/app/components/tvtypes/infrastructures/infrastructures.component';

describe('InfrastructuresComponent', () => {
  let component: InfrastructuresComponent;
  let fixture: ComponentFixture<InfrastructuresComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ InfrastructuresComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfrastructuresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
