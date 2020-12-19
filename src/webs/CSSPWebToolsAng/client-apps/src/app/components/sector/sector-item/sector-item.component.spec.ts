import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SectorItemComponent } from 'src/app/components/sector/sector-item/sector-item.component';

describe('SectorItemComponent', () => {
  let component: SectorItemComponent;
  let fixture: ComponentFixture<SectorItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ SectorItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SectorItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
