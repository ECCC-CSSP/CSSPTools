import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SectorItemEditComponent } from 'src/app/components/sector/sector-item-edit/sector-item-edit.component';

describe('SectorItemEditComponent', () => {
  let component: SectorItemEditComponent;
  let fixture: ComponentFixture<SectorItemEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ SectorItemEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SectorItemEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
