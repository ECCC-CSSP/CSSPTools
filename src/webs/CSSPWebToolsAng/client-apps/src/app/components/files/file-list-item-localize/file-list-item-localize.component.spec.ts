import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FileListItemLocalizeComponent } from 'src/app/components/files/file-list-item-localize/file-list-item-localize.component';

describe('FileListItemLocalizeComponent', () => {
  let component: FileListItemLocalizeComponent;
  let fixture: ComponentFixture<FileListItemLocalizeComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ FileListItemLocalizeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FileListItemLocalizeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
