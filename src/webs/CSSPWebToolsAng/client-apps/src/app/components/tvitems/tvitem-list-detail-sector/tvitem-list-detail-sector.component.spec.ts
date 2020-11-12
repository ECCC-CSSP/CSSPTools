import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListDetailSectorComponent } from 'src/app/components/tvitems/tvitem-list-detail-sector/tvitem-list-detail-sector.component';

describe('TVItemListDetailSectorComponent', () => {
  let component: TVItemListDetailSectorComponent;
  let fixture: ComponentFixture<TVItemListDetailSectorComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListDetailSectorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListDetailSectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
