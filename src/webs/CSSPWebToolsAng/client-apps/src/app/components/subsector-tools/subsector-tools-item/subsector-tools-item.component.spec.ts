import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubsectorToolsItemComponent } from 'src/app/components/subsector-tools/subsector-tools-item/subsector-tools-item.component';

describe('SubsectorToolsItemComponent', () => {
  let component: SubsectorToolsItemComponent;
  let fixture: ComponentFixture<SubsectorToolsItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ SubsectorToolsItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubsectorToolsItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
