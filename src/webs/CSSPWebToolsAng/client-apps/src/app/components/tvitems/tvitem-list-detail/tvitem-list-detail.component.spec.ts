import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListDetailComponent } from './tvitem-list-detail.component';

describe('TVItemListDetailComponent', () => {
  let component: TVItemListDetailComponent;
  let fixture: ComponentFixture<TVItemListDetailComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
