import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualPlumesItemListComponent } from 'src/app/components/visual-plumes/visual-plumes-item-list/visual-plumes-item-list.component';

describe('VisualPlumesItemListComponent', () => {
  let component: VisualPlumesItemListComponent;
  let fixture: ComponentFixture<VisualPlumesItemListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ VisualPlumesItemListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualPlumesItemListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
