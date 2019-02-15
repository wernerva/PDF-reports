import {Component} from '@angular/core';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public navLinks: { path: string, label: string }[] = [
    { path: '/server-side', label: 'Server Side Reports'},
    { path: '/from-pdfBody', label: 'From HTML'}
  ];
}
