import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GenerateAngularComponent } from './generate-angular.component';

describe('GenerateAngularComponent', () => {
  let component: GenerateAngularComponent;
  let fixture: ComponentFixture<GenerateAngularComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GenerateAngularComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GenerateAngularComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
