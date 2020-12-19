import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RainExceedanceItemComponent } from 'src/app/components/rain-exceedance/rain-exceedance-item/rain-exceedance-item.component';

describe('RainExceedanceItemComponent', () => {
  let component: RainExceedanceItemComponent;
  let fixture: ComponentFixture<RainExceedanceItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ RainExceedanceItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RainExceedanceItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
