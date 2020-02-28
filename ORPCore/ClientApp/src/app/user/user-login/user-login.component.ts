import { Component } from '@angular/core';
import { User } from '../user';
import { UserService } from '../User.Service';
import { HttpClient } from '@angular/common/http';
import { Handler } from '../../viewHandler';


@Component({
  selector: 'user-login-component',
  templateUrl: 'user-login.component.html',
  styleUrls: ['user-login.component.css']
})

export class UserLoginComponent {

 //private userService: UserService;

 public constructor(private userService: UserService) {
    
 }
  public user: User;
  public loginfailed: boolean;
  public userlogin: any;

public playerName: any;

  public ngOnInit() {
    this.user = new User();
    this.user.name = "";
    this.user.password = "";
  }

  public login(){
    var isLoggedin = false
    var userLogin = this.userService.tryLogIn(this.user).then(res => {
      if (res) {
        Handler.userId = res.userId
        Handler.isLoggedIn = true
      }
    });
    if(!userLogin) {
      this.loginfailed = true;
    }
  }
}
