import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryItemCreateComponent } from 'src/app/components/country/country-item-create/country-item-create.component';

describe('CountryItemCreateComponent', () => {
  let component: CountryItemCreateComponent;
  let fixture: ComponentFixture<CountryItemCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryItemCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryItemCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
