import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListItemMWQMRunComponent } from 'src/app/components/tvitems/tvitem-list-item-mwqm-run/tvitem-list-item-mwqm-run.component';

describe('TVItemListItemMWQMRunComponent', () => {
  let component: TVItemListItemMWQMRunComponent;
  let fixture: ComponentFixture<TVItemListItemMWQMRunComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListItemMWQMRunComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListItemMWQMRunComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
