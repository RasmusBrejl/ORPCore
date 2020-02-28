import { Component } from '@angular/core';
import { Handler } from './viewHandler';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  handler = Handler
  title = 'ORB';
}
