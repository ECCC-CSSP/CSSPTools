import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListDetailRootComponent } from './tvitem-list-detail-root.component';

describe('TVItemListDetailRootComponent', () => {
  let component: TVItemListDetailRootComponent;
  let fixture: ComponentFixture<TVItemListDetailRootComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListDetailRootComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListDetailRootComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
