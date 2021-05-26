import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FileListItemMenuComponent } from 'src/app/components/files/file-list-item-menu/file-list-item-menu.component';

describe('FileListItemMenuComponent', () => {
  let component: FileListItemMenuComponent;
  let fixture: ComponentFixture<FileListItemMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ FileListItemMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FileListItemMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
