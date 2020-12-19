import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CountryTVItemListItemComponent } from 'src/app/components/country/country-tvitem-list-item/country-tvitem-list-item.component';

describe('CountryTVItemListItemComponent', () => {
  let component: CountryTVItemListItemComponent;
  let fixture: ComponentFixture<CountryTVItemListItemComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ CountryTVItemListItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryTVItemListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
