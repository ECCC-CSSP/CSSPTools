import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListDetailCountryComponent } from './tvitem-list-detail-country.component';

describe('TVItemListDetailCountryComponent', () => {
  let component: TVItemListDetailCountryComponent;
  let fixture: ComponentFixture<TVItemListDetailCountryComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListDetailCountryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListDetailCountryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
