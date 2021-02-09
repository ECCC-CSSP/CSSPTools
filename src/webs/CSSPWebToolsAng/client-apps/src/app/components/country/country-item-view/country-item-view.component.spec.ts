import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryItemViewComponent } from 'src/app/components/country/country-item-view/country-item-view.component';

describe('CountryItemViewComponent', () => {
  let component: CountryItemViewComponent;
  let fixture: ComponentFixture<CountryItemViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryItemViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryItemViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
