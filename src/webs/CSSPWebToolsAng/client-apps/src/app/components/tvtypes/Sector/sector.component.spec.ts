import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SectorComponent } from 'src/app/components/tvtypes/sector/sector.component';

describe('SectorComponent', () => {
  let component: SectorComponent;
  let fixture: ComponentFixture<SectorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ SectorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
