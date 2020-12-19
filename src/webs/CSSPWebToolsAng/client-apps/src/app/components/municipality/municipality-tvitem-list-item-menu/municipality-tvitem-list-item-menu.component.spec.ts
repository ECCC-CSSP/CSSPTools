import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MunicipalityTVItemListItemMenuComponent } from 'src/app/components/area/area-tvitem-list-item-menu/area-tvitem-list-item-menu.component';

describe('MunicipalityTVItemListItemMenuComponent', () => {
  let component: MunicipalityTVItemListItemMenuComponent;
  let fixture: ComponentFixture<MunicipalityTVItemListItemMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MunicipalityTVItemListItemMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MunicipalityTVItemListItemMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
