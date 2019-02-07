import {Component} from '@angular/core';
import {FileOpenerService, IFileData} from './file-opener.service';
import {HttpClient, HttpHeaders, HttpRequest, HttpResponse} from '@angular/common/http';
import {environment} from '../environments/environment';

export enum Orientation {
  landscape = 'landscape',
  portrait = 'portrait'
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public title = 'PDF Generator Demo';
  public Orientation = Orientation;
  public html: string = '';
  public pdfOrientation: Orientation = Orientation.portrait;

  constructor(private fileOpenerSvc: FileOpenerService, private http: HttpClient) {
  }

  public getFooReport(orientation: Orientation): void {
    this.http.get(`${environment.serviceUrl}api/fooreports/pdf/${orientation}`).toPromise().then(
      fileData => this.fileOpenerSvc.openDownload(fileData),
      err => console.log(err)
    );
  }

  public htmlToPdf(): void {
    let body: { orientation: number, htmlContent: string };
    const headers = new HttpHeaders().set('Accept', 'application/json').set('Content-Type', 'application/json');
    let req: HttpRequest<any>;

    if (this.html.trim() === '') {
      alert('No html to post');
      return;
    }

    body = {orientation: this.pdfOrientation === Orientation.portrait ? 0 : 1, htmlContent: this.html};

    // this.http.post(`${environment.serviceUrl}api/htmltopdf`, JSON.stringify(htmlToPdfRequest), {headers: headers}).toPromise().then(
    //   fileData => this.fileOpenerSvc.openDownload(fileData),
    //   err => console.log(err)
    // );

    req = new HttpRequest<any>('POST', `${environment.serviceUrl}api/htmltopdf`, body, {headers: headers} );


    this.http.request(req).toPromise().then(
      resp => this.fileOpenerSvc.openDownload((resp as HttpResponse<any>).body),
      err => console.log(err)
    );
  }
}
