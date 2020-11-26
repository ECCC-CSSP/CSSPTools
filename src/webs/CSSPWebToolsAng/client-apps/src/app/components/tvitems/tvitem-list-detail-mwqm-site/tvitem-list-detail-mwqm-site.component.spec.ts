import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListDetailMWQMSiteComponent } from 'src/app/components/tvitems/tvitem-list-detail-mwqm-site/tvitem-list-detail-mwqm-site.component';

describe('TVItemListDetailMWQMSiteComponent', () => {
  let component: TVItemListDetailMWQMSiteComponent;
  let fixture: ComponentFixture<TVItemListDetailMWQMSiteComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListDetailMWQMSiteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListDetailMWQMSiteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
