import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubsectorItemViewComponent } from 'src/app/components/subsector/subsector-item-view/subsector-item-view.component';

describe('SubsectorItemViewComponent', () => {
  let component: SubsectorItemViewComponent;
  let fixture: ComponentFixture<SubsectorItemViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ SubsectorItemViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubsectorItemViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
