import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PolSourceSiteTVItemListItemComponent } from 'src/app/components/pol-source-site/pol-source-site-tvitem-list-item/pol-source-site-tvitem-list-item.component';

describe('PolSourceSiteTVItemListItemComponent', () => {
  let component: PolSourceSiteTVItemListItemComponent;
  let fixture: ComponentFixture<PolSourceSiteTVItemListItemComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ PolSourceSiteTVItemListItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolSourceSiteTVItemListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
