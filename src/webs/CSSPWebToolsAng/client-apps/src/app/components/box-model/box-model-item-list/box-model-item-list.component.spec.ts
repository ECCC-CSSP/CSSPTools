import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BoxModelItemListComponent } from 'src/app/components/box-model/box-model-item-list/box-model-item-list.component';

describe('BoxModelItemListComponent', () => {
  let component: BoxModelItemListComponent;
  let fixture: ComponentFixture<BoxModelItemListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ BoxModelItemListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BoxModelItemListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
