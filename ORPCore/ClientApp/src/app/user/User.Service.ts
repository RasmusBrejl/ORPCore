import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

import { User } from './user';

@Injectable({
  providedIn: 'root'
})

export class UserService {

endpoint: string = 'https://wa-oapl.azurewebsites.net/RequestRoute';
httpOptions: any;

constructor(private http: HttpClient, ) { 
    const httpOptions = {
    headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Access-Control-Allow-Origin': '*'
  })
};
}

private extractData(res: Response) {
    let body = res;
    return body || { };
  }

  tryLogIn(user: User): Observable<any> {
    // var requestRoute = this.endpoint + "?username=" + user.name + "&password=" + user.password;
    // console.log(requestRoute);
    this.http.get<any>(this.endpoint).subscribe(data => {
    console.log(data);
})
    var response = this.http.get(this.endpoint).pipe(
      map(this.extractData));
    return response;
  }
}
