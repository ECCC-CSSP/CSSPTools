import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AreaItemComponent } from 'src/app/components/area/area-item/area-item.component';

describe('AreaItemComponent', () => {
  let component: AreaItemComponent;
  let fixture: ComponentFixture<AreaItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ AreaItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AreaItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
