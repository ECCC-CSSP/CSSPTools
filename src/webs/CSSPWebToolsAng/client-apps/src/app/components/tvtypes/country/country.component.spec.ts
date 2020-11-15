import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryComponent } from 'src/app/components/tvtypes/country/country.component';

describe('CountryComponent', () => {
  let component: CountryComponent;
  let fixture: ComponentFixture<CountryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});