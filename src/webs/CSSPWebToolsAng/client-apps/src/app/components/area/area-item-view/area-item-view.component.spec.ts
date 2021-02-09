import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AreaItemViewComponent } from 'src/app/components/area/area-item-view/area-item-view.component';

describe('AreaItemViewComponent', () => {
  let component: AreaItemViewComponent;
  let fixture: ComponentFixture<AreaItemViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ AreaItemViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AreaItemViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
