import { Component } from '@angular/core';
import { User } from '../user';
import { UserService } from '../User.Service';
import { HttpClient } from '@angular/common/http';

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
    this.user.name = "1";
  }

  public login(){
    console.log(this.user);
    console.log(this.playerName);
    this.loginfailed = !this.loginfailed;
    var userLogin = this.userService.tryLogIn(this.user);
    console.log(userLogin);
    // if(!userLogin) {
    //   this.loginfailed = true;
    // }
  }
  public onKey(event: any) { // without type info
    console.log(event);
  }
}
