import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

import { User } from './user';
@Injectable({
  providedIn: 'root'
})
export class UserService {

endpoint: string = 'https://wa-oapl.azurewebsites.net/';

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
    console.log(user)
    return this.http.get(this.endpoint+'?username='+user.name+'&password='+user.password).pipe(
      map(this.extractData));
  }
}