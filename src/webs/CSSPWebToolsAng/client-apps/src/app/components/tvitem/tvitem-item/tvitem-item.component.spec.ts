import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemItemComponent } from 'src/app/components/tvitem/tvitem-item/tvitem-item.component';

describe('TVItemItemComponent', () => {
  let component: TVItemItemComponent;
  let fixture: ComponentFixture<TVItemItemComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
