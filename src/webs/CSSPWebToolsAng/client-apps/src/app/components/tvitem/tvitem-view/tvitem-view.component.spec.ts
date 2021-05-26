import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TVItemViewComponent } from 'src/app/components/tvitem/tvitem-view/tvitem-view.component';

describe('TVItemViewComponent', () => {
  let component: TVItemViewComponent;
  let fixture: ComponentFixture<TVItemViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ TVItemViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TVItemViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
