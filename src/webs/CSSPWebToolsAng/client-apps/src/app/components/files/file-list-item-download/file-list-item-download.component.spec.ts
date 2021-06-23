import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FileListItemDownloadComponent } from 'src/app/components/files/file-list-item-download/file-list-item-download.component';

describe('FileListItemDownloadComponent', () => {
  let component: FileListItemDownloadComponent;
  let fixture: ComponentFixture<FileListItemDownloadComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ FileListItemDownloadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FileListItemDownloadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
