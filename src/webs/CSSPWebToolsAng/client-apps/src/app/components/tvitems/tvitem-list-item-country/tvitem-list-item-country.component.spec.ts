import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListItemCountryComponent } from 'src/app/components/tvitems/tvitem-list-item-country/tvitem-list-item-country.component';

describe('TVItemListItemCountryComponent', () => {
  let component: TVItemListItemCountryComponent;
  let fixture: ComponentFixture<TVItemListItemCountryComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListItemCountryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListItemCountryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
