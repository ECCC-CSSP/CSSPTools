import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SubsectorTVItemListDetailComponent } from 'src/app/components/subsector/subsector-tvitem-list-detail/subsector-tvitem-list-detail.component';

describe('SubsectorTVItemListDetailComponent', () => {
  let component: SubsectorTVItemListDetailComponent;
  let fixture: ComponentFixture<SubsectorTVItemListDetailComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ SubsectorTVItemListDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubsectorTVItemListDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
