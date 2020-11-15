import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RainExceedanceComponent } from 'src/app/components/tvtypes/rain-exceedance/rain-exceedance.component';

describe('RainExceedanceComponent', () => {
  let component: RainExceedanceComponent;
  let fixture: ComponentFixture<RainExceedanceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ RainExceedanceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RainExceedanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
