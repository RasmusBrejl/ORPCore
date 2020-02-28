import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

import { User } from './user';
@Injectable({
  providedIn: 'root'
})
export class UserService {

endpoint: string = 'https://wa-oapl.azurewebsites.net/user/getuser/';

constructor(private http: HttpClient, ) { 
    const httpOptions = {
    headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};
}

private extractData(res: Response) {
    let body = res;
    return body || { };
  }

  tryLogIn(user: User): Promise<any> {
    console.log(user)
    
    return this.http.get(this.endpoint+'?username='+user.name+'&password='+user.password).toPromise()
      .catch(res => console.log(res))
    //.pipe(
      //map(this.extractData));
  }
}