import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GenerateEnumsComponent } from './generate-enums.component';

describe('GenerateEnumsComponent', () => {
  let component: GenerateEnumsComponent;
  let fixture: ComponentFixture<GenerateEnumsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GenerateEnumsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GenerateEnumsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
