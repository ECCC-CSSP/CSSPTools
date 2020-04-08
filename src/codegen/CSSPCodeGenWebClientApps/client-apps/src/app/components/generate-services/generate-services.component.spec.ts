import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GenerateServicesComponent } from './generate-services.component';

describe('EnumsComponent', () => {
  let component: GenerateServicesComponent;
  let fixture: ComponentFixture<GenerateServicesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GenerateServicesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GenerateServicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
