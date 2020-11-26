import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListItemAreaComponent } from 'src/app/components/tvitems/tvitem-list-item-area/tvitem-list-item-area.component';

describe('TVItemListItemAreaComponent', () => {
  let component: TVItemListItemAreaComponent;
  let fixture: ComponentFixture<TVItemListItemAreaComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListItemAreaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListItemAreaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
