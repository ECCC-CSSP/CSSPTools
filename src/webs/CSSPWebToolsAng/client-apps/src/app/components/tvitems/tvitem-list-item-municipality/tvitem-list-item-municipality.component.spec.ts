import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListItemMunicipalityComponent } from 'src/app/components/tvitems/tvitem-list-item-municipality/tvitem-list-item-municipality.component';

describe('TVItemListItemMunicipalityComponent', () => {
  let component: TVItemListItemMunicipalityComponent;
  let fixture: ComponentFixture<TVItemListItemMunicipalityComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListItemMunicipalityComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListItemMunicipalityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
