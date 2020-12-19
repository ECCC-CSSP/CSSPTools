import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SubsectorTVItemListItemComponent } from 'src/app/components/subsector/subsector-tvitem-list-item/subsector-tvitem-list-item.component';

describe('SubsectorTVItemListItemComponent', () => {
  let component: SubsectorTVItemListItemComponent;
  let fixture: ComponentFixture<SubsectorTVItemListItemComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ SubsectorTVItemListItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubsectorTVItemListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
