import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

import { User } from './user';

export class UserService {

endpoint: string = 'http://localhost:3000/api/user/';

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
    return this.http.get(this.endpoint).pipe(
      map(this.extractData));
  }

}