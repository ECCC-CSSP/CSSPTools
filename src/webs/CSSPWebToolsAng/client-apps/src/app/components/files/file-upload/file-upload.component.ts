import { ElementRef, ViewChild } from '@angular/core';
import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { FileUploadService } from 'src/app/services/file';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css'],
})
export class FileUploadComponent implements OnInit, OnDestroy {
  @ViewChild("fileUpload", { static: false }) fileUpload: ElementRef; 
  files = [];
  
  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public fileUploadService: FileUploadService
  ) {
  }

  ngOnInit() { }

  ngOnDestroy() { }

  UploadFile(file) {
    const formData = new FormData();
    formData.append('file', file.data);
    this.fileUploadService.Working = true;
    file.inProgress = true;
    this.fileUploadService.UploadFile(formData);
  }

  private uploadFiles() {
    this.fileUpload.nativeElement.value = '';
    this.files.forEach(file => {
      this.UploadFile(file);
    });
  }

  onClick() {
    const fileUpload = this.fileUpload.nativeElement; fileUpload.onchange = () => {
      for (let index = 0; index < fileUpload.files?.length; index++) {
        const file = fileUpload.files[index];
        this.files.push({ data: file, inProgress: false, progress: 0 });
      }
      this.uploadFiles();
    };
    fileUpload.click();
  }

}
