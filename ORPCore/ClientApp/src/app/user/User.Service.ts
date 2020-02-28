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
  console.log(res)
    let body = res;
    return body || { };
  }

  tryLogIn(user: User): Observable<any> {
    console.log(user)
    var endpoint = this.endpoint+'?username='+user.name+'&password='+user.password
    console.log(endpoint)
    return this.http.get(endpoint).pipe(
      map(this.extractData));
  }
}