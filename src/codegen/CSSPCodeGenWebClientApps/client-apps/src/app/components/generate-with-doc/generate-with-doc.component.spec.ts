import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GenerateWithDocComponent } from './generate-with-doc.component';

describe('GenerateWithDocComponent', () => {
  let component: GenerateWithDocComponent;
  let fixture: ComponentFixture<GenerateWithDocComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GenerateWithDocComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GenerateWithDocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
