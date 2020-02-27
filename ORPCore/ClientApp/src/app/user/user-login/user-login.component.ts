import { Component } from '@angular/core';
import { User } from '../user';
import { UserService } from '../User.Service';

@Component({
  selector: 'user-login-component',
  templateUrl: 'user-login.component.html',
  styleUrls: ['user-login.component.css']
})
export class UserLoginComponent {

 //private userService: UserService;

 public constructor() {
    
 }
  public user: User;
  public loginfailed: boolean;

  public ngOnInit() {
    this.user = new User();
    this.user.name = "1";
  }

  public login(){
    
    this.loginfailed = !this.loginfailed;
    // var userLogin = this.userService.tryLogIn(this.user);
    // if(!userLogin) {
    //   this.loginfailed = true;
    // }
  }

}
