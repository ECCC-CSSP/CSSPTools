import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubsectorItemComponent } from 'src/app/components/subsector/subsector-item/subsector-item.component';

describe('SubsectorItemComponent', () => {
  let component: SubsectorItemComponent;
  let fixture: ComponentFixture<SubsectorItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ SubsectorItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubsectorItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
