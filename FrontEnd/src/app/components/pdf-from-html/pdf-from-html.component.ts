import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest, HttpResponse } from '@angular/common/http';
import { FileOpenerService } from '../../services/file-opener.service';
import { Orientation } from '../../common/Orientation';
import { environment } from '../../../environments/environment';
import {HtmlToPdfRequest} from '../../interfaces/htmlToPdfRequest';
import {Margins} from '../../interfaces/margins';

@Component({
  selector: 'app-pdf-from-html',
  templateUrl: './pdf-from-html.component.html',
  styleUrls: ['./pdf-from-html.component.css']
})
export class PdfFromHtmlComponent implements OnInit {
  public pdfHeader = '';
  public pdfBody = '';
  public pdfFooter = '';
  public pdfOrientation: Orientation = Orientation.portrait;
  public orientation = Orientation;
  public margins: Margins = { top: 10, right: 10, bottom: 10, left: 10 };

  constructor(private fileOpenerSvc: FileOpenerService, private http: HttpClient) {}

  ngOnInit() {}

  public preview(): void {
    this.getPdf(true);
  }

  public pdf(): void {
    this.getPdf(false);
  }

  private getPdf(preview: boolean): void {
    const headers = new HttpHeaders().set('Accept', 'application/json').set('Content-Type', 'application/json');
    const url = `${environment.serviceUrl}api/htmltopdf${preview ? '/preview' : ''}`;
    let requestBody: HtmlToPdfRequest;
    let req: HttpRequest<any>;

    if (this.pdfBody.trim() === '') {
      alert('No pdfBody to post');
      return;
    }

    requestBody = {
      orientation: this.pdfOrientation === Orientation.portrait ? 0 : 1,
      pdfHeader: this.pdfHeader,
      pdfBody: this.pdfBody,
      pdfFooter: this.pdfFooter,
      margins: this.margins
    };

    req = new HttpRequest<any>('POST', url, requestBody, {
      headers: headers,
      responseType: preview ? 'text' : 'json'
    });

    this.http
      .request(req)
      .toPromise()
      .then(
        resp => {
          const responseBody = (resp as HttpResponse<any>).body;

          if (preview) {
            const opener = window.open(null, '_blank');
            opener.document.write(responseBody);
          } else {
            this.fileOpenerSvc.openDownload(responseBody);
          }
        },
        err => console.log(err)
      );
  }
}
