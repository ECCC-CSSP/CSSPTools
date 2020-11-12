import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListDetailMunicipalityComponent } from 'src/app/components/tvitems/tvitem-list-detail-municipality/tvitem-list-detail-municipality.component';

describe('TVItemListDetailMunicipalityComponent', () => {
  let component: TVItemListDetailMunicipalityComponent;
  let fixture: ComponentFixture<TVItemListDetailMunicipalityComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListDetailMunicipalityComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListDetailMunicipalityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
