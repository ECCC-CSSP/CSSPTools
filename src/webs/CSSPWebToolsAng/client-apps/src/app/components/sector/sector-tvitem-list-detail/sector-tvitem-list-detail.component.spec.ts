import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SectorTVItemListDetailComponent } from 'src/app/components/sector/sector-tvitem-list-detail/sector-tvitem-list-detail.component';

describe('SectorTVItemListDetailComponent', () => {
  let component: SectorTVItemListDetailComponent;
  let fixture: ComponentFixture<SectorTVItemListDetailComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ SectorTVItemListDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SectorTVItemListDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
