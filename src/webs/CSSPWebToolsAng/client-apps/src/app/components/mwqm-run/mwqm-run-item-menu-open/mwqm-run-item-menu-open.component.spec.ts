import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MWQMRunItemMenuOpenComponent } from 'src/app/components/mwqm-run/mwqm-run-item-menu-open/mwqm-run-item-menu-open.component';

describe('MWQMRunItemMenuOpenComponent', () => {
  let component: MWQMRunItemMenuOpenComponent;
  let fixture: ComponentFixture<MWQMRunItemMenuOpenComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MWQMRunItemMenuOpenComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMRunItemMenuOpenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
