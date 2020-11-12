import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemListComponent } from 'src/app/components/tvitems/tvitem-list/tvitem-list.component';

describe('TVItemListComponent', () => {
  let component: TVItemListComponent;
  let fixture: ComponentFixture<TVItemListComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
