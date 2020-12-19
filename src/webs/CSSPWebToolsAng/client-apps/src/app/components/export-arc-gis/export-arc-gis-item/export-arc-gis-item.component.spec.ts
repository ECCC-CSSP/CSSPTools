import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExportArcGISItemComponent } from 'src/app/components/export-arc-gis/export-arc-gis-item/export-arc-gis-item.component';

describe('ExportArcGISItemComponent', () => {
  let component: ExportArcGISItemComponent;
  let fixture: ComponentFixture<ExportArcGISItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ ExportArcGISItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExportArcGISItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
