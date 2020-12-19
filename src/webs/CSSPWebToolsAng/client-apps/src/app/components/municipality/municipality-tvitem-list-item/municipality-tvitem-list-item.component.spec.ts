import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MunicipalityTVItemListItemComponent } from 'src/app/components/municipality/municipality-tvitem-list-item/municipality-tvitem-list-item.component';

describe('MunicipalityTVItemListItemComponent', () => {
  let component: MunicipalityTVItemListItemComponent;
  let fixture: ComponentFixture<MunicipalityTVItemListItemComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MunicipalityTVItemListItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MunicipalityTVItemListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
