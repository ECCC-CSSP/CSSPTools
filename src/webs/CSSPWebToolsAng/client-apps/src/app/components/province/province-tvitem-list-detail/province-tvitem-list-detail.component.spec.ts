import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ProvinceTVItemListDetailComponent } from 'src/app/components/province/province-tvitem-list-detail/province-tvitem-list-detail.component';

describe('ProvinceTVItemListDetailComponent', () => {
  let component: ProvinceTVItemListDetailComponent;
  let fixture: ComponentFixture<ProvinceTVItemListDetailComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ ProvinceTVItemListDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvinceTVItemListDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
