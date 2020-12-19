import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryItemComponent } from 'src/app/components/country/country-item/country-item.component';

describe('CountryItemComponent', () => {
  let component: CountryItemComponent;
  let fixture: ComponentFixture<CountryItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
