import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LastUpdateTVFileModelComponent } from 'src/app/components/helpers/last-update-tvfilemodel/last-update-tvfilemodel.component';

describe('LastUpdateTVFileModelComponent', () => {
  let component: LastUpdateTVFileModelComponent;
  let fixture: ComponentFixture<LastUpdateTVFileModelComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ LastUpdateTVFileModelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LastUpdateTVFileModelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
