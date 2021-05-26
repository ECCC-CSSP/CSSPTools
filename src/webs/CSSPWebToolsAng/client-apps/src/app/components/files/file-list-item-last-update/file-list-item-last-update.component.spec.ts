import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FileListItemLastUpdateComponent } from 'src/app/components/files/file-list-item-last-update/file-list-item-last-update.component';

describe('FileListItemLastUpdateComponent', () => {
  let component: FileListItemLastUpdateComponent;
  let fixture: ComponentFixture<FileListItemLastUpdateComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ FileListItemLastUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FileListItemLastUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
