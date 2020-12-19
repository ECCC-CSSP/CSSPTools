import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SectorTVItemListItemComponent } from 'src/app/components/sector/sector-tvitem-list-item/sector-tvitem-list-item.component';

describe('SectorTVItemListItemComponent', () => {
  let component: SectorTVItemListItemComponent;
  let fixture: ComponentFixture<SectorTVItemListItemComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ SectorTVItemListItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SectorTVItemListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
