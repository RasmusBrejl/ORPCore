import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

import { User } from './user';

@Injectable({
  providedIn: 'root'
})

export class UserService {

endpoint: string = 'http://localhost:4002/user/';

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

  tryLogIn(user: User): Observable<any> {
    console.log(user);
    var requestRoute = this.endpoint + "?Username=" + user.name + "&Password=" + user.password;
    return this.http.get(requestRoute).pipe(
      map(this.extractData));
  }

  public changeName(event) {
    console.log(event);
  }
}
