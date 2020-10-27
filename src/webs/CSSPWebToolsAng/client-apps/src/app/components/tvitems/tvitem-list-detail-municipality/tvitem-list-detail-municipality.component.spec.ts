import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListDetailMunicipalityComponent } from './tvitem-list-detail-municipality.component';

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
