import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListDetailProvinceComponent } from 'src/app/components/tvitems/tvitem-list-detail-province/tvitem-list-detail-province.component';

describe('TVItemListDetailProvinceComponent', () => {
  let component: TVItemListDetailProvinceComponent;
  let fixture: ComponentFixture<TVItemListDetailProvinceComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListDetailProvinceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListDetailProvinceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
