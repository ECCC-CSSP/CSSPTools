import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubsectorToolsComponent } from 'src/app/components/tvtypes/subsector-tools/subsector-tools.component';

describe('SubsectorToolsComponent', () => {
  let component: SubsectorToolsComponent;
  let fixture: ComponentFixture<SubsectorToolsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ SubsectorToolsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubsectorToolsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
