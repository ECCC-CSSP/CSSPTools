import { ComponentFixture, TestBed } from '@angular/core/testing';
import { StatCountComponent } from 'src/app/components/stat-count/stat-count.component';

describe('StatCountComponent', () => {
  let component: StatCountComponent;
  let fixture: ComponentFixture<StatCountComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ StatCountComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StatCountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
