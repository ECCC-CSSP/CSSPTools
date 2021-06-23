import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FileListLocalizeAllComponent } from 'src/app/components/files/file-list-localize-all/file-list-localize-all.component';

describe('FileListLocalizeAllComponent', () => {
  let component: FileListLocalizeAllComponent;
  let fixture: ComponentFixture<FileListLocalizeAllComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ FileListLocalizeAllComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FileListLocalizeAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
