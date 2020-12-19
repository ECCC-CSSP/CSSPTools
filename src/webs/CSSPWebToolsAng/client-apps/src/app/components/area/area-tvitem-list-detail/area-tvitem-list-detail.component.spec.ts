import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AreaTVItemListDetailComponent } from 'src/app/components/area/area-tvitem-list-detail/area-tvitem-list-detail.component';

describe('AreaTVItemListDetailComponent', () => {
  let component: AreaTVItemListDetailComponent;
  let fixture: ComponentFixture<AreaTVItemListDetailComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ AreaTVItemListDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AreaTVItemListDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
