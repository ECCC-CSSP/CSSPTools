import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CountryTVItemListItemMenuComponent } from 'src/app/components/country/country-tvitem-list-item-menu/country-tvitem-list-item-menu.component';

describe('CountryTVItemListItemMenuComponent', () => {
  let component: CountryTVItemListItemMenuComponent;
  let fixture: ComponentFixture<CountryTVItemListItemMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ CountryTVItemListItemMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryTVItemListItemMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
