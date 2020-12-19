import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MunicipalityTVItemListDetailComponent } from 'src/app/components/municipality/municipality-tvitem-list-detail/municipality-tvitem-list-detail.component';

describe('MunicipalityTVItemListDetailComponent', () => {
  let component: MunicipalityTVItemListDetailComponent;
  let fixture: ComponentFixture<MunicipalityTVItemListDetailComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MunicipalityTVItemListDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MunicipalityTVItemListDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
