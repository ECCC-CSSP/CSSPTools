import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TVItemLastUpdateComponent } from 'src/app/components/tvitem/tvitem-last-update/tvItem-last-update.component';

describe('TVItemLastUpdateComponent', () => {
  let component: TVItemLastUpdateComponent;
  let fixture: ComponentFixture<TVItemLastUpdateComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ TVItemLastUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemLastUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
