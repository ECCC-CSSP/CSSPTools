import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListDetailPolSourceSiteComponent } from 'src/app/components/tvitems/tvitem-list-detail-pol-source-site/tvitem-list-detail-pol-source-site.component';

describe('TVItemListDetailPolSourceSiteComponent', () => {
  let component: TVItemListDetailPolSourceSiteComponent;
  let fixture: ComponentFixture<TVItemListDetailPolSourceSiteComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListDetailPolSourceSiteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListDetailPolSourceSiteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
