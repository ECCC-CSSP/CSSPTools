import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FileListByPurposeComponent } from 'src/app/components/files/file-list-by-purpose/file-list-by-purpose.component';

describe('FileListByPurposeComponent', () => {
  let component: FileListByPurposeComponent;
  let fixture: ComponentFixture<FileListByPurposeComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ FileListByPurposeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FileListByPurposeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
