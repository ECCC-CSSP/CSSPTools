import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SectorTVItemListItemMenuComponent } from 'src/app/components/sector/sector-tvitem-list-item-menu/sector-tvitem-list-item-menu.component';

describe('SectorTVItemListItemMenuComponent', () => {
  let component: SectorTVItemListItemMenuComponent;
  let fixture: ComponentFixture<SectorTVItemListItemMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ SectorTVItemListItemMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SectorTVItemListItemMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
