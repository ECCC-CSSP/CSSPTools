import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SectorItemViewComponent } from 'src/app/components/sector/sector-item-view/sector-item-view.component';

describe('SectorItemViewComponent', () => {
  let component: SectorItemViewComponent;
  let fixture: ComponentFixture<SectorItemViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ SectorItemViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SectorItemViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
