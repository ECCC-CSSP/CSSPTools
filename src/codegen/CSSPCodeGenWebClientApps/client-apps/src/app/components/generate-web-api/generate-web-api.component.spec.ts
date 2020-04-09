import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GenerateWebAPIComponent } from './generate-web-api.component';

describe('GenerateWebAPIComponent', () => {
  let component: GenerateWebAPIComponent;
  let fixture: ComponentFixture<GenerateWebAPIComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GenerateWebAPIComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GenerateWebAPIComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
