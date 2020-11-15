import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExportArcGISComponent } from 'src/app/components/tvtypes/export-arc-gis/export-arc-gis.component';

describe('ExportArcGISComponent', () => {
  let component: ExportArcGISComponent;
  let fixture: ComponentFixture<ExportArcGISComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ ExportArcGISComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExportArcGISComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
