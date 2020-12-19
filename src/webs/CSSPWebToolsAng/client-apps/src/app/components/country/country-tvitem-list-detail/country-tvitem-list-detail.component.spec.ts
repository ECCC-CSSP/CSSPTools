import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CountryTVItemListDetailComponent } from 'src/app/components/country/country-tvitem-list-detail/country-tvitem-list-detail.component';

describe('CountryTVItemListDetailComponent', () => {
  let component: CountryTVItemListDetailComponent;
  let fixture: ComponentFixture<CountryTVItemListDetailComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ CountryTVItemListDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryTVItemListDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
