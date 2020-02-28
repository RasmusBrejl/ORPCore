import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ORB';

  public showRoutePlanner: boolean = false;
  public showLogin: boolean = true;

  @Input() showLogin: boolean;

  public login() {
    this.showLogin = false;
  }

}
