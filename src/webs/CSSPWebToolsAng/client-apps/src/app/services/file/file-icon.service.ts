import { Injectable } from '@angular/core';
import { FileTypeEnum } from 'src/app/enums/generated/FileTypeEnum';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';

@Injectable({
  providedIn: 'root'
})
export class FileIconService {

  constructor() {
  }

  GetFileIcon(tvFileModel: TVFileModel) {
    let fileName: string = '';
    switch (tvFileModel.TVFile.FileType) {
      case FileTypeEnum.CSV:
      case FileTypeEnum.XLSX:
        {
          fileName = 'Excel_icon16';
        }
        break;
      case FileTypeEnum.DFS0:
      case FileTypeEnum.DFS1:
      case FileTypeEnum.DFSU:
      case FileTypeEnum.MESH:
        {
          fileName = 'DataFile_icon16';
        }
        break;
      case FileTypeEnum.DOCX:
        {
          fileName = 'Word_icon16';
        }
        break;
      case FileTypeEnum.GIF:
      case FileTypeEnum.JPEG:
      case FileTypeEnum.JPG:
      case FileTypeEnum.PNG:
        {
          fileName = 'Image_icon16';
        }
        break;
      case FileTypeEnum.HTML:
        {
          fileName = 'Html_icon16';
        }
        break;
      case FileTypeEnum.KML:
      case FileTypeEnum.KMZ:
        {
          fileName = 'GoogleEarth_icon16';
        }
        break;
      case FileTypeEnum.LOG:
      case FileTypeEnum.TXT:
      case FileTypeEnum.XYZ:
        {
          fileName = 'GeneralFile_icon16';
        }
        break;
      case FileTypeEnum.M21FM:
      case FileTypeEnum.M3FM:
        {
          fileName = 'Engine_icon16';
        }
        break;
      case FileTypeEnum.MDF:
        {
          fileName = 'Tool_icon16';
        }
        break;
      case FileTypeEnum.PDF:
        {
          fileName = 'Pdf_icon16';
        }
        break;
      case FileTypeEnum.WMV:
        {
          fileName = 'GeneralFile_icon16';
        }
        break;
      default:
        {
          fileName = 'GeneralFile_icon16';
        }
    }

    return `../../../assets/images/${fileName}.png`;

  }

}
