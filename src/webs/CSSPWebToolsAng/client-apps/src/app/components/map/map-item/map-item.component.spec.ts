import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MapItemComponent } from 'src/app/components/map/map-item/map-item.component';

describe('MapItemComponent', () => {
  let component: MapItemComponent;
  let fixture: ComponentFixture<MapItemComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ MapItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MapItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
