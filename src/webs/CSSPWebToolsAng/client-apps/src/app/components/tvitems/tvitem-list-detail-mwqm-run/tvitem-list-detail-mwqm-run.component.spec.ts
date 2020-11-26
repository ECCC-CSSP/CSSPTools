import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListDetailMWQMRunComponent } from 'src/app/components/tvitems/tvitem-list-detail-mwqm-run/tvitem-list-detail-mwqm-run.component';

describe('TVItemListDetailMWQMRunComponent', () => {
  let component: TVItemListDetailMWQMRunComponent;
  let fixture: ComponentFixture<TVItemListDetailMWQMRunComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListDetailMWQMRunComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListDetailMWQMRunComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
