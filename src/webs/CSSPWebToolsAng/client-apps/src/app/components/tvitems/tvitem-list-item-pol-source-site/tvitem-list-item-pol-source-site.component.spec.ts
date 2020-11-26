import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListItemPolSourceSiteComponent } from 'src/app/components/tvitems/tvitem-list-item-pol-source-site/tvitem-list-item-pol-source-site.component';

describe('TVItemListItemPolSourceSiteComponent', () => {
  let component: TVItemListItemPolSourceSiteComponent;
  let fixture: ComponentFixture<TVItemListItemPolSourceSiteComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListItemPolSourceSiteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListItemPolSourceSiteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
