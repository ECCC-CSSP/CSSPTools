import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LastUpdateTVItemModelComponent } from 'src/app/components/helpers/last-update-tvitemmodel/last-update-tvitemmodel.component';

describe('LastUpdateTVItemModelComponent', () => {
  let component: LastUpdateTVItemModelComponent;
  let fixture: ComponentFixture<LastUpdateTVItemModelComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ LastUpdateTVItemModelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LastUpdateTVItemModelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
