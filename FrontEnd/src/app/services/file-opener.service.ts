import { Injectable } from '@angular/core';
import { Base64 } from './base64';

export interface IFileData {
  fileName?: string;
  contentType?: string;
  base64Data?: string;
}

@Injectable()
export class FileOpenerService {
  constructor() {}

  public openDownload(fileData: IFileData) {
    const arrayBuff: any[] = Base64.base64ToArrayBuffer(fileData.base64Data);
    const blob = new Blob(arrayBuff, { type: fileData.contentType });

    if (window.navigator && window.navigator.msSaveOrOpenBlob) {
      window.navigator.msSaveOrOpenBlob(blob, fileData.fileName);
    } else {
      const link = document.createElement('a');

      link.href = URL.createObjectURL(blob);
      link.target = '_blank';
      link.setAttribute('download', fileData.fileName);

      document.body.appendChild(link);
      link.click();
      document.body.removeChild(link);
    }
  }
}
