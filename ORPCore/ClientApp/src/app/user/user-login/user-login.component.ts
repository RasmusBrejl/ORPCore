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

 public noName: boolean;
 public wrongUser: boolean;

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
    this.noName = false;
  }

  public login(){
    //this.noName = true;
    if(!this.user.name) {
      this.noName = true;
    }
    else {
      this.noName = false;
    }
    var isLoggedin = false
    var userLogin = this.userService.tryLogIn(this.user).then(res => {
      if (res) {
        Handler.userId = res.userId
        Handler.isLoggedIn = true
      }
      else {
        this.loginfailed = true;
      }
    });
    if(!userLogin) {
      this.loginfailed = true;
    }
  }
}
