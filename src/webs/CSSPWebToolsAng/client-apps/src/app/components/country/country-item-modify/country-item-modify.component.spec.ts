import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryItemModifyComponent } from 'src/app/components/country/country-item-modify/country-item-modify.component';

describe('CountryItemModifyComponent', () => {
  let component: CountryItemModifyComponent;
  let fixture: ComponentFixture<CountryItemModifyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryItemModifyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryItemModifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
