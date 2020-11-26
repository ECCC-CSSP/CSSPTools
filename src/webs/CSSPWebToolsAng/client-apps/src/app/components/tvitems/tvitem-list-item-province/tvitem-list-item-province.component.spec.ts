import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListItemProvinceComponent } from 'src/app/components/tvitems/tvitem-list-item-province/tvitem-list-item-province.component';

describe('TVItemListItemProvinceComponent', () => {
  let component: TVItemListItemProvinceComponent;
  let fixture: ComponentFixture<TVItemListItemProvinceComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListItemProvinceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListItemProvinceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
