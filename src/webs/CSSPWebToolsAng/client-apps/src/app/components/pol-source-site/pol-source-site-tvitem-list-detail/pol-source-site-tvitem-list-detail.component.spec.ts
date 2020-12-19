import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PolSourceSiteTVItemListDetailComponent } from 'src/app/components/pol-source-site/pol-source-site-tvitem-list-detail/pol-source-site-tvitem-list-detail.component';

describe('PolSourceSiteTVItemListDetailComponent', () => {
  let component: PolSourceSiteTVItemListDetailComponent;
  let fixture: ComponentFixture<PolSourceSiteTVItemListDetailComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ PolSourceSiteTVItemListDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolSourceSiteTVItemListDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
